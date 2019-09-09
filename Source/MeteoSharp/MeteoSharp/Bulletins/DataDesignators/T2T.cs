using MeteoSharp.Attibutes;
using static MeteoSharp.Codes.CodeForm;

namespace MeteoSharp.Bulletins.DataDesignators
{
    /// <summary>
    /// T2 Designator for T1 = T (Satellite data)
    /// </summary>
    public enum T2T : byte
    {
        /// <summary>
        /// Invalid value
        /// </summary>
        Invalid = 0,

        /// <summary>
        /// Satellite orbit parameters
        /// </summary>
        [Text] SatelliteOrbitParameters = (byte) 'B',

        /// <summary>
        /// Satellite cloud interpretations
        /// </summary>
        [CodeForm(SAREP)] SatelliteCloudInterpretations = (byte) 'C',

        /// <summary>
        /// Satellite remote upper-air soundings
        /// </summary>
        [CodeForm(SATEM)] SatelliteRemoteUpperAirSoundings = (byte) 'H',

        /// <summary>
        /// Clear radiance observations
        /// </summary>
        [CodeForm(SARAD)] ClearRadianceObservations = (byte) 'R',

        /// <summary>
        /// Sea surface temperatures
        /// </summary>
        [CodeForm(SATOB)] SeaSurfaceTemperatures = (byte) 'T',

        /// <summary>
        /// Winds and cloud temperatures
        /// </summary>
        [CodeForm(SATOB)] WindsAndCloudTemperatures = (byte) 'W',

        /// <summary>
        /// Miscellaneous
        /// </summary>
        [Text] Miscellaneous = (byte) 'X'
    }
}
