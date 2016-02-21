using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Drawing;
using System.Linq;
using System.Threading;

namespace OpenTK_Procedural
{
    class CellEngineStrategy
    {
        private InvalidationCallback Invalidate;
        private bool Running = false;
        private int FPS;
        private IList<Cell> Cells;
        public IList<Cell> Renderable
        {
            get
            {
                return ImmutableList.Create(Cells.ToArray());
            }
        }
        private Queue<ICellEngineState> Program;
        private ICellEngineState State = null;
        private Timer Timer;

        public CellEngineStrategy(InvalidationCallback Invalidate, int FPS, Queue<ICellEngineState> Program)
        {
            this.Invalidate = Invalidate;
            this.FPS = FPS;
            this.Program = Program;
            Cells = new List<Cell>();
            TimerCallback TickCallback = Tick;
            Timer = new Timer(Tick, null, Timeout.Infinite, Timeout.Infinite);
        }

        public void Start()
        {
            if (!Running && (Program.Count > 0 || State != null))
            {
                if (State == null)
                {
                    State = Program.Dequeue();
                }
                Running = true;
                Timer.Change(0, (1000 / FPS));
            }
        }

        private void Tick(Object stateInfo)
        {
            if (!Running)
            {
                return;
            }
            State.Tick(Cells);
            Invalidate();
            if (State.Done())
            {
                if (Program.Count > 0)
                {
                    State = Program.Dequeue();
                }
                else
                {
                    Stop();
                }
            }
        }

        public void Stop()
        {
            Timer.Change(Timeout.Infinite, Timeout.Infinite);
            Running = false;
        }
    }
}
