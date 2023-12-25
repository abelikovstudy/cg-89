using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using cg_lab89.MathUtils;
using cg_lab89.Primitives;
namespace cg_lab89.Render
{

    public static class Texturing
    {
        public static List<int> interpolate(int x1, int y1, int x2, int y2)
        {
            List<int> res = new List<int>();
            if (x1 == x2)
            {
                res.Add(y2);
            }

            double step = (y2 - y1) * 1.0f / (x2 - x1); //с таким шагом будем получать новые точки
            double y = y1;
            for (int i = x1; i <= x2; i++)
            {
                res.Add((int)y);
                y += step;
            }

            return res;
        }
        public static List<Texel> interpolate_texture(int x1, Texel t1, int x2, Texel t2)
        {
            List<Texel> res = new List<Texel>();
            if (x1 == x2)
            {
                res.Add(t1);
            }

            Texel step = (t2 - t1) / (x2 - x1); //с таким шагом будем получать новые значения
            Texel y = t1;
            for (int i = x1; i <= x2; i++)
            {
                res.Add(y);
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

            var wpoints = points.Select((p) => (x: (int)p.x, y: (int)p.y, z: (int)p.z, t: p.tex)).ToList();
            if (wpoints.Count > 2)
            {
                var xy01 = interpolate(wpoints[0].y, wpoints[0].x, wpoints[1].y, wpoints[1].x);
            var xy12 = interpolate(wpoints[1].y, wpoints[1].x, wpoints[2].y, wpoints[2].x);
            var xy02 = interpolate(wpoints[0].y, wpoints[0].x, wpoints[2].y, wpoints[2].x);
            var yz01 = interpolate(wpoints[0].y, wpoints[0].z, wpoints[1].y, wpoints[1].z);
            var yz12 = interpolate(wpoints[1].y, wpoints[1].z, wpoints[2].y, wpoints[2].z);
            var yz02 = interpolate(wpoints[0].y, wpoints[0].z, wpoints[2].y, wpoints[2].z);
            xy01.RemoveAt(xy01.Count() - 1); //убрать точку, чтобы не было повтора
            var xy = xy01.Concat(xy12).ToList();
            yz01.RemoveAt(yz01.Count() - 1);
            var yz = yz01.Concat(yz12).ToList();
            //когда растеризуем, треугольник делим надвое
            //ищем координаты, чтобы разделить треугольник на 2
            int center = xy.Count() / 2;
            List<int> lx, rx, lz, rz; //для приращений по координатам
            List<Texel> lefttexture, righttexture; //для приращений по интенсивности цвета
            lefttexture = new List<Texel>();
            righttexture = new List<Texel>();
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

            var lighting01 = interpolate_texture(wpoints[0].y, wpoints[0].t, wpoints[1].y, wpoints[1].t);
            var lighting12 = interpolate_texture(wpoints[1].y, wpoints[1].t, wpoints[2].y, wpoints[2].t);
            var lighting02 = interpolate_texture(wpoints[0].y, wpoints[0].t, wpoints[2].y, wpoints[2].t);
            lighting01.RemoveAt(lighting01.Count() - 1); //убрать точку, чтобы не было повтора
            var lighting = lighting01.Concat(lighting12).ToList();
            if (xy02[center] < xy[center])
            {
                lefttexture = lighting02;
                righttexture = lighting;
            }
            else
            {
                lefttexture = lighting;
                righttexture = lighting02;
            }

            int y0 = wpoints[0].y;
            int y2 = wpoints[2].y;

            for (int i = 0; i <= y2 - y0; i++)
            {
                int leftx = lx[i];
                int rightx = rx[i];
                List<int> zcurr = interpolate(leftx, lz[i], rightx, rz[i]);

                List<Texel> texture_current = interpolate_texture(leftx, lefttexture[i], rightx, righttexture[i]);
                for (int j = leftx; j < rightx; j++)
                {
                    res.Add(new Dot(j, y0 + i, zcurr[j - leftx]));
                    res.Last().tex = texture_current[j - leftx];
                }
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
                res.Add(new List<Dot> { points[0], points[i - 1], points[i] }); //points[0]
            }

            return res;
        }

        public static List<List<Dot>> RasterFigure(Polyhedron figure, ref Camera camera)
        {
            List<List<Dot>> res = new List<List<Dot>>();
            foreach (var polygon in figure.polys) //каждая грань-это многоугольник, который надо растеризовать
            {
                List<Dot> currentface = new List<Dot>();
                List<Dot> points = new List<Dot>();
                //добавим все вершины
                for (int i = 0; i < polygon.Dots.Count; i++)
                {
                    points.Add(polygon.Dots[i]);
                }

                List<List<Dot>> triangles = Triangulate(points); //разбили все грани на треугольники
                foreach (var triangle in triangles)
                {
                    var planeTriangle = ProjectionToPlane(triangle, ref camera);
                    currentface.AddRange(Raster(planeTriangle)); //projection(triangle)
                    //currentface.AddRange(Raster(triangle));
                }

                res.Add(currentface);
            }

            return res;
        }

        public static List<Dot> ProjectionToPlane(List<Dot> points, ref Camera camera) //Camera camera,ProjectionType type 
        {
            List<Dot> res = new List<Dot>();
            // float c = 1000;
            //Matrix matrix = new Matrix(4, 4).fill(1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, -1 / c, 0, 0, 0, 1);//перспективная чисто для начала
            foreach (var p in points) //потом заменить to2D(camera)
            {
                var current = camera.getProjection(p);
                if (current.HasValue)
                {
                    // Point newpoint = new Point(current.Item1.Value.X, current.Item1.Value.Y,current.Item2);
                    //var current = transformPoint(p, matrix);
                    var tocamv = camera.toCameraView(p);
                    Dot newpoint = new Dot(current.Value.X, current.Value.Y, tocamv.z);
                    newpoint.tex = p.tex;
                    res.Add(newpoint);
                }
            }

            return res;
        }
        public static double GetCos(VectorUtils v1, VectorUtils v2)
        {
            double scalar = v1.x * v2.x + v1.y * v2.y + v1.z * v2.z;
            double lengthv1 = Math.Sqrt(v1.x * v1.x + v1.y * v1.y + v1.z * v1.z);
            double lengthv2 = Math.Sqrt(v2.x * v2.x + v2.y * v2.y + v2.z * v2.z);
            double res = scalar / lengthv1 / lengthv2;
            return res;

        }
        public static double GetLightness(Dot v, Light light)
        {
            var normv = new VectorUtils(v).normalize(); 

            var raytovertex = new VectorUtils(v.x - light.Position.x, v.y - light.Position.y, v.z - light.Position.z);
            //cos α = a·b/
            //|a |·| b |
            double cos = GetCos(normv, raytovertex);
            //добавить max(cos,0)
            return cos;
        }

        public static double GetIntense(double lightness)
        {
            return (lightness + 1) / 2;//у Яны в презентации (1+cos)/2
            //return lightness*0.3*0.7;//что-то интуитивные коэффициенты не помогают

        }
        public static VectorUtils NormalVertex(List<Polygon> faces, Polyhedron s)
        {
            VectorUtils res = new VectorUtils(10, 0, 0);
            foreach (var face in faces)
            {
                res.x += face.normalise().x;
                res.y += face.normalise().y;
                res.z += face.normalise().z;
            }
            res.x = res.x / faces.Count();
            res.y = res.y / faces.Count();
            res.z = res.z / faces.Count();
            return res;
        }
        public static void CalculateLambert(ref Polyhedron s, Light light)
        {
            Dictionary<Dot, VectorUtils> normales = new Dictionary<Dot, VectorUtils>();
            for (int i = 0; i < s.polys.Count; i++)
            {
                Polygon f = s.polys[i];
                foreach (var vert in f.Dots)
                {
                    List<Polygon> faces = s.polys.Where(x => x.Dots.Contains(vert)).ToList();//все грани, содержащие данную вершину
                    vert.norm = NormalVertex(faces, s);
                    // normales.Add(vert, NormalVertex(faces, s));
                }

                // List<Face> neededFaces = s.Faces.Where(x => x.Contains(i)).ToList();
                // pointNormal.Add(i, Vectors.CalculateNormal(neededFaces, polyhedron));
            }

            //посчитать вектор нормали для каждой вершины
            foreach (var f in s.polys)
            {
                //посчитать яркость в каждой вершине многоугольника
                foreach (var vert in f.Dots)
                {
                    double lamb = GetLightness(vert, light);

                    double intense = GetIntense(lamb);
                    vert.lightness = (float)intense;
                }
            }
        }

        public static void z_buf(int width, int height, List<Polyhedron> scene, ref Camera camera,ref FastBitmap fb, Light light, bool mode, string filename = @"C:\Users\user\Documents\University\IV Course\Computer Graphics\bundle\Lab9\AdvancedGraphics\textures\gradient.png")
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
            //Bitmap bitmap = new Bitmap(width, height);
            if (mode == true)
            {
                foreach (var shape in scene)
                {
                    for (int i = 0; i < shape.polys.Count; i++)
                    {
                        Polygon f = shape.polys[i];
                        foreach (var vert in f.Dots)
                        {
                            vert.norm = NormalVertex(shape.polys, shape);
                        }

                    }

                    //посчитать вектор нормали для каждой вершины
                    foreach (var f in shape.polys)
                    {
                        //посчитать яркость в каждой вершине многоугольника
                        foreach (var vert in f.Dots)
                        {
                            double lamb = GetLightness(vert, light);
                            double intense = GetIntense(lamb);
                            vert.lightness = (float)intense;
                        }
                    }
                }
            }

            //new FastBitmap(bitmap);
            for (int i = 0; i < width; i++)
                for (int j = 0; j < height; j++)
                    fb.SetPixel(new Point(i, j), Color.White); //new System.Drawing.Point(i, j)
            //z-буфер
            double[,] zbuffer = new double[width, height];
            for (int i = 0; i < width; i++)
                for (int j = 0; j < height; j++)
                    zbuffer[i, j] = double.MaxValue; //Изначально, буфер
            // инициализируется значением z = zmax
            List<List<List<Dot>>> rasterscene = new List<List<List<Dot>>>();
            for (int i = 0; i < scene.Count(); i++)
            {
                rasterscene.Add(RasterFigure(scene[i],ref camera)); //растеризовали все фигуры
            }

            Bitmap bitmap = new Bitmap(filename);
            FastBitmap texture = new FastBitmap(bitmap);
            int withmiddle = width / 2;
            int heightmiddle = height / 2;
            int index = 0;
            for (int i = 0; i < rasterscene.Count(); i++)
            {
                Color color1 = Color.Orange;
                for (int j = 0; j < rasterscene[i].Count(); j++)
                {
                    List<Dot> current = rasterscene[i][j]; //это типа грань но уже растеризованная
                    
                    var cntV = current.Where(x => x.tex.x < 0);
                    if (cntV.Count() > 0)
                    {
                        int x = 5;
                    }

                    foreach (Dot p in current)
                    {
                        int x = (int)(p.x); //

                        int y = (int)(p.y); // + heightmiddle 

                        double u = p.tex.x;
                        double v = p.tex.y;

                        if (x < width && y < height && y > 0 && x > 0)
                        {
                            if (p.z < zbuffer[x, y])
                            {
                                PointF? p1 = camera.getProjection(new Dot(p.x, p.y, p.z));
                                if (p1.HasValue)
                                {
                                    zbuffer[x, y] = p.z;
                                    if (mode == false) //если это текстурирование
                                    {
                                        var color = texture.GetPixel(new System.Drawing.Point(
                                            (int)(u * (texture.Width - 1)), (int)(v * (texture.Height - 1))));
                                        fb.SetPixel(new Point(x, y), color); //canvas.Height - 
                                    }
                                    else //иначе это осчещение, тогда меняем цвет точки согласно степени ее освещенности
                                    {
                                        fb.SetPixel(new Point(x, y),
                                            Color.FromArgb((int)(p.lightness * color1.R), (int)(p.lightness * color1.G),
                                                (int)(p.lightness * color1.B)));
                                        Debug.WriteLine(p.lightness);
                                    }

                                }

                            }
                        }
                    }

                    index++;
                }
            }

        }
    }

}
