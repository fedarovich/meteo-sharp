using System;
using System.Collections.Generic;
using System.Text;
using MeteoSharp.Attibutes;
using static MeteoSharp.Codes.CodeForm;

namespace MeteoSharp.Bulletins.DataDesignators
{
    /// <summary>
    /// T2 Designator for T1 = A (Analysis)
    /// </summary>
    public enum T2A : byte
    {
        /// <summary>
        /// Invalid
        /// </summary>
        Invalid = 0,

        /// <summary>
        /// Cyclone
        /// </summary>
        [Text] Cyclone = (byte)'C',
        /// <summary>
        /// Hydrological/marine
        /// </summary>
        [Text] HydrologicalMarine = (byte)'G',
        /// <summary>
        /// Thickness
        /// </summary>
        [Text] Thickness = (byte)'H',
        /// <summary>
        /// Ice
        /// </summary>
        [CodeForm(ICEAN)] Ice = (byte)'I',
        /// <summary>
        /// Ozone layer
        /// </summary>
        [Text] OzoneLayer = (byte)'O',
        /// <summary>
        /// Radar
        /// </summary>
        [Text] Radar = (byte)'R',
        /// <summary>
        /// Surface
        /// </summary>
        [CodeForm(IAC), CodeForm(IAC_FLEET)] Surface = (byte)'S',
        /// <summary>
        /// Upper air
        /// </summary>
        [CodeForm(IAC)] UpperAir = (byte)'U',
        /// <summary>
        /// Weather summary
        /// </summary>
        [Text] WeatherSummary = (byte)'W',
        /// <summary>
        /// Miscellaneous
        /// </summary>
        [Text] Miscellaneous = (byte)'X'
    }
}
