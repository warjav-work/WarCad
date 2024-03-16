using System;

namespace WarCad.Entities
{
    public class Line
    {
        private Vector3 _startPoint;
        private Vector3 _endPoint;
        private double _thickness;

        public Vector3 StartPoint { get => _startPoint; set => _startPoint = value; }
        public Vector3 EndPoint { get => _endPoint; set => _endPoint = value; }
        public Line() : this(Vector3.Zero, Vector3.Zero) { }

        public Line(Vector3 start, Vector3 end)
        {
            this._startPoint = start;
            this._endPoint = end;
            this._thickness = 0.0;
        }

        public double Length
        {
            get
            {
                double dx = EndPoint.X - StartPoint.X;
                double dy = EndPoint.Y - StartPoint.Y;
                double dz = EndPoint.Z - StartPoint.Z;

                return Math.Sqrt(dx * dx + dy * dy + dz * dz);
            }
        }
    }
}
