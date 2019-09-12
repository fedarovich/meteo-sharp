using System;
using System.Collections.Generic;
using System.Text;

namespace MeteoSharp.Readers
{
    /// <summary>
    /// Controls whether XML reports must be automatically parsed during reading.
    /// </summary>
    public enum XmlParsingBehavior : byte
    {
        /// <summary>
        /// Parse XML reports and throw exception if XML cannot be parsed.
        /// </summary>
        Parse,
        /// <summary>
        /// Parse XML reports and return raw text if XML cannot be parsed.
        /// </summary>
        ParseIgnoreErrors,
        /// <summary>
        /// Do not parse XML reports but return them as raw text.
        /// </summary>
        DoNotParse
    }
}
