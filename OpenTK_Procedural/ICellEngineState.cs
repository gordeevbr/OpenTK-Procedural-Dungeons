using System.Collections.Generic;

namespace OpenTK_Procedural
{
    interface ICellEngineState
    {
        bool Done();

        void Tick(IList<Cell> Cells);
    }
}
