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
        public Rectangle Rectangle { get; private set; }
        public Color FillColor { get; private set; }
        public Color BorderColor { get; private set; }

        public Cell(Rectangle Rectangle)
        {
            this.Rectangle = Rectangle;
            FillColor = Color.CadetBlue;
            BorderColor = Color.AliceBlue;
        }
    }
}
