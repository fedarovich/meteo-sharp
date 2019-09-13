using System;
using System.Collections.Generic;
using System.Text;

namespace MeteoSharp.Codes
{
    /// <summary>
    /// Code table 1855 : Indicator for source and units of wind speed
    /// </summary>
    public enum WindSourceAndUnits : byte
    {
        EstimatedMetersPerSecond = 0,
        AnemometerMetersPerSecond = 1,
        EstimatedKnots = 2,
        AnemometerKnots = 3
    }
}
