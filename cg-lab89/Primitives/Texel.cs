using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cg_lab89.Primitives
{
    public class Texel
    {
        public double x { get; set; }
        public double y { get; set; }

        public Texel(double _x = 0, double _y = 0)
        {
            x = _x;
            y = _y;
        }

        public static Texel operator +(Texel tp1, Texel tp2)
        {
            if (tp1 == null || tp2 == null) return new Texel(0, 0);
            return new Texel(tp1.x + tp2.x, tp1.y + tp2.y);
        }

        public static Texel operator -(Texel tp1, Texel tp2)
        {
            if (tp1 == null || tp2 == null) return new Texel(0, 0);    
            return new Texel(tp1.x - tp2.x, tp1.y - tp2.y);
        }

        public static Texel operator /(Texel tp1, float d)
        {
            if (tp1 == null) return new Texel(0, 0);
            return new Texel(tp1.x / d, tp1.y / d);
        }
    }
}
