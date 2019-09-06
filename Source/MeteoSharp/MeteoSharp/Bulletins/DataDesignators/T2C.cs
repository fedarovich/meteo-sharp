using System;
using System.Collections.Generic;
using System.Text;
using MeteoSharp.Attibutes;
using static MeteoSharp.Codes.CodeForm;

namespace MeteoSharp.Bulletins.DataDesignators
{
    /// <summary>
    /// T2 Designator for T1 = C (Climatic data)
    /// </summary>
    public enum T2C : byte
    {
        /// <summary>
        /// Invalid value
        /// </summary>
        Invalid = 0,

        /// <summary>
        /// Climatic anomalies
        /// </summary>
        [Text] ClimaticAnomalies = (byte)'A',

        /// <summary>
        /// Monthly means (upper air)
        /// </summary>
        [CodeForm(SHIP)] MonthlyMeansUpperAir = (byte)'E',

        /// <summary>
        /// Monthly means (surface)
        /// </summary>
        [CodeForm(CLIMAT_SHIP)] MonthlyMeansSurfaceH = (byte)'H',
        
        /// <summary>
        /// Monthly means (ocean areas)
        /// </summary>
        [CodeForm(NACLI)] MonthlyMeansOceanAreas = (byte)'O',
        
        /// <summary>
        /// Monthly means (surface)
        /// </summary>
        [CodeForm(CLIMAT)] MonthlyMeansSurfaceS = (byte)'S',
    }
}
