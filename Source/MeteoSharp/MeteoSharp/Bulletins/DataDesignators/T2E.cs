namespace MeteoSharp.Bulletins.DataDesignators
{
    /// <summary>
    /// T2 Designator for T1 = E
    /// </summary>
    public enum T2E : byte
    {
        /// <summary>
        /// Invalid value
        /// </summary>
        Invalid = 0,

        /// <summary>
        /// Cloud top temperature
        /// </summary>
        CloudTopTemperature = (byte) 'C',

        /// <summary>
        /// Fog
        /// </summary>
        Fog = (byte) 'F',

        /// <summary>
        /// Infrared
        /// </summary>
        Infrared = (byte) 'I',

        /// <summary>
        /// Surface temperature
        /// </summary>
        SurfaceTemperature = (byte) 'S',

        /// <summary>
        /// Visible
        /// </summary>
        Visible = (byte) 'V',

        /// <summary>
        /// Water vapour
        /// </summary>
        WaterVapour = (byte) 'W',

        /// <summary>
        /// User specified
        /// </summary>
        UserSpecified = (byte) 'Y',

        /// <summary>
        /// Unspecified
        /// </summary>
        Unspecified = (byte) 'Z'
    }
}
