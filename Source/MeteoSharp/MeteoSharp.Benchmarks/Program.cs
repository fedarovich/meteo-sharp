using System;
using BenchmarkDotNet.Running;
using MeteoSharp.Benchmarks.Measurements;

namespace MeteoSharp.Benchmarks
{
    class Program
    {
        static void Main(string[] args)
        {
            BenchmarkRunner.Run<MeasurementConversion>();
        }
    }
}
