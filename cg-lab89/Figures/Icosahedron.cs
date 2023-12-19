using cg_lab89.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cg_lab89.Figures
{
    internal class Icosahedron
    {
        public Polyhedron shape;
        public Icosahedron()
        {
            float phi = 1.6180f;
            float coef = (float)Math.Sqrt(1 + 1.6180f * 1.6180f);
            Dot d0 = new Dot(phi * 100 / coef, 1 * 100 / coef, 0, FigureType.Icosahedron);
            Dot d1 = new Dot(phi * 100 / coef, -1 * 100 / coef, 0, FigureType.Icosahedron);
            Dot d2 = new Dot(-phi * 100 / coef, -1 * 100 / coef, 0, FigureType.Icosahedron);
            Dot d3 = new Dot(-phi * 100 / coef, 1 * 100 / coef, 0, FigureType.Icosahedron);
            Dot d4 = new Dot(0, phi * 100 / coef, 1 * 100 / coef, FigureType.Icosahedron);
            Dot d5 = new Dot(0, -phi * 100 / coef, 1 * 100 / coef, FigureType.Icosahedron);
            Dot d6 = new Dot(0, -phi * 100 / coef, -1 * 100 / coef, FigureType.Icosahedron);
            Dot d7 = new Dot(0, phi * 100 / coef, -1 * 100 / coef, FigureType.Icosahedron);
            Dot d8 = new Dot(1 * 100 / coef, 0, phi * 100 / coef, FigureType.Icosahedron);
            Dot d9 = new Dot(1 * 100 / coef, 0, -phi * 100 / coef, FigureType.Icosahedron);
            Dot d10 = new Dot(-1 * 100 / coef, 0, -phi * 100 / coef, FigureType.Icosahedron);
            Dot d11 = new Dot(-1 * 100 / coef, 0, phi * 100 / coef, FigureType.Icosahedron);

            Edge e1 = new Edge(d7, d0);
            Edge e2 = new Edge(d7, d4);
            Edge e3 = new Edge(d7, d3);
            Edge e4 = new Edge(d7, d10);
            Edge e5 = new Edge(d7, d9);
            Edge e6 = new Edge(d5, d8);
            Edge e7 = new Edge(d5, d11);
            Edge e8 = new Edge(d5, d2);
            Edge e9 = new Edge(d5, d6);
            Edge e10 = new Edge(d5, d1);
            Edge e11 = new Edge(d0, d8);
            Edge e12 = new Edge(d0, d4);
            Edge e13 = new Edge(d8, d4);
            Edge e14 = new Edge(d8, d11);
            Edge e15 = new Edge(d4, d11);
            Edge e16 = new Edge(d4, d3);
            Edge e17 = new Edge(d11, d3);
            Edge e18 = new Edge(d11, d2);
            Edge e19 = new Edge(d3, d2);
            Edge e20 = new Edge(d3, d10);
            Edge e21 = new Edge(d2, d10);
            Edge e22 = new Edge(d2, d6);
            Edge e23 = new Edge(d10, d6);
            Edge e24 = new Edge(d10, d9);
            Edge e25 = new Edge(d6, d9);
            Edge e26 = new Edge(d6, d1);
            Edge e27 = new Edge(d9, d1);
            Edge e28 = new Edge(d9, d0);
            Edge e29 = new Edge(d1, d0);
            Edge e30 = new Edge(d1, d8);

            Polygon p1 = new Polygon(new List<Edge> { e1, e2, e12 });
            Polygon p2 = new Polygon(new List<Edge> { e1, e28, e5 });
            Polygon p3 = new Polygon(new List<Edge> { e2, e3, e16 });
            Polygon p4 = new Polygon(new List<Edge> { e3, e4, e20 });
            Polygon p5 = new Polygon(new List<Edge> { e4, e5, e24 });
            Polygon p6 = new Polygon(new List<Edge> { e6, e14, e7 });
            Polygon p7 = new Polygon(new List<Edge> { e6, e10, e30 });
            Polygon p8 = new Polygon(new List<Edge> { e7, e8, e18 });
            Polygon p9 = new Polygon(new List<Edge> { e8, e9, e22 });
            Polygon p10 = new Polygon(new List<Edge> { e9, e10, e26 });
            Polygon p11 = new Polygon(new List<Edge> { e11, e12, e13 });
            Polygon p12 = new Polygon(new List<Edge> { e11, e29, e30 });
            Polygon p13 = new Polygon(new List<Edge> { e13, e14, e15 });
            Polygon p14 = new Polygon(new List<Edge> { e15, e16, e17 });
            Polygon p15 = new Polygon(new List<Edge> { e17, e18, e19 });
            Polygon p16 = new Polygon(new List<Edge> { e19, e20, e21 });
            Polygon p17 = new Polygon(new List<Edge> { e21, e22, e23 });
            Polygon p18 = new Polygon(new List<Edge> { e23, e24, e25 });
            Polygon p19 = new Polygon(new List<Edge> { e25, e26, e27 });
            Polygon p20 = new Polygon(new List<Edge> { e27, e28, e29 });


            shape = new Polyhedron(new List<Polygon> { p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13, p14, p15, p16, p17, p18, p19, p20 });
            shape.dots = new List<Dot> { d0, d1, d2, d3, d4, d5, d6, d7, d8, d9, d10, d11 };
        }
        public static List<Polygon> getPolys(List<Dot> dots)
        {
            Dot d0 = dots[0];
            Dot d1 = dots[1];
            Dot d2 = dots[2];
            Dot d3 = dots[3];
            Dot d4 = dots[4];
            Dot d5 = dots[5];
            Dot d6 = dots[6];
            Dot d7 = dots[7];
            Dot d8 = dots[8];
            Dot d9 = dots[9];
            Dot d10 = dots[10];
            Dot d11 = dots[11];

            Edge e1 = new Edge(d7, d0);
            Edge e2 = new Edge(d7, d4);
            Edge e3 = new Edge(d7, d3);
            Edge e4 = new Edge(d7, d10);
            Edge e5 = new Edge(d7, d9);
            Edge e6 = new Edge(d5, d8);
            Edge e7 = new Edge(d5, d11);
            Edge e8 = new Edge(d5, d2);
            Edge e9 = new Edge(d5, d6);
            Edge e10 = new Edge(d5, d1);
            Edge e11 = new Edge(d0, d8);
            Edge e12 = new Edge(d0, d4);
            Edge e13 = new Edge(d8, d4);
            Edge e14 = new Edge(d8, d11);
            Edge e15 = new Edge(d4, d11);
            Edge e16 = new Edge(d4, d3);
            Edge e17 = new Edge(d11, d3);
            Edge e18 = new Edge(d11, d2);
            Edge e19 = new Edge(d3, d2);
            Edge e20 = new Edge(d3, d10);
            Edge e21 = new Edge(d2, d10);
            Edge e22 = new Edge(d2, d6);
            Edge e23 = new Edge(d10, d6);
            Edge e24 = new Edge(d10, d9);
            Edge e25 = new Edge(d6, d9);
            Edge e26 = new Edge(d6, d1);
            Edge e27 = new Edge(d9, d1);
            Edge e28 = new Edge(d9, d0);
            Edge e29 = new Edge(d1, d0);
            Edge e30 = new Edge(d1, d8);

            Polygon p1 = new Polygon(new List<Edge> { e1, e2, e12 });
            Polygon p2 = new Polygon(new List<Edge> { e1, e28, e5 });
            Polygon p3 = new Polygon(new List<Edge> { e2, e3, e16 });
            Polygon p4 = new Polygon(new List<Edge> { e3, e4, e20 });
            Polygon p5 = new Polygon(new List<Edge> { e4, e5, e24 });
            Polygon p6 = new Polygon(new List<Edge> { e6, e14, e7 });
            Polygon p7 = new Polygon(new List<Edge> { e6, e10, e30 });
            Polygon p8 = new Polygon(new List<Edge> { e7, e8, e18 });
            Polygon p9 = new Polygon(new List<Edge> { e8, e9, e22 });
            Polygon p10 = new Polygon(new List<Edge> { e9, e10, e26 });
            Polygon p11 = new Polygon(new List<Edge> { e11, e12, e13 });
            Polygon p12 = new Polygon(new List<Edge> { e11, e29, e30 });
            Polygon p13 = new Polygon(new List<Edge> { e13, e14, e15 });
            Polygon p14 = new Polygon(new List<Edge> { e15, e16, e17 });
            Polygon p15 = new Polygon(new List<Edge> { e17, e18, e19 });
            Polygon p16 = new Polygon(new List<Edge> { e19, e20, e21 });
            Polygon p17 = new Polygon(new List<Edge> { e21, e22, e23 });
            Polygon p18 = new Polygon(new List<Edge> { e23, e24, e25 });
            Polygon p19 = new Polygon(new List<Edge> { e25, e26, e27 });
            Polygon p20 = new Polygon(new List<Edge> { e27, e28, e29 });
            return new List<Polygon> { p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13, p14, p15, p16, p17, p18, p19, p20 };
        }
    }
}
