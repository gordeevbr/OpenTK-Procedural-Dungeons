using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenTK_Procedural
{
    class SpawnState : ICellEngineState
    {
        private bool Done = false;
        private ParkMillerCartaRNG RNG;

        public SpawnState()
        {
            RNG = new ParkMillerCartaRNG();
        }

        bool ICellEngineState.Done()
        {
            return Done;
        }

        void ICellEngineState.Tick(IList<Cell> Cells)
        {
            if (Done)
            {
                return;
            }
            if (Cells.Count >= Field.FieldCellCap)
            {
                Done = true;
            }
            else
            {
                Cell NewCell = ProduceCell();
                Cells.Add(NewCell);
            }
            if (Cells.Count >= Field.FieldCellCap)
            {
                Done = true;
            }

        }

        private Cell ProduceCell()
        {
            int X = RNG.GenerateRanged(Field.Middle.X - Field.DistanceFromMiddle,
                Field.Middle.X + Field.DistanceFromMiddle);
            int Y = RNG.GenerateRanged(Field.Middle.Y - Field.DistanceFromMiddle,
                Field.Middle.Y + Field.DistanceFromMiddle);
            int Width = RNG.GenerateRanged(Field.MinCellLength, Field.MaxCellLength);
            int Height = RNG.GenerateOffseted(Width, Field.AllowedSideDifferenceTimes,
                Field.MaxCellLength, Field.MinCellLength);
            return new Cell(new Rectangle(X, Y, Width, Height));
        }
    }
}
