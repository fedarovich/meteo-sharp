using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using BenchmarkDotNet.Attributes;
using MeteoSharp.Core;
using MeteoSharp.Measurements;

namespace MeteoSharp.Benchmarks.Measurements
{
    [MemoryDiagnoser]
    public class MeasurementDeconstruction
    {
        private readonly Pressure _pressure;

        public MeasurementDeconstruction()
        {
            _pressure = 760 * Pressure.MillimeterOfMercury;
        }

        [Benchmark]
        public void Deconstruct()
        {
            var (value, unit) = _pressure;
            Use(value, unit);
        }

        [Benchmark]
        public void Tuple()
        {
            var tuple = _pressure;
            Use(tuple.Value, tuple.Unit);
        }

        [Benchmark(Baseline = true)]
        public void Direct()
        {
            Use(_pressure.Value, _pressure.Unit);
        }

        [MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
        private void Use(in SmallDecimal value, PressureUnit unit)
        {
        }
    }
}
