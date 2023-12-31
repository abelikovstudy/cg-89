﻿using cg_lab89.MathUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace cg_lab89.Primitives
{
    public class Polygon
    {
        public List<Edge> edges { get; set; }
        public List<Dot> Dots { get; set; }
        public Polygon(List<Edge> _edges)
        {
            edges = _edges;
            Dots = new List<Dot>();
            foreach (Edge edge in edges)
            {
                Dots.Add(edge.start);
                Dots.Add(edge.end);
            }
            Dots = Dots.Distinct().ToList();
        }
        public Polygon(List<Edge> _edges, List<Dot> _Dots)
        {
            edges = _edges;
            Dots = _Dots;
        }
        public Dot getCenter()
        {
            float x = 0, y = 0, z = 0;
            foreach (Dot d in Dots)
            {
                x += d.x;
                y += d.y;
                z += d.z;
            }
            return new Dot(x / Dots.Count, y / Dots.Count, z / Dots.Count);
        }

        public VectorUtils normalise() 
        {
            Dot a = edges[2].start;
            Dot b = edges[1].start;
            Dot c = edges[0].start;
            VectorUtils v1 = new VectorUtils(b.x - a.x, b.y - a.y, b.z - a.z);
            VectorUtils v2 = new VectorUtils(c.x - a.x, c.y - a.y, c.z - a.z);
            VectorUtils res = (v1 * v2);
            return res;
        }
    }
}
