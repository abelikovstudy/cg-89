using cg_lab89.Primitives;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace cg_lab89.Figures
{
    internal class Icosahedron
    {
        public Polyhedron shape;
        public Icosahedron()
        {
            Dot a = new Dot(170, 0, 85, FigureType.Icosahedron); //85 52 0
            Dot b = new Dot(53, -162, 85, FigureType.Icosahedron); //85 -52 0
            Dot c = new Dot(0, 0, 190, FigureType.Icosahedron); //-85 -52 0
            Dot d = new Dot(-138, -100, 85, FigureType.Icosahedron); //-85 52 0
            Dot e = new Dot(-138, 100, 85, FigureType.Icosahedron); //0 85 52
            Dot f = new Dot(53, 162, 85, FigureType.Icosahedron); //0 -85 52
            Dot g = new Dot(-170, 0, -85, FigureType.Icosahedron); //0 -85 -52
            Dot h = new Dot(-53, 162, -85, FigureType.Icosahedron); //0 85 -52
            Dot i = new Dot(138, -100, -85, FigureType.Icosahedron); //52 0 85
            Dot j = new Dot(138, 100, -85, FigureType.Icosahedron); //52 0 -85
            Dot k = new Dot(-53, -162, -85f, FigureType.Icosahedron); //-52 0 -85
            Dot l = new Dot(0, 0, -190, FigureType.Icosahedron); //-52 0 85

            Edge ab = new Edge(a, b);
            Edge bc = new Edge(b, c);
            Edge ca = new Edge(c, a);
            Edge bd = new Edge(b, d);
            Edge dc = new Edge(d, c);
            Edge cb = new Edge(c, b);
            Edge de = new Edge(d, e);
            Edge ec = new Edge(e, c);
            Edge cd = new Edge(c, d);
            Edge ef = new Edge(e, f);
            Edge fc = new Edge(f, c);
            Edge ce = new Edge(c, e);
            Edge cf = new Edge(c, f);
            Edge fa = new Edge(f, a);
            Edge ac = new Edge(a, c);
            Edge gh = new Edge(g, h);
            Edge he = new Edge(h, e);
            Edge eg = new Edge(e, g);
            Edge ai = new Edge(a, i);
            Edge ib = new Edge(i, b);
            Edge ba = new Edge(b, a);
            Edge hj = new Edge(h, j);
            Edge jf = new Edge(j, f);
            Edge fh = new Edge(f, h);
            Edge bk = new Edge(b, k);
            Edge kd = new Edge(k, d);
            Edge db = new Edge(d, b);
            Edge ji = new Edge(j, i);
            Edge ia = new Edge(i, a);
            Edge aj = new Edge(a, j);
            Edge dg = new Edge(d, g);
            Edge ge = new Edge(g, e);
            Edge ed = new Edge(e, d);
            Edge ik = new Edge(i, k);
            Edge kb = new Edge(k, b);
            Edge bi = new Edge(b, i);
            Edge eh = new Edge(e, h);
            Edge hf = new Edge(h, f);
            Edge fe = new Edge(f, e);
            Edge dk = new Edge(d, k);
            Edge kg = new Edge(k, g);
            Edge gd = new Edge(g, d);
            Edge fj = new Edge(f, j);
            Edge ja = new Edge(j, a);
            Edge af = new Edge(a, f);
            Edge kl = new Edge(k, l);
            Edge lg = new Edge(l, g);
            Edge gk = new Edge(g, k);
            Edge gl = new Edge(g, l);
            Edge lh = new Edge(l, h);
            Edge hg = new Edge(h, g);
            Edge hl = new Edge(h, l);
            Edge lj = new Edge(l, j);
            Edge jh = new Edge(j, h);
            Edge jl = new Edge(j, l);
            Edge li = new Edge(l, i);
            Edge ij = new Edge(i, j);
            Edge il = new Edge(i, l);
            Edge lk = new Edge(l, k);
            Edge ki = new Edge(k, i);

            Polygon abc = new Polygon(new List<Edge> { ab, bc, ca });
            Polygon bdc = new Polygon(new List<Edge> { bd, dc, cb });
            Polygon dec = new Polygon(new List<Edge> { de, ec, cd });
            Polygon efc = new Polygon(new List<Edge> { ef, fc, ce });
            Polygon cfa = new Polygon(new List<Edge> { cf, fa, ac });
            Polygon ghe = new Polygon(new List<Edge> { gh, he, eg });
            Polygon aib = new Polygon(new List<Edge> { ai, ib, ba });
            Polygon hjf = new Polygon(new List<Edge> { hj, jf, fh });
            Polygon bkd = new Polygon(new List<Edge> { bk, kd, db });
            Polygon jia = new Polygon(new List<Edge> { ji, ia, aj });
            Polygon dge = new Polygon(new List<Edge> { dg, ge, ed });
            Polygon ikb = new Polygon(new List<Edge> { ik, kb, bi });
            Polygon ehf = new Polygon(new List<Edge> { eh, hf, fe });
            Polygon dkg = new Polygon(new List<Edge> { dk, kg, gd });
            Polygon fja = new Polygon(new List<Edge> { fj, ja, af });
            Polygon klg = new Polygon(new List<Edge> { kl, lg, gk });
            Polygon glh = new Polygon(new List<Edge> { gl, lh, hg });
            Polygon hlj = new Polygon(new List<Edge> { hl, lj, jh });
            Polygon jli = new Polygon(new List<Edge> { jl, li, ij });
            Polygon ilk = new Polygon(new List<Edge> { il, lk, ki });


            shape = new Polyhedron(new List<Polygon> { abc, bdc, dec, efc, cfa, ghe, aib, hjf, bkd, jia, dge, ikb, ehf, dkg, fja, klg , glh, hlj, jli, ilk});
            shape.dots = new List<Dot> { a, b, c, d, e, f, g, h, i, j, k, l};
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
            Dot i = dots[8];
            Dot j = dots[9];
            Dot k = dots[10];
            Dot l = dots[11];

            Edge ab = new Edge(a, b);
            Edge bc = new Edge(b, c);
            Edge ca = new Edge(c, a);
            Edge bd = new Edge(b, d);
            Edge dc = new Edge(d, c);
            Edge cb = new Edge(c, b);
            Edge de = new Edge(d, e);
            Edge ec = new Edge(e, c);
            Edge cd = new Edge(c, d);
            Edge ef = new Edge(e, f);
            Edge fc = new Edge(f, c);
            Edge ce = new Edge(c, e);
            Edge cf = new Edge(c, f);
            Edge fa = new Edge(f, a);
            Edge ac = new Edge(a, c);
            Edge gh = new Edge(g, h);
            Edge he = new Edge(h, e);
            Edge eg = new Edge(e, g);
            Edge ai = new Edge(a, i);
            Edge ib = new Edge(i, b);
            Edge ba = new Edge(b, a);
            Edge hj = new Edge(h, j);
            Edge jf = new Edge(j, f);
            Edge fh = new Edge(f, h);
            Edge bk = new Edge(b, k);
            Edge kd = new Edge(k, d);
            Edge db = new Edge(d, b);
            Edge ji = new Edge(j, i);
            Edge ia = new Edge(i, a);
            Edge aj = new Edge(a, j);
            Edge dg = new Edge(d, g);
            Edge ge = new Edge(g, e);
            Edge ed = new Edge(e, d);
            Edge ik = new Edge(i, k);
            Edge kb = new Edge(k, b);
            Edge bi = new Edge(b, i);
            Edge eh = new Edge(e, h);
            Edge hf = new Edge(h, f);
            Edge fe = new Edge(f, e);
            Edge dk = new Edge(d, k);
            Edge kg = new Edge(k, g);
            Edge gd = new Edge(g, d);
            Edge fj = new Edge(f, j);
            Edge ja = new Edge(j, a);
            Edge af = new Edge(a, f);
            Edge kl = new Edge(k, l);
            Edge lg = new Edge(l, g);
            Edge gk = new Edge(g, k);
            Edge gl = new Edge(g, l);
            Edge lh = new Edge(l, h);
            Edge hg = new Edge(h, g);
            Edge hl = new Edge(h, l);
            Edge lj = new Edge(l, j);
            Edge jh = new Edge(j, h);
            Edge jl = new Edge(j, l);
            Edge li = new Edge(l, i);
            Edge ij = new Edge(i, j);
            Edge il = new Edge(i, l);
            Edge lk = new Edge(l, k);
            Edge ki = new Edge(k, i);

            Polygon abc = new Polygon(new List<Edge> { ab, bc, ca });
            Polygon bdc = new Polygon(new List<Edge> { bd, dc, cb });
            Polygon dec = new Polygon(new List<Edge> { de, ec, cd });
            Polygon efc = new Polygon(new List<Edge> { ef, fc, ce });
            Polygon cfa = new Polygon(new List<Edge> { cf, fa, ac });
            Polygon ghe = new Polygon(new List<Edge> { gh, he, eg });
            Polygon aib = new Polygon(new List<Edge> { ai, ib, ba });
            Polygon hjf = new Polygon(new List<Edge> { hj, jf, fh });
            Polygon bkd = new Polygon(new List<Edge> { bk, kd, db });
            Polygon jia = new Polygon(new List<Edge> { ji, ia, aj });
            Polygon dge = new Polygon(new List<Edge> { dg, ge, ed });
            Polygon ikb = new Polygon(new List<Edge> { ik, kb, bi });
            Polygon ehf = new Polygon(new List<Edge> { eh, hf, fe });
            Polygon dkg = new Polygon(new List<Edge> { dk, kg, gd });
            Polygon fja = new Polygon(new List<Edge> { fj, ja, af });
            Polygon klg = new Polygon(new List<Edge> { kl, lg, gk });
            Polygon glh = new Polygon(new List<Edge> { gl, lh, hg });
            Polygon hlj = new Polygon(new List<Edge> { hl, lj, jh });
            Polygon jli = new Polygon(new List<Edge> { jl, li, ij });
            Polygon ilk = new Polygon(new List<Edge> { il, lk, ki });


            List<Polygon> p = new List<Polygon> { abc, bdc, dec, efc, cfa, ghe, aib, hjf, bkd, jia, dge, ikb, ehf, dkg, fja, klg, glh, hlj, jli, ilk };
            return p;
        }
    }
}
