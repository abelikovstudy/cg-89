using cg_lab89.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cg_lab89.MathUtils
{
    public static class PlotFunctions
    {

    }

    public class PlotFunction 
    {
        public string label { get; set; }
        public PlotFunction(string _label) 
        {
            label = _label;
        }

        public float f(float x, float y) => (float)(50*Math.Sin(x) + Math.Sin(y));

        public List<Dot> calculate(float x1, float x2, float y1, float y2, int step) 
        {
            List<Dot> result = new List<Dot>();
            for (float i = x1; i < x2; i += step) 
            {
                for (float j = y1; j < y2; j += step) 
                {
                    result.Add(new Dot(i,j,f(i, j)));
                }
            }
            return result;
        }
    }
}
