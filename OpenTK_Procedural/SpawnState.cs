using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenTK_Procedural
{
    class SpawnState : ICellEngineState
    {
        private bool Done = false;

        bool ICellEngineState.Done()
        {
            //TODO set generation ceiling
            return Done;
        }

        void ICellEngineState.Tick(IList<Cell> Cells)
        {
            throw new NotImplementedException();
        }
    }
}
