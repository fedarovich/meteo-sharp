using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace MeteoSharp.Measurements
{
    internal class ConversionTable<TMeasurement, TUnit>
        where TMeasurement : unmanaged, IMeasurement<TUnit>
        where TUnit : unmanaged, Enum
    {
        private static readonly int Count = Enum.GetValues(typeof(TUnit)).Cast<int>().Max() + 1;

        private readonly decimal[,] _conversions;

        internal ConversionTable()
        {
            _conversions = new decimal[Count, Count];
        }

        public decimal this[TUnit from, TUnit to]
        {
            get => EqualityComparer<TUnit>.Default.Equals(from, to) ? 1m : _conversions[Index(from), Index(to)];
            set
            {
                if (!EqualityComparer<TUnit>.Default.Equals(from, to))
                {
                    int f = Index(from);
                    int t = Index(to);
                    _conversions[f, t] = value;
                    _conversions[t, f] = 1 / value;
                }
            }
        }

        public (decimal value, TUnit unit) Convert(TMeasurement measurement, TUnit targetUnit)
        {
            var factor = this[measurement.Unit, targetUnit];
            return (measurement.Value * factor, targetUnit);
        }

        public decimal ConvertValue(TMeasurement measurement, TUnit targetUnit)
        {
            var factor = this[measurement.Unit, targetUnit];
            return measurement.Value * factor;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static unsafe int Index(TUnit unit) => *(int*) &unit;
    }
}
