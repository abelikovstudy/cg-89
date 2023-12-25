using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.AxHost;
using System.Xml.Linq;
using cg_lab89.MathUtils;
using System.Diagnostics;
using static cg_lab89.Constants;

namespace cg_lab89.Primitives
{
    public enum FigureType { Tetrahedron, Octahedron, Hexahedron, Icosahedron, Dodecahedron, RotationFigure, Plot}
    public enum ProjectionType { Central, Isometric, Camera }
    public class Dot
    {
        public FigureType type;
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
        public Texel tex;
        public float lightness;
        public VectorUtils norm;
        public Dot(float _x, float _y, float _z, FigureType ft = FigureType.Tetrahedron, float _lightness = 0.5f)
        {
            x = _x;
            y = _y;
            z = _z;
            type = ft;
            lightness = _lightness; 
        }
        public override string ToString()
        {
            
            return string.Concat($"{(int)x} {(int)y} {(int)z}");
        }

        public PointF getProjection(ProjectionType projection) 
        {

            if (projection == ProjectionType.Central)
            {

                MatrixUtils m1 = new MatrixUtils(4, 4,
                    1, 0, 0, 0,
                    0, 1, 0, 0,
                    0, 0, 0.0008, 1,
                    0, 0, 0, 1);
                MatrixUtils m2 = new MatrixUtils(4, 1, x, -y, z, 1.0);
                MatrixUtils res = (m1 * m2);
                return new PointF(Constants.WORLD_X + (float)((float)res.matrix[0, 0] / (float)res.matrix[2, 0]), Constants.WORLD_Y + (float)((float)res.matrix[1, 0] / (float)res.matrix[2, 0]));
            }
            else if (projection == ProjectionType.Camera) 
            {
                MatrixUtils m1 = new MatrixUtils(4, 4,
                    1, 0, 0, 0,
                    0, 1, 0, 0,
                    0, 0, 0.0008, 1,
                    0, 0, 0, 1);
                MatrixUtils m2 = new MatrixUtils(4, 1, x, -y, z, 1.0);
                MatrixUtils res = (m1 * Constants.cameraMatrix * m2);
                CameraCoordTest = new Dot((float)res.matrix[0, 0], (float)res.matrix[2, 0], (float)res.matrix[1, 0]);
                return new PointF(Constants.WORLD_X + (float)((float)res.matrix[0, 0] / (float)res.matrix[2, 0]), Constants.WORLD_Y + (float)((float)res.matrix[1, 0] / (float)res.matrix[2, 0]));

            }
            else
            {
                double sqrt3 = Math.Sqrt(3);
                double sqrt2 = Math.Sqrt(2);
                double sqrt6 = Math.Sqrt(6);
                MatrixUtils m1 = new MatrixUtils(3, 3,
                    sqrt3, 0, -sqrt3,
                    1, 2, 1,
                    sqrt2, -sqrt2, sqrt2);
                MatrixUtils m2 = new MatrixUtils(3, 1, x, -y, z); //y z x
                MatrixUtils m3 = new MatrixUtils(3, 3, 1, 0, 0, 0, 1, 0, 0, 0, 0);
                MatrixUtils res = m3 * (m1 * m2);
                return new PointF(Constants.WORLD_X + (float)(res.matrix[0, 0] / sqrt6), Constants.WORLD_Y + (float)(res.matrix[1, 0] / sqrt6));
            }
        }

    }
}
