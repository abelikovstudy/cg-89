using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using cg_lab89.Primitives;
using static cg_lab89.Constants;

namespace cg_lab89.MathUtils
{
    static class AffineTransformations
    {
        public static double radians(double angle)
        {
            return Math.PI * angle / 180.0;
        }
        public static List<Dot> rotate(List<Dot> dots, double angle, Constants.Axis axis) 
        {
            double rads = radians(angle);
            List<Dot> result = new List<Dot>();
            MatrixUtils rotation;
            switch (axis) 
            {
                
                case Constants.Axis.X:
                    rotation = new MatrixUtils(4,4,1,0,0,0,0,Math.Cos(rads), Math.Sin(rads), 0, 0, -Math.Sin(rads), Math.Cos(rads),0,0,0,0,1);
                    break;

                case Constants.Axis.Y:
                    rotation = new MatrixUtils(4, 4, Math.Cos(rads), 0 , -Math.Sin(rads),0, 0, 1, 0, 0, Math.Sin(rads), 0, Math.Cos(rads), 0, 0, 0, 0, 1);
                    break;

                case Constants.Axis.Z:
                    rotation = new MatrixUtils(4, 4, Math.Cos(rads), Math.Sin(rads), 0, 0, -Math.Sin(rads), Math.Cos(rads), 0, 0, 0, 0, 1, 0, 0, 0,0 ,1);
                    break;

                default:
                    rotation = new MatrixUtils(4, 4, 1, 0, 0, 0, 0, Math.Cos(angle), Math.Sin(angle), 0, 0, -Math.Sin(angle), Math.Cos(angle), 0, 0, 0, 0, 1);
                    break;
            }

            foreach (Dot dot in dots) 
            {
                MatrixUtils resulting = rotation * new MatrixUtils(4, 1, dot.x, dot.y, dot.z, 1);
                result.Add(new Dot((float)resulting.matrix[0,0], (float)resulting.matrix[1, 0], (float)resulting.matrix[2, 0]));
            }
            return result;
        }

        public static List<Dot> shift(List<Dot> dots, double dx, double dy, double dz) 
        {
            List<Dot> result = new List<Dot>();
            MatrixUtils rotation = new MatrixUtils(4, 4, 1, 0, 0, dx, 0, 1, 0, dy, 0, 0, 1, dz, 0, 0, 0, 1);

            foreach (Dot dot in dots)
            {
                MatrixUtils resulting = rotation * new MatrixUtils(4, 1, dot.x, dot.y, dot.z, 1);
                result.Add(new Dot((float)resulting.matrix[0, 0], (float)resulting.matrix[1, 0], (float)resulting.matrix[2, 0]));
            }
            return result;
        }

        public static List<Dot> scale(List<Dot> dots, double dx, double dy, double dz)
        {
            List<Dot> result = new List<Dot>();
            MatrixUtils rotation = new MatrixUtils(4, 4, dx, 0, 0, 0, 0, dy, 0, 0, 0, 0, dz, 0, 0, 0, 0, 1);

            foreach (Dot dot in dots)
            {
                MatrixUtils resulting = rotation * new MatrixUtils(4, 1, dot.x, dot.y, dot.z, 1);
                result.Add(new Dot((float)resulting.matrix[0, 0], (float)resulting.matrix[1, 0], (float)resulting.matrix[2, 0]));
            }
            return result;
        }
        public static List<Dot> rotate_around_center(List<Dot> dots, Dot center,  Constants.Axis axis, double angle) 
        {
            List<Dot> result = new List<Dot>();

            MatrixUtils rotation = new MatrixUtils(4, 4, 1, 0, 0, -center.x, 0, 1, 0, -center.y, 0, 0, 1, -center.z, 0, 0, 0, 1);
            foreach (Dot dot in dots)
            {
                MatrixUtils resulting = rotation * new MatrixUtils(4, 1, dot.x, dot.y, dot.z, 1);
                result.Add(new Dot((float)resulting.matrix[0, 0], (float)resulting.matrix[1, 0], (float)resulting.matrix[2, 0]));
            }

            List<Dot> rs = rotate(result, angle, axis);

            result.Clear();

            rotation = new MatrixUtils(4, 4, 1, 0, 0, center.x, 0, 1, 0, center.y, 0, 0, 1, center.z, 0, 0, 0, 1);
            foreach (Dot dot in rs)
            {
                MatrixUtils resulting = rotation * new MatrixUtils(4, 1, dot.x, dot.y, dot.z, 1);
                result.Add(new Dot((float)resulting.matrix[0, 0], (float)resulting.matrix[1, 0], (float)resulting.matrix[2, 0]));
            }
            return result;
        }

        public static List<Dot> rotate_around_line(List<Dot> dots, Dot lineStart, Dot lineEnd , double angle)
        {
            List<Dot> result = new List<Dot>();
            Dot v = new Dot(lineEnd.x - lineStart.x, lineEnd.y - lineStart.y, lineEnd.z - lineStart.z);
            double length = Math.Sqrt(v.x * v.x + v.y * v.y + v.z * v.z);
            double l = v.x / length;
            double m = v.y / length;
            double n = v.z / length;
            double asin = Math.Sin(AffineTransformations.radians(angle));
            double acos = Math.Cos(AffineTransformations.radians(angle));
            double l2 = l * l;
            double m2 = m * m;
            double n2 = n * n;
            MatrixUtils rotation = new MatrixUtils(4, 4,
                l2 + acos * (1 - l2), l * (1 - acos) * m - n * asin, l * (1 - acos) * n + m * asin, 0,
                l * (1 - acos) * m + n * asin, m2 + acos * (1 - m2), m * (1 - acos) * n - l * asin, 0,
                l * (1 - acos) * n - m * asin, m * (1 - acos) * n + l * asin, n2 + acos * (1 - n2), 0,
                0, 0, 0, 1);

            foreach (Dot dot in dots)
            {
                MatrixUtils resulting = rotation * new MatrixUtils(4, 1, dot.x, dot.y, dot.z, 1);
                result.Add(new Dot((float)resulting.matrix[0, 0], (float)resulting.matrix[1, 0], (float)resulting.matrix[2, 0]));
            }
            return result;
        }

        public static List<Dot> reflection(List<Dot> dots, Constants.Axis axis)
        {
            List<Dot> result = new List<Dot>();
            MatrixUtils reflectionMatrix;
            switch (axis)
            {
                case Constants.Axis.X: // XY                 
                    reflectionMatrix = new MatrixUtils(4, 4, 
                        1, 0, 0, 0,
                        0, 1, 0, 0,
                        0, 0, -1, 0,
                        0, 0, 0, 1);
                    break;
                case Constants.Axis.Y: // XZ
                    reflectionMatrix = new MatrixUtils(4, 4,
                        1, 0, 0, 0,
                        0, -1, 0, 0,
                        0, 0, 1, 0, 
                        0, 0, 0, 1);
                    break;
                case Constants.Axis.Z: // YZ                 
                    reflectionMatrix = new MatrixUtils(4, 4,
                        -1, 0, 0, 0,
                        0, 1, 0, 0,
                        0, 0, 1, 0,
                        0, 0, 0, 1);
                    break;
                default:
                    reflectionMatrix = new MatrixUtils(4, 4,
                        1, 0, 0, 0,
                        0, 1, 0, 0,
                        0, 0, -1, 0,
                        0, 0, 0, 1);
                    break;
            }

            foreach (Dot dot in dots)
            {
                MatrixUtils resulting = reflectionMatrix * new MatrixUtils(4, 1, dot.x, dot.y, dot.z, 1);
                result.Add(new Dot((float)resulting.matrix[0, 0], (float)resulting.matrix[1, 0], (float)resulting.matrix[2, 0]));
            }
            return result;
        }
        public static void rotateVectors(ref VectorUtils vector1, ref VectorUtils vector2, double angle, VectorUtils axis)
        {
            axis.normalize();
            double l = axis.x;
            double m = axis.y;
            double n = axis.z;
            double anglesin = Math.Sin(angle);
            double anglecos = Math.Cos(angle);
            MatrixUtils rotation = new MatrixUtils(4, 4, l * l + anglecos * (1 - l * l), l * (1 - anglecos) * m - n * anglesin, l * (1 - anglecos) * n + m * anglesin, 0,
                                 l * (1 - anglecos) * m + n * anglesin, m * m + anglecos * (1 - m * m), m * (1 - anglecos) * n - l * anglesin, 0,
                                 l * (1 - anglecos) * n - m * anglesin, m * (1 - anglecos) * n + l * anglesin, n * n + anglecos * (1 - n * n), 0,
                                 0, 0, 0, 1);

            var res = rotation * new MatrixUtils(4, 1, vector1.x, vector1.y, vector1.z, 1);
            vector1 = new VectorUtils(res.matrix[0, 0], res.matrix[1, 0], res.matrix[2, 0]).normalize();
            res = rotation * new MatrixUtils(4, 1, vector2.x, vector2.y, vector2.z, 1);
            vector2 = new VectorUtils(res.matrix[0, 0], res.matrix[1, 0], res.matrix[2, 0]).normalize();
        }

    }
}
