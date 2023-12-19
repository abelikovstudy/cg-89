using cg_lab89.Figures;
using cg_lab89.MathUtils;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cg_lab89.Primitives
{
    public class Polyhedron
    {
        public float PlotX1 { get; set; }
        public float PlotX2 { get; set; }
        public float PlotY1 { get; set; }
        public float PlotY2 { get; set; }

        public List<Dot> RotationFigureDots { get; set; }
        public int RotationFigureBreaks { get; set; }
        public int RotationFigureInitDots { get; set; }
        public Dot[,] PlotMatrix { get; set; }
        public int PlotStep { get; set; }

        public Constants.Axis ax { get ; set; }
        public List<Polygon> polys { get; set; }
        public List<Dot> dots { get; set; }
        public Polyhedron(List<Polygon> _polys)
        {
            polys = _polys;
        }
        public FigureType type { get; set; }
        public void transform() 
        {

            switch (type) 
            {

                case FigureType.Tetrahedron:
                    polys = Tetrahedron.getPolys(dots);
                    break;
                case FigureType.Octahedron:
                    polys = Octahedron.getPolys(dots);
                    break;
                case FigureType.Hexahedron:
                    polys = Hexahedron.getPolys(dots);
                    break;
                case FigureType.Icosahedron:
                    polys = Icosahedron.getPolys(dots);
                    break;
                case FigureType.Dodecahedron:
                    polys = Dodecahedron.getPolys(dots);
                    break;
                default:    
                    throw new InvalidOperationException("Несоответствующее число точек!");
            }
        }

        public void updatePolygons()
        {
            int count = 0;
            foreach (Polygon pp in polys)
            {
                foreach (Edge e in pp.edges) count += 1;
            }

            Debug.WriteLine($"Граней в методе: {count}");
            Debug.WriteLine($"Полигонов в методе:{polys.Count}");
            Debug.WriteLine($"Точек в методе:{dots.Count}");
            int i = 0;
            foreach (Polygon p in polys) 
            {
                foreach (Edge e in p.edges) 
                {
                    e.start = dots[i + 1];
                    e.end = dots[i];
                    if (i < dots.Count - 3) i += 2;
                }
            }

            Debug.WriteLine(i);
            Debug.WriteLine(dots.Count);
        }

        public Dot getCenter() 
        {
            float x = 0f, y = 0f, z = 0f;
            foreach (Polygon p in polys)
            {
                x += p.getCenter().x;
                y += p.getCenter().y;
                z += p.getCenter().z;
            }

            return new Dot(x / polys.Count, y / polys.Count, z / polys.Count);
        }


        public void addEdge(Polygon poly)
        {
            polys.Add(poly);
        }

        public List<Triangle> triangulate(ProjectionType projection, ref Graphics gr)
        {
            List<Triangle> triangles = new List<Triangle>();
            foreach (Polygon p in polys)
            {
                foreach (Edge e in p.edges)
                {
                    triangles.Add(new Triangle(e.start.getProjection(projection), p.getCenter().getProjection(projection), e.end.getProjection(projection)));
                }
            }
            return triangles;
        }

    }


}
