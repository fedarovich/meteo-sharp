using System.Diagnostics.CodeAnalysis;
using MeteoSharp.Attibutes;

namespace MeteoSharp.Bulletins.DataDesignators
{
    /// <summary>
    /// T2 Designator for T1 = D, G, H, Y
    /// </summary>
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    [Text, Binary]
    public enum T2DGHY : byte
    {
        /// <summary>
        /// Invalid value
        /// </summary>
        Invalid = 0,

        /// <summary>
        /// Radar data
        /// </summary>
        RadarData = (byte)'A',

        /// <summary>
        /// Cloud
        /// </summary>
        Cloud = (byte) 'B',

        /// <summary>
        /// Vorticity
        /// </summary>
        Vorticity = (byte) 'C',

        /// <summary>
        /// Thickness (relative topography)
        /// </summary>
        Thickness = (byte) 'D',

        /// <summary>
        /// Precipitation
        /// </summary>
        Precipitation = (byte) 'E',

        /// <summary>
        /// Divergence
        /// </summary>
        Divergence = (byte) 'G',

        /// <summary>
        /// Height
        /// </summary>
        Height = (byte) 'H',

        /// <summary>
        /// Wave height + combinations
        /// </summary>
        WaveHeight = (byte) 'J',

        /// <summary>
        /// Swell height + combinations
        /// </summary>
        SwellHeight = (byte) 'K',

        /// <summary>
        /// For national use
        /// </summary>
        ForNationalUse = (byte) 'M',

        /// <summary>
        /// Radiation
        /// </summary>
        Radiation = (byte) 'N',

        /// <summary>
        /// Vertical velocity
        /// </summary>
        VerticalVelocity = (byte) 'O',

        /// <summary>
        /// Pressure
        /// </summary>
        Pressure = (byte) 'P',

        /// <summary>
        /// Wet bulb potential temperature
        /// </summary>
        WetBulbPotentialTemperature = (byte) 'Q',

        /// <summary>
        /// Relative humidity
        /// </summary>
        RelativeHumidity = (byte) 'R',

        /// <summary>
        /// Temperature
        /// </summary>
        Temperature = (byte) 'T',

        /// <summary>
        /// Eastward wind component
        /// </summary>
        EastwardWindComponent = (byte) 'U',

        /// <summary>
        /// Northward wind component
        /// </summary>
        NorthwardWindComponent = (byte) 'V',

        /// <summary>
        /// Wind
        /// </summary>
        Wind = (byte) 'W',

        /// <summary>
        /// Not assigned
        /// </summary>
        NotAssigned = (byte) 'Z',
    }
}
