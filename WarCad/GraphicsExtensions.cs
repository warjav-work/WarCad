using System.Drawing;
using WarCad.Entities;

namespace WarCad
{
    public static class GraphicsExtensions
    {
        private static float Height;
        private static float XScroll;
        private static float YScroll;
        private static float ScaleFactor;

        public static void SetParameters(this Graphics g, float xScroll, float yScroll, float scaleFactor,float height)
        {
            XScroll = xScroll;
            YScroll = yScroll;
            ScaleFactor = scaleFactor;
            Height = height;
        }
        public static void SetTransform(this Graphics g)
        {
            g.PageUnit = GraphicsUnit.Millimeter;
            g.TranslateTransform(0, Height);
            g.ScaleTransform(ScaleFactor, -ScaleFactor);
            g.TranslateTransform(-XScroll / ScaleFactor, YScroll / ScaleFactor);
        }

        public static void DrawPoint(this Graphics g, Pen pen, Entities.Point point)
        {
            g.SetTransform();
            PointF p = point.Position.ToPointF;
            g.DrawEllipse(pen, p.X - 1, p.Y - 1, 2, 2);
            g.ResetTransform();
        }

        public static void DrawLine(this Graphics g, Pen pen, Entities.Line line)
        {
            g.SetTransform();
            g.DrawLine(pen, line.StartPoint.ToPointF, line.EndPoint.ToPointF);
            g.ResetTransform();
        }

        public static void DrawCircle(this Graphics g, Pen pen, Entities.Circle circle)
        {
            float x = (float)(circle.Center.X - circle.Radius);
            float y = (float)(circle.Center.Y - circle.Radius);
            float d = (float)circle.Diameter;

            g.SetTransform();
            g.DrawEllipse(pen, x, y, d, d);
            g.ResetTransform();
        }

        public static void DrawEllipse(this Graphics g, Pen pen, Entities.Ellipse ellipse)
        {
            
            g.SetTransform();
            g.TranslateTransform(ellipse.Center.ToPointF.X, ellipse.Center.ToPointF.Y);
            g.RotateTransform((float)ellipse.Rotation);
            g.DrawEllipse(pen, -(float)ellipse.MayorAxis, -(float)ellipse.MinorAxis,(float)ellipse.MayorAxis * 2, (float)ellipse.MinorAxis * 2);
            g.ResetTransform();
        }

        public static void DrawArc(this Graphics g, Pen pen, Entities.Arc arc)
        {
            float x = (float)(arc.Center.X - arc.Radius);
            float y = (float)(arc.Center.Y - arc.Radius);
            float d = (float)arc.Diameter;

            RectangleF rect = new RectangleF(x, y, d, d);

            g.SetTransform();
            g.DrawArc(pen, rect, (float)arc.StartAngle, (float)arc.EndAngle);
            g.ResetTransform();
        }
        public static void DrawPolyline(this Graphics g, Pen pen, LwPolyline polyline)
        {
            PointF[] vertexes = new PointF[polyline.Vertexes.Count];
            if (polyline.IsClosed)
            {
                vertexes = new PointF[polyline.Vertexes.Count + 1];
                vertexes[polyline.Vertexes.Count] = polyline.Vertexes[0].Position.ToPointF;
            }

            for (int i = 0; i < polyline.Vertexes.Count; i++)
            {
                vertexes[i] = polyline.Vertexes[i].Position.ToPointF;
            }
            g.SetTransform();
            g.DrawLines(pen, vertexes);
            g.ResetTransform();
        }
    }
}
