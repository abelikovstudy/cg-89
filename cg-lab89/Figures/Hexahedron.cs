using cg_lab89.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cg_lab89.Figures
{
    class Hexahedron
    {
        public Polyhedron shape;
        public Hexahedron() 
        {

            Dot a = new Dot(0, 0,0, FigureType.Hexahedron);
            Dot b = new Dot(100, 0, 0, FigureType.Hexahedron);
            Dot c = new Dot(100, 100, 0, FigureType.Hexahedron);
            Dot d = new Dot(0, 100, 0, FigureType.Hexahedron);
            Dot e = new Dot(0, 0, 100, FigureType.Hexahedron);
            Dot f = new Dot(0, 100, 100, FigureType.Hexahedron);
            Dot g = new Dot(100, 100, 100, FigureType.Hexahedron);
            Dot h = new Dot(100, 0, 100, FigureType.Hexahedron);
            Edge ab = new Edge(a, b);
            Edge bc = new Edge(b, c);
            Edge cd = new Edge(c, d);
            Edge ad = new Edge(a, d);

            Edge ae = new Edge(a, e);
            Edge df = new Edge(d, f);
            Edge cg = new Edge(c, g);
            Edge bh = new Edge(b, h);

            Edge eh = new Edge(e, h);
            Edge hg = new Edge(h, g);
            Edge gf = new Edge(g, f);
            Edge fe = new Edge(f, e);

            Polygon abcd = new Polygon(new List<Edge> { ab, bc, cd, ad });
            Polygon aefd = new Polygon(new List<Edge> { ae, fe, df, ad });
            Polygon dfgc = new Polygon(new List<Edge> { df, gf, cg, cd });
            Polygon bcgh = new Polygon(new List<Edge> { bc, cg, hg, bh });
            Polygon bhea = new Polygon(new List<Edge> { bh, eh, ae, ab });
            Polygon ehgf = new Polygon(new List<Edge> { eh, hg, gf, fe });
            shape = new Polyhedron(new List<Polygon> { abcd, aefd, dfgc, bcgh, bhea, ehgf });
            shape.dots = new List<Dot> { a, b, c, d, e, f, g, h };
        }
        public static List<Polygon> getPolys(List<Dot> dots) 
        {
            Dot a = dots[0];
            Dot b = dots[1];
            Dot c = dots[2];
            Dot d = dots[3];
            Dot e = dots[4];
            Dot f = dots[5];
            Dot g = dots[6];
            Dot h = dots[7];
            Edge ab = new Edge(a, b);
            Edge bc = new Edge(b, c);
            Edge cd = new Edge(c, d);
            Edge ad = new Edge(a, d);

            Edge ae = new Edge(a, e);
            Edge df = new Edge(d, f);
            Edge cg = new Edge(c, g);
            Edge bh = new Edge(b, h);

            Edge eh = new Edge(e, h);
            Edge hg = new Edge(h, g);
            Edge gf = new Edge(g, f);
            Edge fe = new Edge(f, e);

            Polygon abcd = new Polygon(new List<Edge> { ab, bc, cd, ad });
            Polygon aefd = new Polygon(new List<Edge> { ae, fe, df, ad });
            Polygon dfgc = new Polygon(new List<Edge> { df, gf, cg, cd });
            Polygon bcgh = new Polygon(new List<Edge> { bc, cg, hg, bh });
            Polygon bhea = new Polygon(new List<Edge> { bh, eh, ae, ab });
            Polygon ehgf = new Polygon(new List<Edge> { eh, hg, gf, fe });
            return new List<Polygon> { abcd, aefd, dfgc, bcgh, bhea, ehgf };
        }
    }
}
