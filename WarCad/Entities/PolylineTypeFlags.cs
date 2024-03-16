using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarCad.Entities
{
    [Flags]
    internal enum PolylineTypeFlags
    {
        OpenLwPolyline = 0,
        CloseLwPolyline = 1
    }
}
