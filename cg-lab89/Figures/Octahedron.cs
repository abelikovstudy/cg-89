using cg_lab89.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cg_lab89.Figures
{
    class Octahedron
    {
        public Polyhedron shape;
        public Octahedron() 
        {
            Dot a = new Dot(100, 0, 100, FigureType.Octahedron);
            Dot b = new Dot(100, 100, 200, FigureType.Octahedron);
            Dot c = new Dot(200, 100, 100, FigureType.Octahedron);
            Dot d = new Dot(100, 200, 100, FigureType.Octahedron);
            Dot e = new Dot(0, 100, 100, FigureType.Octahedron);
            Dot f = new Dot(100, 100, 0, FigureType.Octahedron);
            Edge ab = new Edge(a, b);
            Edge bc = new Edge(b, c);
            Edge ca = new Edge(c, a);
            Edge cb = new Edge(c, b);
            Edge bd = new Edge(b, d);
            Edge dc = new Edge(d, c);
            Edge db = new Edge(d, b);
            Edge be = new Edge(b, e);
            Edge ed = new Edge(e, d);
            Edge eb = new Edge(e, b);
            Edge ba = new Edge(b, a);
            Edge ae = new Edge(a, e);
            Edge ac = new Edge(a, c);
            Edge cf = new Edge(c, f);
            Edge fa = new Edge(f, a);
            Edge cd = new Edge(c, d);
            Edge df = new Edge(d, f);
            Edge fc = new Edge(f, c);
            Edge de = new Edge(d, e);
            Edge ef = new Edge(e, f);
            Edge fd = new Edge(f, d);
            Edge ea = new Edge(e, a);
            Edge af = new Edge(a, f);
            Edge fe = new Edge(f, e);

            Polygon abc = new Polygon(new List<Edge> { ab, bc, ca });
            Polygon cbd = new Polygon(new List<Edge> { cb, bd, dc });
            Polygon dbe = new Polygon(new List<Edge> { db, be, ed });
            Polygon eba = new Polygon(new List<Edge> { eb, ba, ae });
            Polygon acf = new Polygon(new List<Edge> { ac, cf, fa });
            Polygon cdf = new Polygon(new List<Edge> { cd, df, fc });
            Polygon def = new Polygon(new List<Edge> { de, ef, fd });
            Polygon eaf = new Polygon(new List<Edge> { ea, af, fe });

            shape = new Polyhedron(new List<Polygon> {abc, cbd, dbe, eba, acf, cdf, def, eaf });
            shape.dots = new List<Dot> { a, b, c, d, e, f };
        }
        public static List<Polygon> getPolys(List<Dot> dots) 
        {
            Dot a = dots[0];
            Dot b = dots[1];
            Dot e = dots[2];
            Dot d = dots[3];
            Dot c = dots[4];
            Dot f = dots[5];

            Edge ab = new Edge(a, b);
            Edge bc = new Edge(b, c);
            Edge ca = new Edge(c, a);
            Edge cb = new Edge(c, b);
            Edge bd = new Edge(b, d);
            Edge dc = new Edge(d, c);
            Edge db = new Edge(d, b);
            Edge be = new Edge(b, e);
            Edge ed = new Edge(e, d);
            Edge eb = new Edge(e, b);
            Edge ba = new Edge(b, a);
            Edge ae = new Edge(a, e);
            Edge ac = new Edge(a, c);
            Edge cf = new Edge(c, f);
            Edge fa = new Edge(f, a);
            Edge cd = new Edge(c, d);
            Edge df = new Edge(d, f);
            Edge fc = new Edge(f, c);
            Edge de = new Edge(d, e);
            Edge ef = new Edge(e, f);
            Edge fd = new Edge(f, d);
            Edge ea = new Edge(e, a);
            Edge af = new Edge(a, f);
            Edge fe = new Edge(f, e);

            Polygon abc = new Polygon(new List<Edge> { ab, bc, ca });
            Polygon cbd = new Polygon(new List<Edge> { cb, bd, dc });
            Polygon dbe = new Polygon(new List<Edge> { db, be, ed });
            Polygon eba = new Polygon(new List<Edge> { eb, ba, ae });
            Polygon acf = new Polygon(new List<Edge> { ac, cf, fa });
            Polygon cdf = new Polygon(new List<Edge> { cd, df, fc });
            Polygon def = new Polygon(new List<Edge> { de, ef, fd });
            Polygon eaf = new Polygon(new List<Edge> { ea, af, fe });
            return new List<Polygon> { abc, cbd, dbe, eba, acf, cdf, def, eaf };
        }
    }
}
