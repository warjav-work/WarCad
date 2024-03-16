using System;
using System.Drawing;

namespace WarCad
{
    public class Vector2
    {
        private double x;
        private double y;

        public Vector2(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        public double X { get => x; set => x = value; }
        public double Y { get => y; set => y = value; }

        public static Vector2 Zero { get { return new Vector2(0.0, 0.0); } }

        public PointF ToPointF { get { return new PointF((float)X, (float)Y); } }

        public double DistanceFrom(Vector2 v)
        {
            double dx = v.X - x;
            double dy = v.Y - y;

            return Math.Sqrt(dx * dx + dy * dy);
        }        

    }
}
