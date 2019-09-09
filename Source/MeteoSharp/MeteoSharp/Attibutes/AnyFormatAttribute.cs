using System;
using System.Collections.Generic;
using System.Text;

namespace MeteoSharp.Attibutes
{
    [AttributeUsage(AttributeTargets.Enum | AttributeTargets.Field)]
    public class AnyFormatAttribute : FormatAttribute
    {
        public bool AlphanumericOnly { get; set; }
    }
}
