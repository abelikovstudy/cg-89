using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using cg_lab89.MathUtils;
using cg_lab89.Primitives;
namespace cg_lab89.Render
{
    public class Light
    {
        Dot position;

        public Light(Dot position)
        {
            this.position = position;
        }

        public Dot Position => position;

        public void move(float shiftX = 0, float shiftY = 0, float shiftZ = 0)
        {
            position.x += shiftX;
            position.y += shiftY;
            position.z += shiftZ;
        }
        public static double GetCos(VectorUtils v1, VectorUtils v2)
        {
            double scalar = v1.x * v2.x + v1.y * v2.y + v1.z * v2.z;
            double lengthv1 = Math.Sqrt(v1.x * v1.x + v1.y * v1.y + v1.z * v1.z);
            double lengthv2 = Math.Sqrt(v2.x * v2.x + v2.y * v2.y + v2.z * v2.z);
            double res = scalar / lengthv1 / lengthv2;
            return res;

        }
        public static double GetLightness(Dot v, Light light)
        {
            var normv = new VectorUtils(v).normalize();

            var raytovertex = new VectorUtils(v.x - light.Position.x, v.y - light.Position.y, v.z - light.Position.z);
            //cos α = a·b/
            //|a |·| b |
            double cos = GetCos(normv, raytovertex);
            if (double.IsNaN(cos)) cos = 1;
            //добавить max(cos,0)
            return cos;
        }

        public static double GetIntense(double lightness)
        {
            return (lightness + 1) / 2;//у Яны в презентации (1+cos)/2
            //return lightness*0.3*0.7;//что-то интуитивные коэффициенты не помогают

        }
        public static VectorUtils NormalVertex(List<Polygon> faces, Polyhedron s)
        {
            VectorUtils res = new VectorUtils(0, 0, 0);
            foreach (var face in faces)
            {
                res.x += face.normalise().x;
                res.y += face.normalise().y;
                res.z += face.normalise().z;
            }
            res.x = res.x / faces.Count();
            res.y = res.y / faces.Count();
            res.z = res.z / faces.Count();
            return res;
        }
        public static void CalculateLambert(ref Polyhedron s, Light light)
        {
            Dictionary<Dot, VectorUtils> normales = new Dictionary<Dot, VectorUtils>();
            for (int i = 0; i < s.polys.Count; i++)
            {
                Polygon f = s.polys[i];
                foreach (var vert in f.Dots)
                {
                    List<Polygon> faces = s.polys.Where(x => x.Dots.Contains(vert)).ToList();//все грани, содержащие данную вершину
                    vert.norm = NormalVertex(faces, s);
                }

            }

            foreach (var f in s.polys)
            {
                //посчитать яркость в каждой вершине многоугольника
                foreach (var vert in f.Dots)
                {
                    double lamb = GetLightness(vert, light);

                    double intense = GetIntense(lamb);
                    vert.lightness = (float)intense;
                }
            }
        }

    }
}
