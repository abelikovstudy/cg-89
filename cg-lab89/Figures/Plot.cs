using cg_lab89.MathUtils;
using cg_lab89.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cg_lab89.Figures
{
    public class Plot
    {
        public Polyhedron shape;

        public float x1 { get; set; }
        public float x2 { get; set; }
        public float y1 { get; set; }
        public float y2 { get; set; }

        public Dot[,] dotsMatrix { get; set; }

        public Plot(float _x1, float _x2, float _y1, float _y2, int step, PlotFunction pf)
        {
            x1 = _x1;
            x2 = _x2;
            y1 = _y1;
            y2 = _y2;
            List<Dot> dots = new List<Dot>();
            List<Polygon> polygons = new List<Polygon>();
            dotsMatrix = new Dot[((int)(x2 - x1) / step) + 1, ((int)(y2 - y1) / step) + 1];

            for (float i = x1; i < x2; i += step)
            {
                List<Dot> lineDots = new List<Dot>();
                for (float j = y1; j < y2; j += step)
                {

                    dotsMatrix[(int)(x2 - i) / step, (int)(y2 - j) / step] = new Dot(i, pf.f(i, j), j);
                    dots.Add(new Dot(i, pf.f(i, j), j));
                    lineDots.Add(new Dot(i, pf.f(i, j), j));
                }
                polygons.Add(new Polygon(Edge.connectDotsExcplicitly(lineDots)));
            }
            for (float j = y1; j < y2; j += step)
            {
                List<Dot> lineDots = new List<Dot>();
                for (float i = x1; i < x2; i += step)
                {
                    lineDots.Add(new Dot(i, pf.f(i, j), j));
                }
                polygons.Add(new Polygon(Edge.connectDotsExcplicitly(lineDots)));
            }
            foreach (Dot dot in dots) dot.type = FigureType.Plot;
            shape = new Polyhedron(polygons);
            shape.dots = dots;
        }

        public static List<Polygon> getPolys(List<Dot> _dots, float x1, float x2, float y1, float y2, int step, Dot[,] matr)
        {
            List<Polygon> polygons = new List<Polygon>();
            int z = 0;
            int countDots = 0;
            for (int i = 0; i < (x2 - x1) / step; ++i)
            {
                List<Dot> lineDots = new List<Dot>();
                for (int j = 0; j < (y2 - y1) / step; ++j)
                {
                    lineDots.Add(_dots[z]);
                    z += 1;
                }
                countDots = lineDots.Count;
                polygons.Add(new Polygon(Edge.connectDots(lineDots), lineDots));
            }

            for (int j = 0; j < countDots; j++)
            {
                List<Dot> crossDots = new List<Dot>();
                for (int i = 0; i < (x2 - x1) / step; ++i)
                {
                    crossDots.Add(polygons[i].Dots[j]);
                }
                polygons.Add(new Polygon(Edge.connectDotsExcplicitly(crossDots)));
            }
            return polygons;

        }

    }
}
