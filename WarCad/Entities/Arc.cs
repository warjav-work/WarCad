namespace WarCad.Entities
{
    public class Arc
    {
        public Arc() : this(Vector3.Zero, 1.0, 0.0, 180.0) { }
        public Arc(Vector3 center, double radius, double start, double end)
        {
            this.Center = center;
            this.Radius = radius;
            this.StartAngle = start;
            this.EndAngle = end;
            this.Thickness = 0.0;
        }

        public Vector3 Center { get; set; }
        public double Radius { get; set; }
        public double StartAngle { get; set; }
        public double EndAngle { get; set; }
        public double Thickness { get; set; }
        public double Diameter { get { return this.Radius * 2; } }
    }
}
