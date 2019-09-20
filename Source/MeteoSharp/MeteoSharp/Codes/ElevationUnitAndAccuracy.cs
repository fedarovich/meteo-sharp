using System;
using System.Collections.Generic;
using System.Text;

namespace MeteoSharp.Codes
{
    /// <summary>
    /// Code table 1845: Indicator for units of elevation, and confidence factor for accuracy of elevation
    /// </summary>
    public enum ElevationUnitAndAccuracy : byte
    {
        Invalid = 0,

        /// <summary>
        /// Unit: meter. Accuracy: within 3 meters.
        /// </summary>
        MeterExcellent = 1,

        /// <summary>
        /// Unit: meter. Accuracy: within 10 meters.
        /// </summary>
        MeterGood = 2,

        /// <summary>
        /// Unit: meter. Accuracy: within 20 meters.
        /// </summary>
        MeterFair = 3,
        
        /// <summary>
        /// Unit: meter. Accuracy: more than 20 meters.
        /// </summary>
        MeterPoor = 4,

        /// <summary>
        /// Unit: foot. Accuracy: within 10 feet.
        /// </summary>
        FootExcellent = 5,

        /// <summary>
        /// Unit: foot. Accuracy: within 30 feet.
        /// </summary>
        FootGood = 6,

        /// <summary>
        /// Unit: foot. Accuracy: within 60 feet.
        /// </summary>
        FootFair = 7,
        
        /// <summary>
        /// Unit: foot. Accuracy: more than 60 feet.
        /// </summary>
        FootPoor = 8,
    }
}
