using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cg_lab89.Primitives
{
    public class Edge
    {
        public Dot start { get; set; }
        public Dot end { get; set; }
        public Edge(Dot _start, Dot _end) 
        {
            start = _start;
            end = _end;
        }

        public static List<Edge> connectDots(List<Dot> dots) 
        {
            List<Edge> edges = new List<Edge>();
            for(int i = 0; i < dots.Count - 1; i++) 
            {
                edges.Add(new Edge(dots[i], dots[i + 1]));
            }
            edges.Add(new Edge(dots.First(), dots.Last()));
            return edges;
        }

        public static List<Edge> connectDotsExcplicitly(List<Dot> dots)
        {
            List<Edge> edges = new List<Edge>();
            for (int i = 0; i < dots.Count - 1; i++)
            {
                edges.Add(new Edge(dots[i], dots[i + 1]));
            }
            return edges;
        }

        public override string ToString()
        {
            return string.Concat($"{start} <-> {end}");
        }
    }
}
