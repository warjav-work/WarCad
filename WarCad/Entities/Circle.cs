namespace WarCad.Entities
{
    public class Circle
    {
        private double radius;
        private double _thickness;
        public Circle() : this(Vector3.Zero, 1.0)
        {

        }
        public Circle(Vector3 center, double radius)
        {
            this.Center = center;
            this.Radius = radius;
            this.Thickness = 0.0;
        }

        public double Radius { get => radius; set => radius = value; }
        public double Thickness { get => _thickness; set => _thickness = value; }
        public Vector3 Center { get; set; }
        public double Diameter
        {
            get { return this.Radius * 2.0; }
        }
    }
}
