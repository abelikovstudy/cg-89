using cg_lab89.MathUtils;
using cg_lab89.Primitives;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cg_lab89.Render
{
    public enum CameraOps { RotateX, RotateY, Zoom }
    public class Camera
    {
        public Dot position;
        public VectorUtils direction;
        public VectorUtils verticalOffset;
        public VectorUtils horisontalOffset;
        public MatrixUtils test;
        const double cameraRotationSpeed = 0.1;
        private double yaw = 0.0, pitch = 0.0;
        public float fov { get; set; }
        public float near { get; set; }
        public float far { get; set; }
        public float f { get; set; }
        public float rangeInv; 
        public MatrixUtils cameraProjectionMatrix;
        public static double rads(float x) => AffineTransformations.radians(x);
        public Camera(float _fov)
        {
            fov = _fov;
            near = 1.0f;
            far = 200.0f;
            f = (float)Math.Tan(Math.PI * 0.5 - 0.5 * AffineTransformations.radians(fov));
            rangeInv = 1.0f / (near - far);
            cameraProjectionMatrix = new MatrixUtils(4, 4,
                              f, 0, 0, 0,
                              0, f, 0, 0,
                              0, 0, (near + far) * rangeInv, -1,
                              0, 0, near * far * rangeInv * 2, 0
            );

            position = new Dot(0, 0, 0);
            direction = new VectorUtils(1, 0, 0);
            verticalOffset = new VectorUtils(0, 0, 1);
            horisontalOffset = (direction * verticalOffset).normalize();

        }

        public void updateCamera(float fov, float far) 
        {
            rangeInv = 1.0f / (near - far);
            f = (float)Math.Tan(Math.PI * 0.5 - 0.5 * AffineTransformations.radians(fov)); 
            cameraProjectionMatrix = new MatrixUtils(4, 4,
                              f, 0, 0, 0,
                              0, f, 0, 0,
                              0, 0, (near + far) * rangeInv, -1,
                              0, 0, near * far * rangeInv * 2, 0
            );
        }

        public void move(VectorUtils offset)
        {
            position.x += (float)(offset.x * horisontalOffset.x + offset.y * direction.x + offset.z * verticalOffset.x);
            position.y += (float)(offset.x * horisontalOffset.y + offset.y * direction.y + offset.z * verticalOffset.y);
            position.z += (float)(offset.x * horisontalOffset.z + offset.y * direction.z + offset.z * verticalOffset.z);
        }

        public void rotate(VectorUtils offset)
        {
            var newPitch = Math.Clamp(pitch + offset.y * cameraRotationSpeed, -89.0, 89.0);
            var newYaw = (yaw + offset.x) % 360;
            if (newPitch != pitch)
            {
                AffineTransformations.rotateVectors(ref direction, ref verticalOffset, (newPitch - pitch), horisontalOffset);
                pitch = newPitch;
            }
            if (newYaw != yaw)
            {
                AffineTransformations.rotateVectors(ref direction, ref horisontalOffset, (newYaw - yaw), verticalOffset);
                yaw = newYaw;
            }
        }
        public Dot toCameraView(Dot p)
        {
            return new Dot((float)(horisontalOffset.x * (p.x - position.x) + horisontalOffset.y * (p.y - position.y) + horisontalOffset.z * (p.z - position.z)),
                             (float)(verticalOffset.x * (p.x - position.x) + verticalOffset.y * (p.y - position.y) + verticalOffset.z * (p.z - position.z)),
                             (float)(direction.x * (p.x - position.x) + direction.y * (p.y - position.y) + direction.z * (p.z - position.z)));
        }

        public PointF? getProjection(Dot p)
        {
            Dot c = new Dot((float)(horisontalOffset.x * (p.x - position.x) + horisontalOffset.y * (p.y - position.y) + horisontalOffset.z * (p.z - position.z)),
                             (float)(verticalOffset.x * (p.x - position.x) + verticalOffset.y * (p.y - position.y) + verticalOffset.z * (p.z - position.z)),
                             (float)(direction.x * (p.x - position.x) + direction.y * (p.y - position.y) + direction.z * (p.z - position.z)));
            if (c.z < 0)
            {
                return null;
            }
            MatrixUtils m1 = cameraProjectionMatrix;
            MatrixUtils m2 = new MatrixUtils(4, 1, c.x, c.y, c.z, 1.0);
            MatrixUtils res = (m1 * m2);
            if (res.matrix[3, 0] == 0)
            {
                return null;
            }
            test = res;
            res.matrix[0, 0] /= (float)res.matrix[3, 0];
            res.matrix[1, 0] /= (float)res.matrix[3, 0];
            res.matrix[0, 0] = Math.Clamp(res.matrix[0, 0], -1, 1);
            res.matrix[1, 0] = Math.Clamp(res.matrix[1, 0], -1, 1);

            return new PointF(Constants.WORLD_X + (float)(res.matrix[0, 0]) * Constants.WORLD_X, Constants.WORLD_Y + (float)(res.matrix[1, 0]) * Constants.WORLD_X);
        }
    }
}
