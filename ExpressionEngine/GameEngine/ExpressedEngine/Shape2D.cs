using GameEngine.ExpressiondEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.ExpressiondEngine
{
    public class Shape2D
    {
        public Vector2 Position = null;
        public Vector2 Scale = null;
        public string Tag;

        public Shape2D(Vector2 position, Vector2 scale, string tag)
        {
            this.Position = position;
            this.Scale = scale;
            this.Tag = tag;

            Log.Info($"[Shape2D] {Tag} - has been registered!");

            ExpressedEngine.RegisterShape(this);
        }

        public void DestroySelf()
        {
            Log.Info($"[Shape2D] {Tag} - has been destoryed!");
            ExpressedEngine.UnRegisterShape(this);
        }
    }
}
