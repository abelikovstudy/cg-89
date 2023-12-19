using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using cg_lab89.Primitives;
namespace cg_lab89.Render
{
    using System.Diagnostics;
    using System.Drawing.Drawing2D;

    public static class Z_buffer
    {
        public static List<int> interpolate(int x1, int y1, int x2, int y2)
        {
            List<int> res = new List<int>();
            if (x1 == x2)
            {
                res.Add(y2);
            }
            double step = (y2 - y1) * 1.0f / (x2 - x1);//с таким шагом будем получать новые точки
            double y = y1;
            for (int i = x1; i <= x2; i++)
            {
                res.Add((int)y);
                y += step;
            }
            return res;
        }
        public static List<Dot> Raster(List<Dot> points)
        {
            List<Dot> res = new List<Dot>();
            //отсортировать точки по неубыванию ординаты
            points.Sort((p1, p2) => p1.y.CompareTo(p2.y));
            // "рабочие точки"
            // изначально они находятся в верхней точке
            var wpoints = points.Select((p) => (x: (int)p.x, y: (int)p.y, z: (int)p.z)).ToList();
            var xy01 = interpolate(wpoints[0].y, wpoints[0].x, wpoints[1].y, wpoints[1].x);
            var xy12 = interpolate(wpoints[1].y, wpoints[1].x, wpoints[2].y, wpoints[2].x);
            var xy02 = interpolate(wpoints[0].y, wpoints[0].x, wpoints[2].y, wpoints[2].x);
            var yz01 = interpolate(wpoints[0].y, wpoints[0].z, wpoints[1].y, wpoints[1].z);
            var yz12 = interpolate(wpoints[1].y, wpoints[1].z, wpoints[2].y, wpoints[2].z);
            var yz02 = interpolate(wpoints[0].y, wpoints[0].z, wpoints[2].y, wpoints[2].z);
            xy01.RemoveAt(xy01.Count() - 1);//убрать точку, чтобы не было повтора
            var xy = xy01.Concat(xy12).ToList();
            yz01.RemoveAt(yz01.Count() - 1);
            var yz = yz01.Concat(yz12).ToList();
            //когда растеризуем, треугольник делим надвое
            //ищем координаты, чтобы разделить треугольник на 2
            int center = xy.Count() / 2;
            List<int> lx, rx, lz, rz;//для приращений
            if (xy02[center] < xy[center])
            {
                lx = xy02;
                lz = yz02;
                rx = xy;
                rz = yz;
            }
            else
            {
                lx = xy;
                lz = yz;
                rx = xy02;
                rz = yz02;
            }
            int y0 = wpoints[0].y;
            int y2 = wpoints[2].y;
            for (int i = 0; i <= y2 - y0; i++)
            {
                int leftx = lx[i];
                int rightx = rx[i];
                List<int> zcurr = interpolate(leftx, lz[i], rightx, rz[i]);
                for (int j = leftx; j < rightx; j++)
                {
                    res.Add(new Dot(j, y0 + i, zcurr[j - leftx]));
                }
            }
            return res;
        }
        public static List<List<Dot>> Triangulate(List<Dot> points)
        {
            //если всего 3 точки, то это уже трекгольник
            List<List<Dot>> res = new List<List<Dot>>();
            if (points.Count == 3)
            {
                res = new List<List<Dot>> { points };
            }
            for (int i = 2; i < points.Count(); i++)
            {
                res.Add(new List<Dot> { points[0], points[i - 1], points[i] });//points[0]
            }
            return res;
        }
        public static List<List<Dot>> RasterFigure(Polyhedron figure, ref Camera camera)
        {
            List<List<Dot>> res = new List<List<Dot>>();
            foreach (var polygon in figure.polys)//каждая грань-это многоугольник, который надо растеризовать
            {
                List<Dot> currentface = new List<Dot>();
                List<Dot> points = new List<Dot>();
                //добавим все вершины
                for (int i = 0; i < polygon.Dots.Count; i++)
                {
                    points.Add(polygon.Dots[i]);
                }

                List<List<Dot>> triangles = Triangulate(points);//разбили все грани на треугольники
                foreach (var triangle in triangles)
                {
                    currentface.AddRange(Raster(ProjectionToPlane(triangle, ref camera)));//projection(triangle)
                    //currentface.AddRange(Raster(triangle));
                }
                res.Add(currentface);
            }
            return res;
        }
        public static List<Dot> ProjectionToPlane(List<Dot> points, ref Camera camera)//Camera camera,ProjectionType type 
        {
            List<Dot> res = new List<Dot>();
            foreach (var p in points)//потом заменить to2D(camera)
            {
                var current = camera.getProjection(p);
                if (current.HasValue)
                {
                    // Point newpoint = new Point(current.Item1.Value.X, current.Item1.Value.Y,current.Item2);
                    //var current = transformPoint(p, matrix);
                    var tocamv = camera.toCameraView(p);
                    Dot newpoint = new Dot(current.Value.X, current.Value.Y, tocamv.z);
                    res.Add(newpoint);
                }
            }
            return res;

        }

        public static void z_buf(int width, int height, List<Polyhedron> scene, ref Camera camera, ref FastBitmap fb)
        {
            List<Color> colors = new List<Color> 
            {
                Color.Red,
                Color.Green, 
                Color.Blue,
                Color.Yellow,
                Color.Orange,
                Color.Orchid,
                Color.Purple,
                Color.Plum,
                Color.Pink,
                Color.LightBlue,
                Color.LightGreen,
                Color.Violet

            };
            for (int i = 0; i < width; i++)
                for (int j = 0; j < height; j++)
                    fb.SetPixel(new Point(i,j), Color.DarkGray);
            double[,] zbuffer = new double[width, height];
            for (int i = 0; i < width; i++)
                for (int j = 0; j < height; j++)
                    zbuffer[i, j] = double.MaxValue;
            List<List<List<Dot>>> rasterscene = new List<List<List<Dot>>>();
            for (int i = 0; i < scene.Count(); i++)
            {
                rasterscene.Add(RasterFigure(scene[i], ref camera));//растеризовали все фигуры
            }
            int index = 0;
            for (int i = 0; i < rasterscene.Count(); i++)
            {

                for (int j = 0; j < rasterscene[i].Count(); j++)
                {
                    List<Dot> current = rasterscene[i][j];//это типа грань но уже растеризованная
                    foreach (Dot p in current)
                    {
                        int x = (int)(p.x); //

                        int y = (int)(p.y);// + heightmiddle 
                        
                        if (x < width && y < height && y > 0 && x > 0)
                        {
                            if (p.z < zbuffer[x, y])
                            {
                                Debug.WriteLine($"{x}{y}{p.z}");
                                zbuffer[x, y] = p.z;
                                fb.SetPixel(new Point(x, y), colors[index % colors.Count()]);//fb.Height - 
                            }

                        }
                    }
                    index++;

                }
            }
        }
    }

}
