using cg_lab89.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cg_lab89.Figures
{
    class Dodecahedron
    {
        public Polyhedron shape;
        public Dodecahedron()
        {
            /*
             */
            float phi = 1.6180f ;
            Dot d0 = new Dot(100, 100, 100, FigureType.Dodecahedron);
            Dot d1 = new Dot(100, 100, -100, FigureType.Dodecahedron);
            Dot d2 = new Dot(100, -100, 100, FigureType.Dodecahedron);
            Dot d3 = new Dot(100, -100, -100, FigureType.Dodecahedron);
            Dot d4 = new Dot(-100, 100, 100, FigureType.Dodecahedron);
            Dot d5 = new Dot(-100, 100, -100, FigureType.Dodecahedron);
            Dot d6 = new Dot(-100, -100, 100, FigureType.Dodecahedron);
            Dot d7 = new Dot(-100, -100, -100, FigureType.Dodecahedron);
            Dot d8 = new Dot(0, 1 * 100 / phi, phi * 100, FigureType.Dodecahedron);
            Dot d9 = new Dot(0, 1 * 100 / phi, -phi * 100, FigureType.Dodecahedron);
            Dot d10 = new Dot(0, -1 * 100 / phi, phi * 100, FigureType.Dodecahedron);
            Dot d11 = new Dot(0, -1 * 100 / phi, -phi * 100, FigureType.Dodecahedron);
            Dot d12 = new Dot(1 * 100 / phi, phi * 100, 0, FigureType.Dodecahedron);
            Dot d13 = new Dot(1 * 100 / phi, -phi * 100, 0, FigureType.Dodecahedron);
            Dot d14 = new Dot(-1 * 100 / phi, phi * 100, 0, FigureType.Dodecahedron);
            Dot d15 = new Dot(-1 * 100 / phi, -phi * 100, 0, FigureType.Dodecahedron);
            Dot d16 = new Dot(phi * 100, 0, 1 * 100 / phi, FigureType.Dodecahedron);
            Dot d17 = new Dot(phi * 100, 0, -1 * 100 / phi, FigureType.Dodecahedron);
            Dot d18 = new Dot(-phi * 100, 0, 1 * 100 / phi, FigureType.Dodecahedron);
            Dot d19 = new Dot(-phi * 100, 0, -1 * 100 / phi, FigureType.Dodecahedron);

            /*
             {8,10},
            {8,0},
            {8,4},
            {10,2},
            {10,6},
            {9,11},
            {9,1},
            {9,5},
            {11,3},
            {11,7},
            */
            Edge e1 = new Edge(d8, d10);
            Edge e2 = new Edge(d8, d0);
            Edge e3 = new Edge(d8, d4);
            Edge e4 = new Edge(d10, d2);
            Edge e5 = new Edge(d10, d6);
            Edge e6 = new Edge(d9, d11);
            Edge e7 = new Edge(d9, d1);
            Edge e8 = new Edge(d9, d5);
            Edge e9 = new Edge(d11, d3);
            Edge e10 = new Edge(d11, d7);
            /*
            {12,14},
            {13,15},
            {12,0},
            {12,1},
            {14,4},
            {14,5},
            {13,2},
            {13,3},
            {15,6},
            {15,7},
            */
            Edge e11 = new Edge(d12, d14);
            Edge e12 = new Edge(d13, d15);
            Edge e13 = new Edge(d12, d0);
            Edge e14 = new Edge(d12, d1);
            Edge e15 = new Edge(d14, d4);
            Edge e16 = new Edge(d14, d5);
            Edge e17 = new Edge(d13, d2);
            Edge e18 = new Edge(d13, d3);
            Edge e19 = new Edge(d15, d6);
            Edge e20 = new Edge(d15, d7);
            /*
            {16,17},
            {18,19},
            {16,0},
            {16,2},
            {17,1},
            {17,3},
            {18,4},
            {18,6},
            {19,5},
            {19,7}
             */
            Edge e21 = new Edge(d16, d17);
            Edge e22 = new Edge(d18, d19);
            Edge e23 = new Edge(d16, d0);
            Edge e24 = new Edge(d16, d2);
            Edge e25 = new Edge(d17, d1);
            Edge e26 = new Edge(d17, d3);
            Edge e27 = new Edge(d18, d4);
            Edge e28 = new Edge(d18, d6);
            Edge e29 = new Edge(d19, d5);
            Edge e30 = new Edge(d19, d7);

            /*
             0 - 
             */

            Polygon p1 = new Polygon(new List<Edge> { e13, e14, e25, e21, e23 });
            Polygon p2 = new Polygon(new List<Edge> { e2, e1, e4, e24, e23 });
            Polygon p3 = new Polygon(new List<Edge> { e2, e3, e15, e11, e13 });
            Polygon p4 = new Polygon(new List<Edge> { e18, e17, e24, e21, e26 });
            Polygon p5 = new Polygon(new List<Edge> { e17, e12, e19, e5, e4 });
            Polygon p6 = new Polygon(new List<Edge> { e1, e5, e28, e27, e3 });
            Polygon p7 = new Polygon(new List<Edge> { e29, e22, e27, e15, e16 });
            Polygon p8 = new Polygon(new List<Edge> { e8, e7, e14, e11, e16 });
            Polygon p9 = new Polygon(new List<Edge> { e6, e9, e26, e21, e7 });
            Polygon p10 = new Polygon(new List<Edge> { e9, e10, e20, e12, e18 });
            Polygon p11 = new Polygon(new List<Edge> { e22, e28, e19, e20, e30 });
            Polygon p12 = new Polygon(new List<Edge> { e5, e4, e17, e12, e19 }); ;

            shape = new Polyhedron(new List<Polygon> { p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12});
            shape.dots = new List<Dot> { d0, d1, d2, d3, d4, d5, d6, d7, d8, d9, d10, d11, d12, d13, d14, d15, d16, d17, d18, d19 };
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
            Dot d12 = dots[12];
            Dot d13 = dots[13];
            Dot d14 = dots[14];
            Dot d15 = dots[15];
            Dot d16 = dots[16];
            Dot d17 = dots[17];
            Dot d18 = dots[18];
            Dot d19 = dots[19];

            Edge e1 = new Edge(d8, d10); // 8 10
            Edge e2 = new Edge(d8, d0); // 8 0
            Edge e3 = new Edge(d8, d4); // 8 4
            Edge e4 = new Edge(d10, d2); // 10 2
            Edge e5 = new Edge(d10, d6); // 10 6
            Edge e6 = new Edge(d9, d11); // 9 11
            Edge e7 = new Edge(d9, d1); // 9 1
            Edge e8 = new Edge(d9, d5); // 9 5
            Edge e9 = new Edge(d11, d3); // 11 3
            Edge e10 = new Edge(d11, d7); // 11 7
            /*
            {12,14},
            {13,15},
            {12,0},
            {12,1},
            {14,4},
            {14,5},
            {13,2},
            {13,3},
            {15,6},
            {15,7},
            */
            Edge e11 = new Edge(d12, d14); // 12 14
            Edge e12 = new Edge(d13, d15); // 13 15
            Edge e13 = new Edge(d12, d0); // 12 0
            Edge e14 = new Edge(d12, d1); // 12 1
            Edge e15 = new Edge(d14, d4); // 14 4
            Edge e16 = new Edge(d14, d5); // 14 5
            Edge e17 = new Edge(d13, d2); // 13 2
            Edge e18 = new Edge(d13, d3); // 13 3
            Edge e19 = new Edge(d15, d6); // 15 6
            Edge e20 = new Edge(d15, d7); // 15 7
            /*
            {16,17},
            {18,19},
            {16,0},
            {16,2},
            {17,1},
            {17,3},
            {18,4},
            {18,6},
            {19,5},
            {19,7}
             */
            Edge e21 = new Edge(d16, d17); // 16 17
            Edge e22 = new Edge(d18, d19); // 18 19
            Edge e23 = new Edge(d16, d0); // 16 0
            Edge e24 = new Edge(d16, d2); // 16 2
            Edge e25 = new Edge(d17, d1); // 17 1
            Edge e26 = new Edge(d17, d3); // 17 3
            Edge e27 = new Edge(d18, d4); // 18 4
            Edge e28 = new Edge(d18, d6); // 18 6
            Edge e29 = new Edge(d19, d5); // 19 5
            Edge e30 = new Edge(d19, d7); // 19 7
            Polygon p1 = new Polygon(new List<Edge> { e13, e14, e25, e21, e23 });
            Polygon p2 = new Polygon(new List<Edge> { e2,  e1,  e4,  e24, e23 });
            Polygon p3 = new Polygon(new List<Edge> { e2,  e3,  e15, e11, e13 });
            Polygon p4 = new Polygon(new List<Edge> { e18, e17, e24, e21, e26 });
            Polygon p5 = new Polygon(new List<Edge> { e17, e12, e19, e5, e4});
            Polygon p6 = new Polygon(new List<Edge> { e1, e5, e28, e27, e3 });
            Polygon p7 = new Polygon(new List<Edge> { e29, e22, e27, e15, e16 });
            Polygon p8 = new Polygon(new List<Edge> { e8, e7, e14, e11, e16});
            Polygon p9 = new Polygon(new List<Edge> { e6, e9, e26, e21, e7});
            Polygon p10 = new Polygon(new List<Edge> { e9, e10, e20, e12, e18});
            Polygon p11 = new Polygon(new List<Edge> { e22, e28, e19, e20, e30});
            Polygon p12 = new Polygon(new List<Edge> { e5, e4, e17, e12, e19});

            return new List<Polygon> { p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12 };

        }
    }
}
