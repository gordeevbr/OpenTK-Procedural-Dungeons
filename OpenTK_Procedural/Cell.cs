using OpenTK;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenTK_Procedural
{

    class Cell
    {
        public Vector2d LeftUpperPoint { get; private set; }
        public int Width { get; private set; }
        public int Height { get; private set; }
        public Color FillColor { get; private set; }
        public Color BorderColor { get; private set; }

        public Cell(Vector2d LeftUpperPoint, int Width, int Height)
        {
            this.LeftUpperPoint = LeftUpperPoint;
            this.Width = Width;
            this.Height = Height;
            FillColor = Color.CadetBlue;
            BorderColor = Color.AliceBlue;
        }
    }
}
