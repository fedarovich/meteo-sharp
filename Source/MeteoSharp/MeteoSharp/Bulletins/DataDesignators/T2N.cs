using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using MeteoSharp.Attibutes;

namespace MeteoSharp.Bulletins.DataDesignators
{
    /// <summary>
    /// T2 Designator for T1 = N (Notices)
    /// </summary>
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public enum T2N : byte
    {
        /// <summary>
        /// Invalid value
        /// </summary>
        Invalid = 0,

        /// <summary>
        /// Hydrological
        /// </summary>
        [Text] Hydrological = (byte) 'G',

        /// <summary>
        /// Marine
        /// </summary>
        [Text] Marine = (byte) 'H',

        /// <summary>
        /// Nuclear emergency response
        /// </summary>
        [Text] NuclearEmergencyResponse = (byte) 'N',

        /// <summary>
        /// METNO/WIFMA
        /// </summary>
        /// <seealso cref="WIFMA"/>
        [Text] METNO = (byte) 'O',

        /// <summary>
        /// METNO/WIFMA
        /// </summary>
        /// <seealso cref="METNO"/>
        [Text] WIFMA = (byte)'O',

        /// <summary>
        /// Product generation delay
        /// </summary>
        [Text] ProductGenerationDelay = (byte) 'P',

        /// <summary>
        /// TEST MSG [System related]
        /// </summary>
        [Text] TestMessage = (byte) 'T',

        /// <summary>
        /// Warning related and/or cancellation
        /// </summary>
        [Text] WarningRelatedAndOrCancellation = (byte) 'W',
    }
}
