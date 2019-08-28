using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using BenchmarkDotNet.Attributes;
using MeteoSharp.Measurements;

namespace MeteoSharp.Benchmarks.Measurements
{
    public class MeasurementConversion
    {
        private Pressure _pressure;

        public MeasurementConversion()
        {
            _pressure = 760 * Pressure.MillimeterOfMercury;
        }

        [Benchmark]
        [MethodImpl(MethodImplOptions.NoOptimization)]
        public void Convert()
        {
            _pressure.ValueIn(PressureUnit.HektoPascal);
        }
    }
}
