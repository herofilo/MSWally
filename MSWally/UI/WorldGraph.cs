using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MSWally.Domain;

namespace MSWally.UI
{
    public class WorldGraph
    {
        private readonly Color _defaultColor = Color.Black;

        private readonly Color _highlightedColor = Color.Red;

        public const int ToleranceDefault = 2;

        public const int WallPenWidthDefault = 2;

        public static int Tolerance { get; set; } = ToleranceDefault;

        public static int WallPenWidth { get; set; } = WallPenWidthDefault;


        private Panel _canvas;

        private Scene _scene;

        private List<GraphWall> _graphWalls;


        private bool _cleared = false;

        private double _xScale;
        private double _yScale;
        private double _xOffset;
        private double _yOffset;

        public bool CanDraw { get; private set; }

        public string CantDrawReason { get; private set; }

        // --------------------------------------------------------------------------------------------------------------------------------

        public WorldGraph(Panel pCanvas, Scene pScene)
        {
            _canvas = pCanvas;
            _scene = pScene;

            CanDraw = CanbeDrawn();
            if (!CanDraw)
            {
                Clear();
                return;
            }

            _xScale = _canvas.Width / _scene.SetWidth;
            _yScale = _canvas.Height / _scene.SetDepth;
            _xOffset = _xScale * (_scene.SetWidth / 2);
            _yOffset = _yScale * (_scene.SetDepth / 2);
        }


        private bool CanbeDrawn()
        {
            if (_canvas == null)
            {
                CantDrawReason = "No canvas defined";
                return false;
            }

            if (_scene == null)
            {
                CantDrawReason = "No scene to draw";
                return false;
            }

            if ((_scene.SetDepth <= 0) || (_scene.SetWidth <= 0))
            {
                CantDrawReason = "Scene dimensions not determined";
                return false;
            }

            if ((_scene.SetDepth > _canvas.Height) || (_scene.SetWidth > _canvas.Width))
            {
                CantDrawReason = $"Scene dimensions larger than maximum allowable ({_canvas.Width}x{_canvas.Height})";
                return false;
            }

            CantDrawReason = null;

            return true;
        }



        public void Clear()
        {
            if (_cleared)
                return;
            Graphics clearRectangle = _canvas.CreateGraphics();
            SolidBrush clearBrush = new SolidBrush(Color.White);

            clearRectangle.FillRectangle(clearBrush, 0, 0, _canvas.Width, _canvas.Height);
            clearRectangle.Dispose();
            clearBrush.Dispose();
            _cleared = true;
        }


        public void RedrawWorld()
        {
            Clear();
            if (!CanDraw)
                return;

            if (_graphWalls == null)
            {
                CreateGraphWalls(_scene.SetWalls);
            }

            // draw walls
            foreach (GraphWall wall in _graphWalls)
            {
                DrawWall(wall, _defaultColor);
            }

            _cleared = false;
        }

        private void CreateGraphWalls(List<Wall> pSceneSetWalls)
        {
            _graphWalls = new List<GraphWall>();

            foreach (Wall wall in _scene.SetWalls)
            {
                Point startPoint = WallCoordinateToGraphPoint(wall.StartCoordinate);
                Point endPoint = WallCoordinateToGraphPoint(wall.EndCoordinate);

                _graphWalls.Add(new GraphWall(startPoint, endPoint));
            }
        }


        public void RedrawWorld(List<int> pSelectedIndexes)
        {
            Clear();
            if (!CanDraw)
                return;

            RedrawWorld();
            HighlightWalls(pSelectedIndexes);
        }


        private void DrawWall(Wall pWall, Color pColor)
        {
            Graphics wallGraphics = _canvas.CreateGraphics();
            SolidBrush brush = new SolidBrush(pColor);
            Pen pen = new Pen(brush, WallPenWidth);

            Point startPoint = WallCoordinateToGraphPoint(pWall.StartCoordinate);
            Point endPoint = WallCoordinateToGraphPoint(pWall.EndCoordinate);

            wallGraphics.DrawLine(pen, startPoint, endPoint);

            wallGraphics.Dispose();
            pen.Dispose();
            brush.Dispose();
        }


        private void DrawWall(GraphWall pWall, Color pColor)
        {
            Graphics wallGraphics = _canvas.CreateGraphics();
            SolidBrush brush = new SolidBrush(pColor);
            Pen pen = new Pen(brush, WallPenWidth);

            wallGraphics.DrawLine(pen, pWall.StartCoordinate, pWall.EndCoordinate);

            wallGraphics.Dispose();
            pen.Dispose();
            brush.Dispose();
        }



        private void HighlightWalls(List<int> pIndexes)
        {
            if (!CanDraw)
                return;

            if (pIndexes == null)
                return;

            foreach (int index in pIndexes)
            {
                if (index > (_scene.SetWalls.Count - 1))
                    continue;
                DrawWall(_graphWalls[index], _highlightedColor);
            }

            _cleared = false;
        }


        public Point WallCoordinateToGraphPoint(Point pWallCoordinate)
        {
            int x = (int) Math.Round((pWallCoordinate.X * _xScale) + _xOffset);
            int y = (int)Math.Round((pWallCoordinate.Y * _yScale) + _yOffset);


            Point graphPoint = new Point(x, y);

            return graphPoint;
        }

        


        public int SelectWall(int pX, int pY)
        {
            if (!CanDraw)
                return -1;

            int index = 0;
            foreach (GraphWall wall in _graphWalls)
            {
                if ((pX >= (wall.LowerX - Tolerance)) && (pX <= (wall.UpperX + Tolerance)) && (pY >= (wall.LowerY - Tolerance)) && (pY <= (wall.UpperY + Tolerance)))
                    return index;
                index++;
            }

            return -1;
        }



        class GraphWall
        {
            public Point StartCoordinate { get; private set; } = Point.Empty;

            public int StartX => StartCoordinate.X;

            public int StartY => StartCoordinate.Y;

            public Point EndCoordinate { get; private set; } = Point.Empty;

            public int EndX => EndCoordinate.X;

            public int EndY => EndCoordinate.Y;

            public int LowerX => StartX <= EndX ? StartX : EndX;

            public int UpperX => StartX > EndX ? StartX : EndX;

            public int LowerY => StartY <= EndY ? StartY : EndY;

            public int UpperY => StartY > EndY ? StartY : EndY;



            public GraphWall(Point pStart, Point pEnd)
            {
                StartCoordinate = pStart;
                EndCoordinate = pEnd;
            }

        }

    }
}
