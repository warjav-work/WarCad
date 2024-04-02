using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using WarCad.Entities;
using WarCad.EntryForms;
using WarCad.Methods;
using Point = System.Drawing.Point;


namespace WarCad
{
    public partial class GraphicsForm : Form
    {
        #region Variables
        // vectors
        private Vector3 currentPosition;
        private Vector3 firstPoint;
        private Vector3 secondPoint;
        // lists
        private List<Entities.Point> _points = new List<Entities.Point>();
        private List<Entities.Line> _lines = new List<Entities.Line>();
        private List<Entities.Circle> _circles = new List<Entities.Circle>();
        private List<Entities.Ellipse> _ellipses = new List<Entities.Ellipse>();
        private List<Entities.Arc> _arcs = new List<Entities.Arc>();
        private List<LwPolyline> _polylines = new List<LwPolyline>();
        private LwPolyline tempPolyline = new LwPolyline();
        // ints
        private int DrawIndex = -1;
        private int ClickNum = 1;
        private int direction;
        private int sidesQty = 5;
        private int inscribed = 1;
        // float
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
                        case 11:// Arc (3-Point)                           
                        case 12:// Arc (Start, Center, End)                            
                        case 13:// Arc (Center, Start, End)
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
                                    switch (DrawIndex)
                                    {
                                        case 11:
                                            _arcs.Add(Method.GetArcWith3Points(firstPoint, secondPoint, currentPosition));
                                            break;
                                        case 12:
                                            _arcs.Add(Method.GetArcWithCenterStartEnd(secondPoint, firstPoint, currentPosition));
                                            break;
                                        case 13:
                                            _arcs.Add(Method.GetArcWithCenterStartEnd(firstPoint, secondPoint, currentPosition));
                                            break;
                                    }
                                    CancelAll();
                                    break;
                            }
                            break;
                        case 14:// Arc (Center, Start, Angle)
                        case 15:// Arc (Center, Start, Length)
                        case 16:// Arc (Start, End, Angle)
                        case 17:// Arc (Start, Center, Length)
                            switch (ClickNum)
                            {
                                case 1:
                                    firstPoint = currentPosition;
                                    ClickNum++;
                                    break;
                                case 2:
                                    secondPoint = currentPosition;
                                    using (var getValue = new GetDoubleValue())
                                    {
                                        getValue.Title = "Angle";
                                        switch (DrawIndex)
                                        {
                                            case 14:
                                            case 16:
                                                getValue.Title = "Angle";
                                                break;
                                            case 15:
                                            case 17:
                                                getValue.Title = "Length";
                                                break;
                                        }
                                        var result = getValue.ShowDialog();
                                        if (result == DialogResult.OK)
                                        {
                                            switch (DrawIndex)
                                            {
                                                case 14:
                                                    _arcs.Add(Method.GetArcWithCenterStartAngle(firstPoint, currentPosition, getValue.ResultValue));
                                                    break;
                                                case 15:
                                                    _arcs.Add(Method.GetArcWithCenterStartLength(firstPoint, currentPosition, getValue.ResultValue));
                                                    break;
                                                case 16:
                                                    _arcs.Add(Method.GetArcWithStartEndAngle(firstPoint, currentPosition, getValue.ResultValue));
                                                    break;
                                                case 17:
                                                    _arcs.Add(Method.GetArcWithCenterStartLength(currentPosition, firstPoint, getValue.ResultValue));
                                                    break;
                                            }

                                        }
                                        CancelAll();

                                    }
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
                        case 4:// LwPoliline
                            firstPoint = currentPosition;
                            tempPolyline.Vertexes.Add(new LwPolylineVertex(firstPoint.ToVector2));
                            ClickNum = 2;
                            break;
                        case 5:// Poligon
                            switch (ClickNum)
                            {
                                case 1:
                                    firstPoint = currentPosition;
                                    ClickNum++;
                                    using (var setPoligon = new EntryForms.SetPoligonValuesForm())
                                    {
                                        var result = setPoligon.ShowDialog();
                                        if (result == DialogResult.OK)
                                        {
                                            sidesQty = setPoligon.SidesQty;
                                            inscribed = setPoligon.Inscribed;
                                        }
                                        else
                                        {
                                            CancelAll();
                                        }
                                    }
                                    break;
                                case 2:
                                    _polylines.Add(Method.GetPolygon(firstPoint, currentPosition, sidesQty, inscribed));
                                    CancelAll();
                                    break;
                            }
                            break;
                        case 6: // Point
                            _points.Add(new Entities.Point(currentPosition));
                            break;
                        case 7:// Rectangle
                            switch (ClickNum)
                            {
                                case 1:
                                    firstPoint = currentPosition;
                                    ClickNum++;
                                    break;
                                case 2:
                                    _polylines.Add(Method.PointToRect(firstPoint, currentPosition, out direction));
                                    CancelAll();
                                    break;
                            }
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
                foreach (LwPolyline lw in _polylines)
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
                case 3:// Line
                case 4:// LwPolyline
                    if (ClickNum == 2)
                    {
                        e.Graphics.DrawLine(penExtend, new Entities.Line(firstPoint, currentPosition));
                    }
                    break;
                case 7:// Rectangle
                    if (ClickNum == 2)
                    {
                        LwPolyline lw = Method.PointToRect(firstPoint, currentPosition, out direction);
                        e.Graphics.DrawPolyline(penExtend, lw);
                    }
                    break;
                case 5:// Polygon
                    if (ClickNum == 2)
                    {
                        e.Graphics.DrawLine(penExtend, new Entities.Line(firstPoint, currentPosition));
                        LwPolyline lw = Method.GetPolygon(firstPoint, currentPosition, sidesQty, inscribed);
                        e.Graphics.DrawPolyline(penExtend, lw);
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
                case 11:// arc 3-Point
                case 12:// Start, Center, End
                case 13:// center, Start, End
                    switch (ClickNum)
                    {
                        case 2:
                            e.Graphics.DrawLine(penExtend, new Entities.Line(firstPoint, currentPosition));
                            break;
                        case 3:
                            switch (DrawIndex)
                            {
                                case 11:
                                    e.Graphics.DrawArc(penExtend, Method.GetArcWith3Points(firstPoint, secondPoint, currentPosition));
                                    break;
                                case 12:
                                    e.Graphics.DrawLine(penExtend, new Entities.Line(secondPoint, currentPosition));
                                    e.Graphics.DrawArc(penExtend, Method.GetArcWithCenterStartEnd(secondPoint, firstPoint, currentPosition));
                                    break;
                                case 13:
                                    e.Graphics.DrawLine(penExtend, new Entities.Line(firstPoint, currentPosition));
                                    e.Graphics.DrawArc(penExtend, Method.GetArcWithCenterStartEnd(firstPoint, secondPoint, currentPosition));
                                    break;
                            }

                            break;

                    }
                    break;
                case 14:// Arc (Center, Start, Angle)
                case 15:// Arc (Center, Start, Length)
                case 16:// Arc (Start, End, Angle)
                case 17:// Arc (Start, Center, Length)
                    switch (ClickNum)
                    {
                        case 2:
                            e.Graphics.DrawLine(penExtend, new Entities.Line(firstPoint, currentPosition));
                            break;
                    }
                    break;
            }
            // Test line line intersect
            //if (_lines.Any())
            //{
            //    foreach (Entities.Line line1 in _lines)
            //    {
            //        foreach (Entities.Line line2 in _lines)
            //        {
            //            Vector3 v = Method.LineLineIntersection(line1, line2);
            //            e.Graphics.DrawPoint(new Pen(Color.Black, 0), new Entities.Point(v));
            //        }
            //    }
            //}

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
