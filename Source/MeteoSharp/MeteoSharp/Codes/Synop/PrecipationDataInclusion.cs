using System;
using System.Collections.Generic;
using System.Text;

namespace MeteoSharp.Codes.Synop
{
    /// <summary>
    /// Code table 1819: Indicator for inclusion or omission of precipitation data
    /// </summary>
    public enum PrecipationDataInclusion : byte
    {
        /// <summary>
        /// Included in Sections 1 and 3
        /// </summary>
        Sections1And3 = 0,
        
        /// <summary>
        /// Included in Section 1
        /// </summary>
        Section1 = 1,

        /// <summary>
        /// Included in Section 3
        /// </summary>
        Section3 = 2,

        /// <summary>
        /// Omitted (precipitation amount = 0)
        /// </summary>
        NoPrecipation = 3,

        /// <summary>
        /// Omitted (precipitation amount not available)
        /// </summary>
        NotAvailable = 4
    }
}
