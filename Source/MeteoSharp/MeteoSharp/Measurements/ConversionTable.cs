using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace MeteoSharp.Measurements
{
    internal class ConversionTable<TMeasurement, TUnit>
        where TMeasurement : struct, IMeasurement<TUnit>
        where TUnit : struct
    {
        private readonly Dictionary<(TUnit from, TUnit to), decimal> _conversions = new Dictionary<(TUnit from, TUnit to), decimal>();

        public decimal this[TUnit from, TUnit to]
        {
            get => from.Equals(to) ? 1m : _conversions[(from, to)];
            set
            {
                if (!from.Equals(to))
                {
                    _conversions[(from, to)] = value;
                    _conversions[(to, from)] = 1 / value;
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
    }
}
