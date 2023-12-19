using cg_lab89.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cg_lab89.MathUtils
{
    public class VectorUtils
    {
        public double x, y, z;
        public VectorUtils(double x, double y, double z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public VectorUtils(Dot d)
        {
            this.x = d.x;
            this.y = d.y;
            this.z = d.z;

        }
        public VectorUtils normalize()
        {
            double normalization = Math.Sqrt(Math.Pow(x, 2) + Math.Pow(y, 2) + Math.Pow(z, 2));
            x = x / normalization;
            y = y / normalization;
            z = z / normalization;
            return this;
        }

        public int X { get => (int)x; set => x = value; }
        public int Y { get => (int)y; set => y = value; }
        public int Z { get => (int)z; set => z = value; }


        public static VectorUtils operator -(VectorUtils v1, VectorUtils v2)
        {
            return new VectorUtils(v1.x - v2.x, v1.y - v2.y, v1.z - v2.z);
        }

        public static VectorUtils operator +(VectorUtils v1, VectorUtils v2)
        {
            return new VectorUtils(v1.x + v2.x, v1.y + v2.y, v1.z + v2.z);
        }

        public static VectorUtils operator *(VectorUtils a, VectorUtils b)
        {
            return new VectorUtils(a.y * b.z - a.z * b.y, a.z * b.x - a.x * b.z, a.x * b.y - a.y * b.x);
        }

        public static VectorUtils operator *(double k, VectorUtils b)
        {
            return new VectorUtils(k * b.x, k * b.y, k * b.z);
        }
    }
}

