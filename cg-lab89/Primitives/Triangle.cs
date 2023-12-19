using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cg_lab89.Primitives
{
    public class Triangle
    {
        public PointF x { get; set; }
        public PointF y { get; set; }
        public PointF z { get; set; }

        public List<PointF> vx { get; set; }

        public Triangle(PointF _x, PointF _y, PointF _z)
        {
            x = _x;
            y = _y;
            z = _z;
            vx = new List<PointF>();
            vx.Add(x);
            vx.Add(y);
            vx.Add(z);
        }

        public List<PointF> getVertexes()
        {
            return vx;
        }

        public override string ToString()
        {
            return $"{x} {y} {z}";
        }
    }

    public class Triangulation
    {
        public List<Triangle> triangles { get; set; }
        public List<PointF> p { get; set; }
        public Triangulation(List<Dot> _points, ProjectionType projection)
        {
            triangles = new List<Triangle>();
            p = new List<PointF>();
            foreach(Dot _p in _points) 
            {
                p.Add(_p.getProjection(projection));
            }
        }

        public static List<Triangle> updTriangulate(List<Dot> dots, ProjectionType projection) 
        {
            if (dots.Count == 3) return new List<Triangle> { new Triangle(dots[0].getProjection(projection), dots[1].getProjection(projection), dots[2].getProjection(projection)) };

            List<Triangle> triangles = new List<Triangle>();
            for (int i = 0; i < dots.Count - 2; ++i) 
            {
                triangles.Add(new Triangle(dots[0].getProjection(projection), dots[i].getProjection(projection), dots[i + 1].getProjection(projection)));
            }
            return triangles;
        }

        public List<Triangle> getTriangles()
        {
            triangulation(p);
            return triangles;
        }
        private void triangulation(List<PointF> points)
        {
            if (points.Count() == 3)
            {
                triangles.Add(new Triangle(points[0], points[1], points[2]));
                return;
            }

            int vertexI = -1;
            float max_y = float.MinValue;
            int search;

            foreach (PointF p in points)
            {
                if (p.Y >= max_y)
                {
                    max_y = p.Y;
                    vertexI = points.IndexOf(p);
                }
            }

            if (vertexI > 0)
            {
                search = vertexI - 1;
            }
            else
            {
                search = points.Count() - 1;
            }

            int P = vertexI;
            int B = (vertexI >= 2) ? vertexI - 2 : points.Count() + vertexI - 2;
            int A = (vertexI >= 1) ? vertexI - 1 : points.Count() - 1;
            if (points[search].X < points[vertexI].X)
            {
                int count = 0;
                while (((points[B].X - points[A].X) * (points[P].Y - points[A].Y) - (points[B].Y - points[A].Y) * (points[P].X - points[A].X)) <= 0)
                {
                    if (count > points.Count())
                        break;
                    count++; vertexI = (vertexI + 1) % points.Count();
                    P = vertexI;
                    B = (vertexI >= 2) ? vertexI - 2 : points.Count() + vertexI - 2;
                    A = (vertexI >= 1) ? vertexI - 1 : points.Count() - 1;

                }
                vertexI = A;
            }

            int t2 = -1;
            double max = 0;
            for (int i = 0; i < points.Count(); i++)
            {
                if (i != vertexI && i != vertexI - 1 && i != vertexI + 1)
                {
                    if (isInTriangle((vertexI >= 1) ? points[vertexI - 1] : points[points.Count() - 1], points[vertexI], points[(vertexI + 1) % (points.Count())], points[i]))
                    {
                        if (pointToLineDistance((vertexI >= 1) ? points[vertexI - 1] : points[points.Count() - 1], points[(vertexI + 1) % (points.Count())], points[i]) > max)
                        {
                            max = pointToLineDistance(points[(vertexI >= 1) ? vertexI - 1 : points.Count() - 1], points[(vertexI + 1) % points.Count], points[i]);
                            t2 = i;
                        }
                    }
                }
            }

            if (t2 == -1)
            {
                List<PointF> newP = new List<PointF>();
                newP.Add(points[vertexI]);
                newP.Add(points[(vertexI >= 1) ? vertexI - 1 : points.Count() - 1]);
                newP.Add(points[(vertexI + 1) % points.Count]);
                points.RemoveAt(vertexI);


                triangulation(points);
                triangulation(newP);
                return;
            }
            int var1 = vertexI;
            int var2 = t2;

            List<PointF> newPoints = new List<PointF>();
            while (var1 != var2)
            {
                newPoints.Add(points[var2]);
                var2 = (var2 + 1) % points.Count();
            }
            newPoints.Add(points[var1]);

            foreach (PointF x in newPoints)
                if (x != newPoints[0] && x != newPoints[newPoints.Count() - 1])
                    points.Remove(x);

            triangulation(points);
            triangulation(newPoints);


        }

        float distance(PointF p1, PointF p2, PointF p3)
        {
            return (p1.X - p3.X) * (p2.Y - p3.Y) - (p2.X - p3.X) * (p1.Y - p3.Y);
        }
        private bool isInTriangle(PointF a, PointF b, PointF c, PointF p)
        {
            float d1, d2, d3;
            bool has_neg, has_pos;

            d1 = distance(p, a, b);
            d2 = distance(p, b, c);
            d3 = distance(p, c, a);

            has_neg = (d1 < 0) || (d2 < 0) || (d3 < 0);
            has_pos = (d1 > 0) || (d2 > 0) || (d3 > 0);

            return !(has_neg && has_pos);
        }

        private double pointToLineDistance(PointF A, PointF B, PointF P)
        {
            return Math.Abs((B.Y - A.Y) * P.X - (B.X - A.X) * P.Y + B.X * A.Y - B.Y * A.X) / Math.Sqrt(Math.Pow(B.Y - A.Y, 2) + Math.Pow(B.X - A.X, 2));
        }
    }

}
