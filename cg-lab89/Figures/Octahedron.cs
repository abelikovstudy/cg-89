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
            Dot a = new Dot(50, 100, 50, FigureType.Octahedron);
            Dot b = new Dot(0, 0, 0, FigureType.Octahedron);
            Dot e = new Dot(100, 0, 0, FigureType.Octahedron);
            Dot d = new Dot(100, 0, 100, FigureType.Octahedron);
            Dot c = new Dot(0, 0, 100, FigureType.Octahedron);
            Dot f = new Dot(50, -100, 50, FigureType.Octahedron);
            Edge ab = new Edge(a, b);
            Edge ae = new Edge(a, e);
            Edge ad = new Edge(a, d);
            Edge ac = new Edge(a, c);

            Edge bc = new Edge(b, c);
            Edge cd = new Edge(c, d);
            Edge de = new Edge(d, e);
            Edge eb = new Edge(e, b);

            Edge bf = new Edge(f, b);
            Edge ef = new Edge(f, e);
            Edge df = new Edge(f, d);
            Edge cf = new Edge(f, c);

            Polygon abc = new Polygon(new List<Edge> { ab, bc, ac });
            Polygon acd = new Polygon(new List<Edge> { ac, cd, ad });
            Polygon aed = new Polygon(new List<Edge> { ae, de, ad });
            Polygon abe = new Polygon(new List<Edge> { ab, eb, ae });


            Polygon bfc = new Polygon(new List<Edge> { bc, cf, bf });
            Polygon cfd = new Polygon(new List<Edge> { cf, df, cd });
            Polygon efd = new Polygon(new List<Edge> { df, ef, de });
            Polygon bfe = new Polygon(new List<Edge> { ef, bf, eb });
            shape = new Polyhedron(new List<Polygon> {abc, acd, aed, abe, bfc, cfd, efd, bfe});
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
            Edge ae = new Edge(a, e);
            Edge ad = new Edge(a, d);
            Edge ac = new Edge(a, c);

            Edge bc = new Edge(b, c);
            Edge cd = new Edge(c, d);
            Edge de = new Edge(d, e);
            Edge eb = new Edge(e, b);

            Edge bf = new Edge(f, b);
            Edge ef = new Edge(f, e);
            Edge df = new Edge(f, d);
            Edge cf = new Edge(f, c);

            Polygon abc = new Polygon(new List<Edge> { ab, bc, ac });
            Polygon acd = new Polygon(new List<Edge> { ac, cd, ad });
            Polygon aed = new Polygon(new List<Edge> { ae, de, ad });
            Polygon abe = new Polygon(new List<Edge> { ab, eb, ae });


            Polygon bfc = new Polygon(new List<Edge> { bc, cf, bf });
            Polygon cfd = new Polygon(new List<Edge> { cf, df, cd });
            Polygon efd = new Polygon(new List<Edge> { df, ef, de });
            Polygon bfe = new Polygon(new List<Edge> { ef, bf, eb });
            return new List<Polygon> { abc, acd, aed, abe, bfc, cfd, efd, bfe };
        }
    }
}
