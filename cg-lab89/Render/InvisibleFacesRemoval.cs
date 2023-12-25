using cg_lab89.MathUtils;
using cg_lab89.Primitives;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
namespace cg_lab89.Render
{
    class InvisibleFacesRemoval
    {
        public static List<Polygon> Remove(ref Camera cam, Polyhedron p)
        {
            
            List<Polygon> polygons = new List<Polygon>();
            foreach (Polygon poly in p.polys)
            {
                VectorUtils vectProec = new VectorUtils(cam.toCameraView(poly.getCenter()));
                vectProec = vectProec.normalize();
                VectorUtils vect1 = new VectorUtils(new Dot(poly.edges.First().end.x - poly.edges.First().start.x, poly.edges.First().end.y - poly.edges.First().start.y, poly.edges.First().end.z - poly.edges.First().start.z));
                VectorUtils vect2 = new VectorUtils(new Dot(poly.edges.Last().start.x - poly.edges.Last().end.x, poly.edges.Last().start.y - poly.edges.Last().end.y, poly.edges.Last().start.z - poly.edges.Last().end.z));
                VectorUtils vectNormal = vect1 * vect2;
                Dot d3 = cam.toCameraView(new Dot((float)vectNormal.x, (float)vectNormal.y, (float)vectNormal.z));
                vectNormal = new VectorUtils(d3).normalize();
                if (vectNormal.x * vectProec.x + vectNormal.y * vectProec.y + vectNormal.z * vectProec.z > 0)
                    polygons.Add(poly);

            }
            return polygons;
        } 

        public static List<Polygon> RemoveUpd(ref Camera cam, Polyhedron p) 
        {

            List<Polygon> polygons = new List<Polygon>();
            foreach (Polygon poly in p.polys)
            {
                Dot d = new Dot(cam.position.x, -cam.position.y, -cam.position.z);
                VectorUtils vectProec = new VectorUtils(d).normalize();
                VectorUtils vectNormal = poly.normalise().normalize();
                double angle = vectNormal.x * vectProec.x + vectNormal.y * vectProec.y + vectNormal.z * vectProec.z;
                Debug.WriteLine(angle);
                if (angle <= 0)
                    polygons.Add(poly);

            }
            return polygons;
        }
    }

}
