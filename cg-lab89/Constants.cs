using cg_lab89.MathUtils;
using cg_lab89.Primitives;
using cg_lab89.Render;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cg_lab89
{

    public static class Constants
    {
        public enum Axis { X, Y, Z }
        public static float WORLD_X { get; set; }
        public static float WORLD_Y { get; set; }
        public static Dot CameraPosition { get; set; }
        public static Dot CameraOffset { get; set; }
        public static Dot CameraCoordTest { get; set; }
        public static MatrixUtils cameraMatrix { get; set; }
    }
}
