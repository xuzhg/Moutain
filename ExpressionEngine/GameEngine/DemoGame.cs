using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameEngine.ExpressiondEngine;

namespace GameEngine
{
    public class DemoGame : ExpressedEngine
    {
        Shape2D player;

        string[,] Map =
        {
           { ".", ".", ".", ".", ".", ".", "."},
           { ".", ".", ".", ".", ".", ".", "."},
           { ".", ".", ".", ".", ".", ".", "."},
           { ".", ".", ".", ".", ".", ".", "."},
           { "g", "g.", "g", ".", "g", ".", "."},
           { ".", ".", ".", ".", ".", ".", "."}
        };


        public DemoGame() :
            base(new Vector2(615, 515), "Demo Game")
        {
        }

        public override void OnLoad()
        {
            backgroundColor = Color.Black;

         //   player = new Shape2D(new Vector2(10, 10), new Vector2(10, 10), "Test");

        //    Sprite2D p = new Sprite2D(new Vector2(20, 40), new Vector2(40, 66), "alienBlue", "Test");
            for (int i = 0; i < Map.GetLength(0); i++)
            {

                for (int j = 0; j < Map.GetLength(1); j++)
                {

                }
            }
        }


      ////  int frame = 0;
///float x = 1f;
        public override void OnDraw()
        {
           
        }


        public override void OnUpdate()
        {
           // System.Console.WriteLine($"Frame count: {frame++}");

           // player.Position.X += x;
        ////    player.Scale.X += x;
         //   player.Scale.Y += x;
        }
    }
}
