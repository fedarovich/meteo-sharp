using MeteoSharp.Attibutes;

namespace MeteoSharp.Bulletins.DataDesignators
{
    /// <summary>
    /// T2 Designator for T1 = O
    /// </summary>
    [Binary]
    public enum T2O : byte
    {
        /// <summary>
        /// Invalid value
        /// </summary>
        Invalid = 0,

        /// <summary>
        /// Depth
        /// </summary>
        Depth = (byte) 'D',

        /// <summary>
        /// Ice concentration
        /// </summary>
        IceConcentration = (byte) 'E',

        /// <summary>
        /// Ice thickness
        /// </summary>
        IceThickness = (byte) 'F',

        /// <summary>
        /// Ice drift
        /// </summary>
        IceDrift = (byte) 'G',

        /// <summary>
        /// Ice growth
        /// </summary>
        IceGrowth = (byte) 'H',

        /// <summary>
        /// Ice convergence/divergence
        /// </summary>
        IceConvergenceDivergence = (byte) 'I',

        /// <summary>
        /// Temperature anomaly
        /// </summary>
        TemperatureAnomaly = (byte) 'Q',

        /// <summary>
        /// Depth anomaly
        /// </summary>
        DepthAnomaly = (byte) 'R',

        /// <summary>
        /// Salinity
        /// </summary>
        Salinity = (byte) 'S',

        /// <summary>
        /// Temperature
        /// </summary>
        Temperature = (byte) 'T',

        /// <summary>
        /// Current component
        /// </summary>
        CurrentComponentU = (byte) 'U',

        /// <summary>
        /// Current component
        /// </summary>
        CurrentComponentV = (byte)'V',

        /// <summary>
        /// Temperature warming
        /// </summary>
        TemperatureWarming = (byte) 'W',

        /// <summary>
        /// Mixed data
        /// </summary>
        MixedData = (byte) 'X'
    }
}
