using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarCad.Entities
{
    public class LwPolylineVertex
    {
        private Vector2 _position;
        private double _bulge;

        public LwPolylineVertex() : this(Vector2.Zero, 0.0)
        {            
        }

        public LwPolylineVertex(Vector2 position) : this(position, 0.0)
        {
        }

        public LwPolylineVertex(Vector2 position, double bulge)
        {
            _position = position;
            _bulge = bulge;
        }

        public Vector2 Position { get => _position; set => _position = value; }
        public double Bulge { get => _bulge; set => _bulge = value; }
    }
}
