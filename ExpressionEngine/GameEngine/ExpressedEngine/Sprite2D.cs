using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
namespace GameEngine.ExpressiondEngine
{
    public class Sprite2D
    {
        public Vector2 Position = null;
        public Vector2 Scale = null;
        public string Directory;
        public string Tag;
        public Image Sprite;
        public Sprite2D(Vector2 position, Vector2 scale, string directory, string tag)
        {
            this.Position = position;
            this.Scale = scale;
            this.Directory = directory;
            this.Tag = tag;

            Log.Info($"[Sprite2D] {Tag} - has been registered!");

            Sprite = Image.FromFile($"assets/sprite/{directory}.png");
           // Sprite = new Bitmap(tmp);

            ExpressedEngine.RegisterSprite(this);
        }

        public void DestroySelf()
        {
            Log.Info($"[Sprite2D] {Tag} - has been destoryed!");
            ExpressedEngine.UnRegisterSprite(this);
        }

    }
}
