using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenTK_Procedural
{
    class SeparationState : ICellEngineState
    {
        private bool Done = false;

        bool ICellEngineState.Done()
        {
            return Done;
        }

        void ICellEngineState.Tick(IList<Cell> Cells)
        {
            Boolean Found = false;
            //foreach(Cell away)
        }
    }
}
