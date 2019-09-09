using System.Diagnostics.CodeAnalysis;
using MeteoSharp.Attibutes;

namespace MeteoSharp.Bulletins.DataDesignators
{
    /// <summary>
    /// T2 Designator for T1 = W (Warnings)
    /// </summary>
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public enum T2W : byte
    {
        /// <summary>
        /// Invalid value
        /// </summary>
        Invalid = 0,

        /// <summary>
        /// AIRMET
        /// </summary>
        [Text] AIRMET = (byte) 'A',

        /// <summary>
        /// Tropical cyclone (SIGMET)
        /// </summary>
        [Text] TropicalCycloneSIGMET = (byte) 'C',

        /// <summary>
        /// Tsunami
        /// </summary>
        [Text] Tsunami = (byte) 'E',

        /// <summary>
        /// Tornado
        /// </summary>
        [Text] Tornado = (byte) 'F',

        /// <summary>
        /// Hydrological/river flood
        /// </summary>
        [Text] HydrologicalRiverFlood = (byte) 'G',

        /// <summary>
        /// Marine/coastal flood
        /// </summary>
        [Text] MarineCoastalFlood = (byte) 'H',

        /// <summary>
        /// Other
        /// </summary>
        [Text] Other = (byte) 'O',

        /// <summary>
        /// Humanitarian activities
        /// </summary>
        [AnyFormat] HumanitarianActivities = (byte) 'R',

        /// <summary>
        /// SIGMET
        /// </summary>
        [Text] SIGMET = (byte) 'S',

        /// <summary>
        /// Tropical cyclone (Typhoon/hurricane)
        /// </summary>
        [Text] TropicalCycloneTyphoonHurricane = (byte) 'T',

        /// <summary>
        /// Severe thunderstorm
        /// </summary>
        [Text] SevereThunderstorm = (byte) 'U',

        /// <summary>
        /// Volcanic ash clouds (SIGMET)
        /// </summary>
        [Text] VolcanicAshCloudsSIGMET = (byte) 'V',

        /// <summary>
        /// Warnings and weather summary
        /// </summary>
        [Text] WarningsAndWeatherSummary = (byte) 'W',


    }
}
