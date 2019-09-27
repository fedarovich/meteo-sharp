using System;
using System.Collections.Generic;
using System.Text;

namespace MeteoSharp.Codes
{
    /// <summary>
    /// Code table 1600 : Height above surface of the base of the lowest cloud seen
    /// </summary>
    public enum LowestCloudBase : sbyte
    {
        /// <summary>
        /// Height of base of cloud not known or base of clouds at a level lower and tops at a level higher than
        /// that of the station
        /// </summary>
        Unknown = -1,

        /// <summary>
        /// 0 to 50 m
        /// </summary>
        From0To50Meters = 0,

        /// <summary>
        /// 50 to 100 m
        /// </summary>
        From50To100Meters = 1,

        /// <summary>
        /// 100 to 200 m
        /// </summary>
        From100To200Meters = 2,

        /// <summary>
        /// 200 to 300 m
        /// </summary>
        From200To300Meters = 3,

        /// <summary>
        /// 300 to 600 m
        /// </summary>
        From300To600Meters = 4,

        /// <summary>
        /// 600 to 1 000 m
        /// </summary>
        From600To1000Meters = 5,

        /// <summary>
        /// 1 000 to 1 500 m
        /// </summary>
        From1000To1500Meters = 6,

        /// <summary>
        /// 1 500 to 2 000 m
        /// </summary>
        From1500To2000Meters = 7,

        /// <summary>
        /// 2 000 to 2 500 m
        /// </summary>
        From2000To2500Meters = 8,

        /// <summary>
        /// 2 500 m or more, or no clouds
        /// </summary>
        From2500MetersOrNoClouds = 9
    }
}
