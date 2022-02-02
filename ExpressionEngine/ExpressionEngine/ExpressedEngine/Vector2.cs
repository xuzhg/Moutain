using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressedEngine.ExpressedEngine
{
    public class Vector2
    {

        public float X { get; set; }

        public float Y { get; set; }

        public Vector2()
            : this(0.0f, 0.0f)
        {
        }

        public Vector2(float x, float y)
        {
            X = x;
            Y = y;
        }

        public static Vector2 Zero()
        {
            return new Vector2(0, 0);
        }
    }
}
