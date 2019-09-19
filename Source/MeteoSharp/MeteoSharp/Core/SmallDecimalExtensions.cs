using System;
using System.Collections.Generic;
using System.Text;

namespace MeteoSharp.Core
{
    public static class SmallDecimalExtensions
    {
        public static SmallDecimal ToSmallDecimal(this in decimal value) => new SmallDecimal(value);
    }
}
