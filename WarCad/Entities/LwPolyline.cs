using System;
using System.Collections.Generic;

namespace WarCad.Entities
{
    public class LwPolyline
    {
        private List<LwPolylineVertex> vertexes;
        private PolylineTypeFlags flags;
        private double thickness;

        public LwPolyline() : this(new List<LwPolylineVertex>(), false)
        {

        }
        public LwPolyline(List<LwPolylineVertex> vertexes, bool IsClosed)
        {
            if (vertexes == null)
            {
                throw new ArgumentNullException(nameof(vertexes));
            }
            this.vertexes = vertexes;
            this.flags = IsClosed ? PolylineTypeFlags.CloseLwPolyline : PolylineTypeFlags.OpenLwPolyline;
            this.thickness = 0.0;
        }

        internal PolylineTypeFlags Flags
        {
            get { return flags; }
            set { flags = value; }
        }

        public bool IsClosed
        {
            get { return (this.flags & PolylineTypeFlags.CloseLwPolyline) == PolylineTypeFlags.CloseLwPolyline; }
            set { this.flags = value ? PolylineTypeFlags.CloseLwPolyline : PolylineTypeFlags.OpenLwPolyline; }
        }

        public List<LwPolylineVertex> Vertexes
        {
            get { return vertexes; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(value));
                }
                vertexes = value;
            }
        }
        public double Thickness { get => thickness; set => thickness = value; }
    }
}
