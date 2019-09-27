using System;
using System.Collections.Generic;
using System.Text;

namespace MeteoSharp.Codes.Synop
{
    /// <summary>
    /// Code table 1860: Indicator for type of station operation (manned or automatic) and for present and past
    /// weather data
    /// </summary>
    public enum StationOperationAndWeatherData : byte
    {
        /// <summary>
        /// Invalid value
        /// </summary>
        Invalid = 0,

        /// <summary>
        /// Manned station operation. Weather data is included.
        /// </summary>
        MannedIncluded = 1,

        /// <summary>
        /// Manned station operation. Weather data is omitted (no significant phenomenon to report).
        /// </summary>
        MannedNoSignificantPhenomenon = 2,

        /// <summary>
        /// Manned station operation. Weather data is omitted (no observation, data not available).
        /// </summary>
        MannedDataNotAvailable = 3,

        /// <summary>
        /// Automatic station operation. Weather data is included using Code tables 4677 and 4561.
        /// </summary>
        AutomaticCodeTables4677And4561 = 4,

        /// <summary>
        /// Automatic station operation. Weather data is omitted (no significant phenomenon to report).
        /// </summary>
        AutomaticNoSignificantPhenomenon = 5,

        /// <summary>
        /// Automatic station operation. Weather data is omitted (no observation, data not available).
        /// </summary>
        AutomaticDataNotAvailable = 6,

        /// <summary>
        /// Automatic station operation. Weather data is included using Code tables 4680 and 4531.
        /// </summary>
        AutomaticCodeTables4680And4531 = 7
    }
}
