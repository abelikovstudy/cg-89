using cg_lab89.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Threading.Tasks;

namespace cg_lab89.Figures
{
    class Tetrahedron
    {
        public Polyhedron shape;
        public Tetrahedron()
        {
            Dot a = new Dot(0, 0, 0);
            Dot b = new Dot(100, 0, 0);
            Dot c = new Dot(0, 0, 100);
            Dot d = new Dot(0, 100, 0);
            Edge ab = new Edge(a, b);
            Edge bc = new Edge(b, c);
            Edge ac = new Edge(c, a);
            Edge bd = new Edge(b, d);
            Edge ad = new Edge(a, d);
            Edge cd = new Edge(c, d);
            Polygon abc = new Polygon(new List<Edge> { ab, bc, ac });
            Polygon dbc = new Polygon(new List<Edge> { bd, cd, bc });
            Polygon adc = new Polygon(new List<Edge> { ad, cd, ac });
            Polygon adb = new Polygon(new List<Edge> { ad, bd, ab });
            shape = new Polyhedron(new List<Polygon> { abc, dbc, adc, adb });
            shape.dots = new List<Dot> { a, b, c, d };
        }
        public static List<Polygon> getPolys(List<Dot> dots) 
        {
            Dot a = dots[0];
            Dot b = dots[1];
            Dot c = dots[2];
            Dot d = dots[3];
            Edge ab = new Edge(a, b);
            Edge bc = new Edge(b, c);
            Edge ac = new Edge(a, c);
            Edge bd = new Edge(b, d);
            Edge ad = new Edge(a, d);
            Edge cd = new Edge(c, d);
            Polygon abc = new Polygon(new List<Edge> { ab, bc, ac });
            Polygon dbc = new Polygon(new List<Edge> { bd, bc, cd });
            Polygon adc = new Polygon(new List<Edge> { ad, cd, ac });
            Polygon adb = new Polygon(new List<Edge> { ad, bd, ab });
            return new List<Polygon> { abc, dbc, adc, adb };
        }
    }
}
