using System;
using System.Drawing;

namespace WarCad
{
    public class Vector3
    {
        private double x;
        private double y;
        private double z;

        public Vector3(double x, double y)
        {
            this.x = x;
            this.y = y;
            this.z = 0.0;
        }

        public Vector3(double x, double y, double z) : this(x, y)
        {
            this.z = z;
        }

        public double X { get => x; set => x = value; }
        public double Y { get => y; set => y = value; }
        public double Z { get => z; set => z = value; }

        public static Vector3 Zero { get { return new Vector3(0.0, 0.0, 0.0); } }

        public PointF ToPointF { get { return new PointF((float)X, (float)Y); } }

        public double DistanceFrom(Vector3 v)
        {
            double dx = v.X - x;
            double dy = v.Y - y;
            double dz = v.Z - z;
            return Math.Sqrt(dx * dx + dy * dy + dz * dz);
        }

        public Vector2 ToVector2 {  get { return new Vector2(x, y); } }

    }
}
