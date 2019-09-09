using System.Diagnostics.CodeAnalysis;
using MeteoSharp.Attibutes;

namespace MeteoSharp.Bulletins.DataDesignators
{
    /// <summary>
    /// T2 Designator for T1 = I, J
    /// </summary>
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    [Binary]
    public enum T2IJ : byte
    {
        /// <summary>
        /// Invalid value
        /// </summary>
        Invalid = 0,

        /// <summary>
        /// Satellite data
        /// </summary>
        SatelliteData = (byte) 'N',

        /// <summary>
        /// Oceanographic/limnographic (water property)
        /// </summary>
        OceanographicLimnographic = (byte) 'O',

        /// <summary>
        /// Pictorial
        /// </summary>
        Pictorial = (byte) 'P',

        /// <summary>
        /// Surface/sea level
        /// </summary>
        SurfaceSeaLevel = (byte) 'S',

        /// <summary>
        /// Text (plain language information)
        /// </summary>
        Text = (byte) 'T',

        /// <summary>
        /// Upper-air data
        /// </summary>
        UpperAirData = (byte) 'U',

        /// <summary>
        /// Other data types
        /// </summary>
        Other = (byte) 'X',
    }
}
