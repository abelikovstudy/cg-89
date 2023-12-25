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

            Dot a = new Dot(0, 0, 0, FigureType.Hexahedron);
            Dot b = new Dot(100, 0, 0, FigureType.Hexahedron);
            Dot c = new Dot(100, 100, 0, FigureType.Hexahedron);
            Dot d = new Dot(0, 100, 0, FigureType.Hexahedron);
            Dot e = new Dot(0, 0, 100, FigureType.Hexahedron);
            Dot f = new Dot(0, 100, 100, FigureType.Hexahedron);
            Dot g = new Dot(100, 100, 100, FigureType.Hexahedron);
            Dot h = new Dot(100, 0, 100, FigureType.Hexahedron);
            a.tex = new Texel(a.x, a.y);
            b.tex = new Texel(b.x, b.y);
            c.tex = new Texel(c.x, c.y);
            d.tex = new Texel(d.x, d.y);
            e.tex = new Texel(e.x, e.y);
            f.tex = new Texel(f.x, f.y);
            g.tex = new Texel(g.x, g.y);
            h.tex = new Texel(h.x, h.y);
            Edge ae = new Edge(a, e);
            Edge eh = new Edge(e, h);
            Edge hb = new Edge(h, b);
            Edge ba = new Edge(b, a);

            Edge bh = new Edge(b, h);
            Edge hg = new Edge(h, g);
            Edge gc = new Edge(g, c);
            Edge cb = new Edge(c, b);
            
            Edge cg = new Edge(c, g);
            Edge gf = new Edge(g, f);
            Edge fd = new Edge(f, d);
            Edge dc = new Edge(d, c);
            
            Edge fe = new Edge(f, e);
            Edge ea = new Edge(e, a);
            Edge ad = new Edge(a, d);
            Edge df = new Edge(d, f);
            
            Edge ab = new Edge(a, b);
            Edge bc = new Edge(b, c);
            Edge cd = new Edge(c, d);
            Edge da = new Edge(d, a);

            Edge ef = new Edge(e, f);
            Edge fg = new Edge(f, g);
            Edge gh = new Edge(g, h);
            Edge he = new Edge(h, e);


            Polygon aehb = new Polygon(new List<Edge> { ae, eh, hb, ba });
            Polygon bhgc = new Polygon(new List<Edge> { bh, hg, gc, cb });
            Polygon cgfd = new Polygon(new List<Edge> { cg, gf, fd, dc });
            Polygon fead = new Polygon(new List<Edge> { fe, ea, ad, df });
            Polygon abcd = new Polygon(new List<Edge> { ab, bc, cd, da });
            Polygon efgh = new Polygon(new List<Edge> { ef, fg, gh, he });
            shape = new Polyhedron(new List<Polygon> { aehb, bhgc, cgfd, fead, abcd, efgh });
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

            a.tex = new Texel(a.x, a.y);
            b.tex = new Texel(b.x, b.y);
            c.tex = new Texel(c.x, c.y);
            d.tex = new Texel(d.x, d.y);
            e.tex = new Texel(e.x, e.y);
            f.tex = new Texel(f.x, f.y);
            g.tex = new Texel(g.x, g.y);
            h.tex = new Texel(h.x, h.y);

            Edge ae = new Edge(a, e);
            Edge eh = new Edge(e, h);
            Edge hb = new Edge(h, b);
            Edge ba = new Edge(b, a);

            Edge bh = new Edge(b, h);
            Edge hg = new Edge(h, g);
            Edge gc = new Edge(g, c);
            Edge cb = new Edge(c, b);

            Edge cg = new Edge(c, g);
            Edge gf = new Edge(g, f);
            Edge fd = new Edge(f, d);
            Edge dc = new Edge(d, c);

            Edge fe = new Edge(f, e);
            Edge ea = new Edge(e, a);
            Edge ad = new Edge(a, d);
            Edge df = new Edge(d, f);

            Edge ab = new Edge(a, b);
            Edge bc = new Edge(b, c);
            Edge cd = new Edge(c, d);
            Edge da = new Edge(d, a);

            Edge ef = new Edge(e, f);
            Edge fg = new Edge(f, g);
            Edge gh = new Edge(g, h);
            Edge he = new Edge(h, e);


            Polygon aehb = new Polygon(new List<Edge> { ae, eh, hb, ba });
            Polygon bhgc = new Polygon(new List<Edge> { bh, hg, gc, cb });
            Polygon cgfd = new Polygon(new List<Edge> { cg, gf, fd, dc });
            Polygon fead = new Polygon(new List<Edge> { fe, ea, ad, df });
            Polygon abcd = new Polygon(new List<Edge> { ab, bc, cd, da });
            Polygon efgh = new Polygon(new List<Edge> { ef, fg, gh, he });
            return new List<Polygon> { aehb, bhgc, cgfd, fead, abcd, efgh };
        }
    }
}
