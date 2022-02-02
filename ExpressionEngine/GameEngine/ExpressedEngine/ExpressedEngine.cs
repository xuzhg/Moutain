using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace GameEngine.ExpressiondEngine
{
    public abstract class ExpressedEngine
    {
        private Vector2 screenSize = new Vector2(512, 512);

        private string title = "New Game";

        private Canvas window = null;

        private Thread GameLoopThread = null;

        private static List<Shape2D> AllShapes = new List<Shape2D>();
        private static List<Sprite2D> AllSprites = new List<Sprite2D>();

        public static void RegisterShape(Shape2D shape)
        {
            AllShapes.Add(shape);
        }

        public static void UnRegisterShape(Shape2D shape)
        {
            AllShapes.Remove(shape);
        }

        public static void RegisterSprite(Sprite2D sprite)
        {
            AllSprites.Add(sprite);
        }

        public static void UnRegisterSprite(Sprite2D sprite)
        {
            AllSprites.Remove(sprite);
        }

        public Color backgroundColor = Color.Beige;
        protected ExpressedEngine(Vector2 screenSize, string title)
        {
            Log.Info("Game is starting ...");
            this.screenSize = screenSize;
            this.title = title;

            window = new Canvas();
            window.Size = new Size((int)screenSize.X, (int)screenSize.Y);
            window.Text = title;
            window.Paint += renderer;

            GameLoopThread = new Thread(GameLoop);
            GameLoopThread.Start();

            Application.Run(window);
        }

        private void renderer(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.Clear(backgroundColor);

            foreach (Shape2D shape in AllShapes)
            {
                g.FillRectangle(new SolidBrush(Color.Red),  shape.Position.X, shape.Position.Y, shape.Scale.X, shape.Scale.Y);
            }

            foreach (Sprite2D sprite in AllSprites)
            {
                g.DrawImage(sprite.Sprite, sprite.Position.X, sprite.Position.Y, sprite.Scale.X, sprite.Scale.Y);
            }
        }

        public void Run()
        {
            Application.Run(window);
        }

        void GameLoop()
        {
            OnLoad();
            while (GameLoopThread.IsAlive)
            {
                try
                {
                    OnDraw();
                    window.BeginInvoke((MethodInvoker)delegate { window.Refresh(); });
                    OnUpdate();
                    Thread.Sleep(1);
                }
                catch
                {
                    Log.Error("Window has not been found ... waiting ...");
                }
            }
        }

        public abstract void OnLoad();

        public abstract void OnUpdate();

        public abstract void OnDraw();
    }
}
