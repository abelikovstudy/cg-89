using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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


    }
}
