using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using MeteoSharp.Attibutes;

namespace MeteoSharp.Bulletins.DataDesignators
{
    /// <summary>
    /// T2 Designator for T1 = L (Aviation information in XML)
    /// </summary>
    [Xml]
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public enum T2L
    {
        /// <summary>
        /// Invalid value
        /// </summary>
        Invalid = 0,

        /// <summary>
        /// Aviation routine reports ("METAR")
        /// </summary>
        AviationRoutineReports = (byte) 'A',

        /// <summary>
        /// Aerodrome Forecast ("TAF") (VT &lt; 12 hours)
        /// </summary>
        AerodromeForecastVTLessThan12Hours = (byte) 'C',

        /// <summary>
        /// Tropical cyclone advisories
        /// </summary>
        TropicalCycloneAdvisories = (byte) 'K',

        /// <summary>
        /// Special aviation weather reports
        /// </summary>
        SpecialAviationWeatherReports = (byte) 'P',

        /// <summary>
        /// Aviation general warning ("SIGMET")
        /// </summary>
        AviationGeneralWarning = (byte) 'S',

        /// <summary>
        /// Aerodrome forecast ("TAF")) (VT ≥ 12 hours) 
        /// </summary>
        AerodromeVTGreaterThanOrEqualTo12Hours = (byte) 'T',

        /// <summary>
        /// Volcanic ash advisory 
        /// </summary>
        VolcanicAshAdvisory  = (byte) 'U',

        /// <summary>
        /// Aviation volcanic ash warning ("SIGMET")
        /// </summary>
        AviationVolcanicAshWarning = (byte) 'V',

        /// <summary>
        /// AIRMET
        /// </summary>
        AIRMET = (byte) 'W',

        /// <summary>
        /// Aviation tropical cyclone warning ("SIGMET")
        /// </summary>
        AviationTropicalCycloneWarning = (byte) 'Y',
    }
}
