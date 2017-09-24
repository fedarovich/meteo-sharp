using System;
using System.Collections.Generic;
using System.Text;

namespace MeteoSharp.Measurements
{
    public static class MeasurementExtensions
    {
        public static void Deconstruct<TUnit>(this IMeasurement<TUnit> measuremnt, out decimal value, out TUnit unit)
            where TUnit : struct
        {
            value = measuremnt.Value;
            unit = measuremnt.Unit;
        }
    }
}
