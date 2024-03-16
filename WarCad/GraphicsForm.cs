using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using WarCad.Entities;
using WarCad.Methods;
using Point = System.Drawing.Point;


namespace WarCad
{
    public partial class GraphicsForm : Form
    {
        #region Variables
        private Vector3 currentPosition;
        private Vector3 firstPoint;
        private Vector3 secondPoint;
        private List<Entities.Point> _points = new List<Entities.Point>();
        private List<Entities.Line> _lines = new List<Entities.Line>();
        private List<Entities.Circle> _circles = new List<Entities.Circle>();
        private List<Entities.Ellipse> _ellipses = new List<Entities.Ellipse>();
        private List<Entities.Arc> _arcs = new List<Entities.Arc>();
        private List<LwPolyline> _polylines = new List<LwPolyline>();
        private LwPolyline tempPolyline = new LwPolyline();
        private int DrawIndex = -1;
        private int ClickNum = 1;
        private float xScroll;
        private float yScroll;
        private float ScaleFactor = 1.0f;
        private bool activeDraw = false;
        #endregion

        public GraphicsForm()
        {
            InitializeComponent();
        }


        #region MouseMove
        private void drawing_MouseMove(object sender, MouseEventArgs e)
        {
            currentPosition = PointToCartesian(e.Location);
            screen.Text = $"Pantalla (px): {e.Location.X}, {e.Location.Y}";
            //coordinate.Text = string.Format("{0:0.000}, {1:0.000}, {2:0.000}", currentPosition.X, currentPosition.Y, currentPosition.Z).Replace(",", ".").Replace(". ", ", ");
            coordinate.Text = $"{currentPosition.X.ToString("F3")}, {currentPosition.Y.ToString("F3")}, {currentPosition.Z.ToString("F3")}".Replace(",", ".").Replace(". ", ", ");
            drawing.Refresh();
        }
        #endregion

        #region GetDpi
        private float DPI
        {
            get
            {
                using (var g = CreateGraphics())
                    return g.DpiX;
            }
        }
        #endregion

        #region Covertir punto del sistema a Cartesiano
        private Vector3 PointToCartesian(Point point)
        {
            return new Vector3(PixelToMm(point.X + xScroll) / ScaleFactor, (PixelToMm(drawing.Height - point.Y) - yScroll) / ScaleFactor);
        }
        #endregion

        #region Convertir pixel a milimetros
        private float PixelToMm(float pixel)
        {
            return pixel * 25.4f / DPI;
        }
        #endregion

        #region MouseDown
        private void drawing_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (activeDraw)
                {
                    switch (DrawIndex)
                    {
                        case 11:// Arc
                            switch (ClickNum)
                            {
                                case 1:
                                    firstPoint = currentPosition;
                                    ClickNum++;
                                    break;
                                case 2:
                                    secondPoint = currentPosition;
                                    ClickNum++;
                                    break;
                                case 3:
                                    _arcs.Add(Method.GetArcWith3Points(firstPoint, secondPoint, currentPosition));
                                    CancelAll();
                                    break;
                            }
                            break;
                        case 21://circle
                            switch (ClickNum)
                            {
                                case 1:
                                    firstPoint = currentPosition;
                                    ClickNum++;
                                    break;
                                case 2:
                                    double r = firstPoint.DistanceFrom(currentPosition);
                                    _circles.Add(new Entities.Circle(firstPoint, r));
                                    ClickNum = 1;
                                    break;
                            }
                            break;
                        case 22://circle with 3 point
                            switch (ClickNum)
                            {
                                case 1:
                                    firstPoint = currentPosition;
                                    ClickNum++;
                                    break;
                                case 2:
                                    secondPoint = currentPosition;
                                    ClickNum++;
                                    break;
                                case 3:

                                    _circles.Add(Method.GetCircleWith3Point(firstPoint, secondPoint, currentPosition));
                                    CancelAll();
                                    break;
                            }
                            break;
                        case 31:// ellipse
                            switch (ClickNum)
                            {
                                case 1:
                                    firstPoint = currentPosition;
                                    ClickNum++;
                                    break;
                                case 2:
                                    secondPoint = currentPosition;
                                    ClickNum++;
                                    break;
                                case 3:

                                    Entities.Ellipse ellipse = Method.GetEllipse(firstPoint, secondPoint, currentPosition);
                                    _ellipses.Add(ellipse);
                                    ClickNum = 1;
                                    break;
                            }
                            break;
                        case 3:// line
                            switch (ClickNum)
                            {
                                case 1:
                                    firstPoint = currentPosition;
                                    _points.Add(new Entities.Point(currentPosition));
                                    ClickNum++;
                                    break;
                                case 2:
                                    _lines.Add(new Entities.Line(firstPoint, currentPosition));
                                    _points.Add(new Entities.Point(currentPosition));
                                    firstPoint = currentPosition;
                                    ClickNum = 1;
                                    break;
                            }
                            break;
                        case 4://LwPoliline
                            firstPoint = currentPosition;
                            tempPolyline.Vertexes.Add(new LwPolylineVertex(firstPoint.ToVector2));
                            ClickNum = 2;
                            break;
                        case 6: // point
                            _points.Add(new Entities.Point(currentPosition));
                            break;


                    }
                    drawing.Refresh();
                }
            }            
        }
        #endregion

        #region Paint
        private void drawing_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SetParameters(xScroll, yScroll, ScaleFactor, PixelToMm(drawing.Height));
            Pen pen = new Pen(Color.Blue, 0.1f);
            Pen penExtend = new Pen(Color.Gray, 0.1f);
            penExtend.DashPattern = new float[] { 1.0f, 2.0f };

            // draw all points
            if (_points.Count > 0)
            {
                foreach (Entities.Point point in _points)
                {
                    e.Graphics.DrawPoint(new Pen(Color.Red, 0.1f), point);
                }
            }

            // Draw all lines
            if (_lines.Any())
            {
                foreach (Entities.Line line in _lines)
                {
                    e.Graphics.DrawLine(pen, line);
                }
            }

            // Draw All circle
            if (_circles.Any())
            {
                foreach (Entities.Circle circle in _circles)
                {
                    e.Graphics.DrawCircle(pen, circle);
                }
            }

            // draw all ellipse
            if (_ellipses.Any())
            {
                foreach (Entities.Ellipse ellipse in _ellipses)
                {
                    e.Graphics.DrawEllipse(pen, ellipse);
                }
            }

            // draw all arcs
            if (_arcs.Any())
            {
                foreach (Entities.Arc arc in _arcs)
                {
                    e.Graphics.DrawArc(pen, arc);
                }
            }

            // Draw all LwPolylines
            if (_polylines.Any())
            {
                foreach(LwPolyline lw in _polylines)
                {
                    e.Graphics.DrawPolyline(pen, lw);
                }
            }

            //DrawTempPolyline
            if (tempPolyline.Vertexes.Count > 1)
            {
                e.Graphics.DrawPolyline(pen, tempPolyline);
            }

            // Draw Line extended
            switch (DrawIndex)
            {
                case 3:
                case 4:
                    if (ClickNum == 2)
                    {
                        e.Graphics.DrawLine(penExtend, new Entities.Line(firstPoint, currentPosition));
                    }
                    break;
                case 21:
                    if (ClickNum == 2)
                    {
                        e.Graphics.DrawLine(penExtend, new Entities.Line(firstPoint, currentPosition));
                        double radio = firstPoint.DistanceFrom(currentPosition);
                        Entities.Circle circle = new Entities.Circle(firstPoint, radio);
                        e.Graphics.DrawCircle(penExtend, circle);
                    }
                    break;
                case 31:
                    switch (ClickNum)
                    {
                        case 2:
                            e.Graphics.DrawLine(penExtend, new Entities.Line(firstPoint, currentPosition));
                            break;
                        case 3:
                            e.Graphics.DrawLine(penExtend, new Entities.Line(firstPoint, currentPosition));
                            Entities.Ellipse ellipse = Method.GetEllipse(firstPoint, secondPoint, currentPosition);
                            e.Graphics.DrawEllipse(penExtend, ellipse);
                            break;
                    }
                    break;
                case 22:
                    switch (ClickNum)
                    {
                        case 2:
                            e.Graphics.DrawLine(penExtend, new Entities.Line(firstPoint, currentPosition));
                            break;
                        case 3:
                            e.Graphics.DrawCircle(penExtend, Method.GetCircleWith3Point(firstPoint, secondPoint, currentPosition));
                            break;

                    }
                    break;
                case 11:
                    switch (ClickNum)
                    {
                        case 2:
                            e.Graphics.DrawLine(penExtend, new Entities.Line(firstPoint, currentPosition));
                            break;
                        case 3:
                            e.Graphics.DrawArc(penExtend, Method.GetArcWith3Points(firstPoint, secondPoint, currentPosition));
                            break;

                    }
                    break;
            }
            // Test line line intersect
            if (_lines.Any())
            {
                foreach (Entities.Line line1 in _lines)
                {
                    foreach (Entities.Line line2 in _lines)
                    {
                        Vector3 v = Method.LineLineIntersection(line1, line2);
                        e.Graphics.DrawPoint(new Pen(Color.Black, 0), new Entities.Point(v));
                    }
                }
            }

        }
        #endregion

        #region CancelAll
        private void CancelAll(int index = 1)
        {
            DrawIndex = -1;
            activeDraw = false;
            drawing.Cursor = Cursors.Default;
            ClickNum = 1;
            LwPolylineCloseStatus(index);
        }
        #endregion

        #region CancelBtn
        private void CancelBtn_Click(object sender, EventArgs e)
        {
            CancelAll();
        }
        #endregion

        #region DrawBnt
        private void DrawBtn_Click(object sender, EventArgs e)
        {
            var item = sender as RibbonButton;
            DrawIndex = drawPanel.Items.IndexOf(item);
            activeDraw = true;
            drawing.Cursor = Cursors.Cross;
        }
        #endregion

        private void CircleBtn_Click(object sender, EventArgs e)
        {
            var item = sender as RibbonButton;
            DrawIndex = circleBttn.DropDownItems.IndexOf(item) + 21;
            activeDraw = true;
            drawing.Cursor = Cursors.Cross;
        }

        private void ArcBtn_Click(object sender, EventArgs e)
        {
            var item = sender as RibbonButton;
            DrawIndex = arcBtn.DropDownItems.IndexOf(item) + 11;
            activeDraw = true;
            drawing.Cursor = Cursors.Cross;
        }

        private void EllipseBtn_Click(object sender, EventArgs e)
        {
            var item = sender as RibbonButton;
            DrawIndex = ellipseBttn.DropDownItems.IndexOf(item) + 31;
            activeDraw = true;
            drawing.Cursor = Cursors.Cross;
        }

        private void hScrollBar_Scroll(object sender, ScrollEventArgs e)
        {
            xScroll = (sender as HScrollBar).Value;
            drawing.Refresh();
        }

        private void vScrollBar_Scroll(object sender, ScrollEventArgs e)
        {
            yScroll = (sender as VScrollBar).Value;
            drawing.Refresh();
        }

        private void closeBoundary_Click(object sender, EventArgs e)
        {
            switch (DrawIndex)
            {
                case 3://line
                    break;
                case 4: //Lwpolyline
                    CancelAll(2);
                    break;
            }
        }

        private void LwPolylineCloseStatus(int index)
        {
            List<LwPolylineVertex> vertexes = new List<LwPolylineVertex>();
            foreach (LwPolylineVertex vertex in tempPolyline.Vertexes)
            {
                vertexes.Add(vertex);
            }
            if (vertexes.Count > 0)
            {
                switch (index)
                {
                    case 1:
                        _polylines.Add(new LwPolyline(vertexes, false));
                        break;
                    case 2:
                        if (vertexes.Count > 2)
                        {
                            _polylines.Add(new LwPolyline(vertexes, true));
                        }
                        else
                        {
                            _polylines.Add(new LwPolyline(vertexes, false));
                        }
                        break;                    
                }
            }
            tempPolyline.Vertexes.Clear();
        }
    }
}
