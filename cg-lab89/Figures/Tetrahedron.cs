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
            Dot b = new Dot(200, 0, 200);
            Dot c = new Dot(200, 200, 0);
            Dot d = new Dot(0, 200, 200);
            Edge ab = new Edge(a, b);
            Edge bc = new Edge(b, c);
            Edge ca = new Edge(c, a);

            Edge ba = new Edge(b, a);
            Edge cb = new Edge(c, b);
            Edge ac = new Edge(a, c);

            Edge db = new Edge(d, b);
            Edge ad = new Edge(a, d);
            Edge cd = new Edge(c, d);

            Edge bd = new Edge(b, d);
            Edge da = new Edge(d, a);
            Edge dc = new Edge(d, c);

            Polygon abc = new Polygon(new List<Edge> { ab, bc, ca });
            Polygon cbd = new Polygon(new List<Edge> { cb, bd, dc });
            Polygon adb = new Polygon(new List<Edge> { ad, db, ba });
            Polygon cda = new Polygon(new List<Edge> { cd, da, ac });

            shape = new Polyhedron(new List<Polygon> { abc, cbd, adb, cda });
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
            Edge ca = new Edge(c, a);

            Edge ba = new Edge(b, a);
            Edge cb = new Edge(c, b);
            Edge ac = new Edge(a, c);

            Edge db = new Edge(d, b);
            Edge ad = new Edge(a, d);
            Edge cd = new Edge(c, d);

            Edge bd = new Edge(b, d);
            Edge da = new Edge(d, a);
            Edge dc = new Edge(d, c);

            Polygon abc = new Polygon(new List<Edge> { ab, bc, ca });
            Polygon cbd = new Polygon(new List<Edge> { cb, bd, dc });
            Polygon adb = new Polygon(new List<Edge> { ad, db, ba });
            Polygon cda = new Polygon(new List<Edge> { cd, da, ac });
            return new List<Polygon> { abc, cbd, adb, cda };
        }
    }
}
