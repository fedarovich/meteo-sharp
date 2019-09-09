using System;
using System.Collections.Generic;
using System.Text;

namespace MeteoSharp.Attibutes
{
    [AttributeUsage(AttributeTargets.Enum | AttributeTargets.Field)]
    public class XmlAttribute : FormatAttribute
    {
    }
}
