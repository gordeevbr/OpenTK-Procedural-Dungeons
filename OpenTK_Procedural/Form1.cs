using OpenTK;
using OpenTK.Graphics.OpenGL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OpenTK_Procedural
{
    public partial class Form1 : Form
    {
        private bool Loaded = false;
        private int ViewPortWidth;
        private int ViewPortHeight;
        private CellEngineStrategy CellEngine;

        public Form1()
        {
            InvalidationCallback Invalidate = InvalidateGL;
            Queue<ICellEngineState> Program = new Queue<ICellEngineState>();
            CellEngine = new CellEngineStrategy(Invalidate, 10, Program);
            InitializeComponent();
        }

        private void InvalidateGL()
        {
            glControl1.Invalidate();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Loaded = true;
            GL.ClearColor(Color.Black);
            SetViewPort();
            CellEngine.Start();
        }

        private void SetViewPort()
        {
            ViewPortWidth = glControl1.Width;
            ViewPortHeight = glControl1.Height;
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
            GL.Ortho(0, ViewPortWidth, 0, ViewPortHeight, -1, 1);
            GL.Viewport(0, 0, ViewPortWidth, ViewPortHeight);
        }

        private void glControl1_Resize_1(object sender, EventArgs e)
        {
            if (!Loaded)
            {
                return;
            }
            SetViewPort();
        }

        private void glControl1_Paint(object sender, PaintEventArgs e)
        {
            if (!Loaded)
            {
                return;
            }
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            foreach(Cell Renderable in CellEngine.Renderable)
            {
                RenderCell(Renderable);
            }
            glControl1.SwapBuffers();
        }

        private void RenderCell(Cell Renderable)
        {
            double X = Field.TranslateCoordinatesX(Renderable.LeftUpperPoint.X, ViewPortWidth);
            double Y = Field.TranslateCoordinatesY(Renderable.LeftUpperPoint.Y, ViewPortHeight);
            double OffsetX = Field.TranslateCoordinatesX(Renderable.Width, ViewPortWidth);
            double OffsetY = Field.TranslateCoordinatesY(Renderable.Height, ViewPortHeight);
            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadIdentity();
            GL.Color3(Renderable.FillColor);
            GL.Begin(PrimitiveType.Quads);
            GL.Vertex2(X, Y - OffsetY);
            GL.Vertex2(X + OffsetX, Y - OffsetY);
            GL.Vertex2(X + OffsetX, Y);
            GL.Vertex2(X, Y);
            GL.End();
            GL.Color3(Renderable.BorderColor);
            GL.Begin(PrimitiveType.LineLoop);
            GL.Vertex2(X + OffsetX, Y - OffsetY);
            GL.Vertex2(X, Y - OffsetY);
            GL.Vertex2(X, Y);
            GL.Vertex2(X + OffsetX, Y);
            GL.End();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Loaded = false;
            CellEngine.Stop();
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            CellEngine.Start();
        }
    }
}
