using System.Diagnostics.CodeAnalysis;
using MeteoSharp.Attibutes;
using static MeteoSharp.Codes.CodeForm;

namespace MeteoSharp.Bulletins.DataDesignators
{
    /// <summary>
    /// T2 Designator for T1 = F (Forecasts)
    /// </summary>
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public enum T2F : byte
    {
        /// <summary>
        /// Invalid value
        /// </summary>
        Invalid = 0,

        /// <summary>
        /// Aviation area/GAMET/advisories
        /// </summary>
        /// <seealso cref="GAMET"/>
        [CodeForm(ARFOR)] AviationArea = (byte)'A',
        /// <summary>
        /// Aviation area/GAMET/advisories
        /// </summary>
        /// <seealso cref="AviationArea"/>
        [Text] GAMET = (byte)'A',

        /// <summary>
        /// Upper winds and temperatures
        /// </summary>
        [CodeForm(WINTEM)] UpperWindsAndTemperatures = (byte)'B',

        /// <summary>
        /// Aerodrome (VT &lt; 12 hours)
        /// </summary>
        [CodeForm(TAF)] AerodromeVTLessThan12Hours = (byte)'C',

        /// <summary>
        /// Radiological trajectory dose
        /// </summary>
        [CodeForm(RADOF)] RadiologicalTrajectoryDose = (byte)'D',

        /// <summary>
        /// Extended
        /// </summary>
        [Text] Extended = (byte)'E',

        /// <summary>
        /// Shipping
        /// </summary>
        [CodeForm(IAC_FLEET)] Shipping = (byte)'F',

        /// <summary>
        /// Hydrological
        /// </summary>
        [CodeForm(HYFOR)] Hydrological = (byte)'G',

        /// <summary>
        /// Upper-air thickness
        /// </summary>
        [Text] UpperAirThickness = (byte)'H',

        /// <summary>
        /// Iceberg
        /// </summary>
        [Text] Iceberg = (byte) 'I',

        /// <summary>
        /// Radio warning service (including IUWDS data)
        /// </summary>
        [Text] RadioWarningService = (byte) 'J',

        /// <summary>
        /// Tropical cyclone advisories
        /// </summary>
        [Text] TropicalCycloneAdvisories = (byte) 'K',

        /// <summary>
        /// Local/area
        /// </summary>
        [Text] Local = (byte) 'L',

        /// <summary>
        /// Temperature extremes
        /// </summary>
        [Text] TemperatureExtremes = (byte) 'M',

        /// <summary>
        /// Guidance
        /// </summary>
        [Text] Guidance = (byte) 'O',

        /// <summary>
        /// Public
        /// </summary>
        [Text] Public = (byte) 'P',

        /// <summary>
        /// Other shipping
        /// </summary>
        [Text] OtherShipping = (byte) 'Q',

        /// <summary>
        /// Aviation route
        /// </summary>
        [CodeForm(ROFOR)] AviationRoute = (byte) 'R',

        /// <summary>
        /// Surface
        /// </summary>
        [CodeForm(IAC), CodeForm(IAC_FLEET)] Surface = (byte) 'S',

        /// <summary>
        /// Aerodrome (VT ≥ 12 hours)
        /// </summary>
        [CodeForm(TAF)] AerodromeVTGreaterThanOrEqualTo12Hours = (byte) 'T',

        /// <summary>
        /// Upper air
        /// </summary>
        [CodeForm(IAC)] UpperAir = (byte) 'U',

        /// <summary>
        /// Volcanic ash advisories
        /// </summary>
        [Text] VolcanicAshAdvisories = (byte) 'V',

        /// <summary>
        /// WinterSports
        /// </summary>
        [Text] WinterSports = (byte) 'W',

        /// <summary>
        /// Miscellaneous
        /// </summary>
        [Text] Miscellaneous = (byte) 'X',

        /// <summary>
        /// Shipping area
        /// </summary>
        [CodeForm(MAFOR)] ShippingArea = (byte) 'Z',
    }
}
