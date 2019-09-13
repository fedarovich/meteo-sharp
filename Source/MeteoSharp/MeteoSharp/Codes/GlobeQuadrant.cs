using System;
using System.Collections.Generic;
using System.Text;

namespace MeteoSharp.Codes
{
    /// <summary>
    /// Code table 3333: Quadrant of the globe
    /// </summary>
    public enum GlobeQuadrant : byte
    {
        Invalid = 0,

        NorthEast = 1,
        SouthEast = 3,
        SouthWest = 5,
        NorthWest = 7
    }
}
