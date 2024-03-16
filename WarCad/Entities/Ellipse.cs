using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarCad.Entities
{
    public class Ellipse
    {
        private Vector3 center;
        private double mayorAxis;
        private double minorAxis;
        private double rotation;
        private double startAngle;
        private double endAngle;
        private double _thickness;       

        public Ellipse(Vector3 center, double mayorAxis, double minorAxis)
        {
            this.Center = center;
            this.MayorAxis = mayorAxis;
            this.MinorAxis = minorAxis;
            this.StartAngle = 0.0;
            this.EndAngle = 360.0;
            this.Thickness = 0.0;
            this.Rotation = 0.0;
        }

        public Vector3 Center { get => center; set => center = value; }
        public double MayorAxis { get => mayorAxis; set => mayorAxis = value; }
        public double MinorAxis { get => minorAxis; set => minorAxis = value; }
        public double Rotation { get => rotation; set => rotation = value; }
        public double StartAngle { get => startAngle; set => startAngle = value; }
        public double EndAngle { get => endAngle; set => endAngle = value; }
        public double Thickness { get => _thickness; set => _thickness = value; }
    }
}
