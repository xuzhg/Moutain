using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Threading;

namespace ExpressedEngine.ExpressedEngine
{


    public abstract class ExpressedEngine
    {
        private Vector2 ScreenSize = new Vector2(512, 512);

        private string Title;

        protected ExpressedEngine(Vector2 screenSize, string title)
        {
            this.ScreenSize = screenSize;
            this.Title = title;
        }
    }
}
