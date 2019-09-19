using System;
using MeteoSharp.Core;

namespace MeteoSharp.Measurements
{
    public interface IMeasurement<TUnit>
        where TUnit : struct, Enum
    {
        SmallDecimal Value { get; }

        TUnit Unit { get; }

        SmallDecimal ValueIn(TUnit unit);
    }

    public interface IMeasurement<TMeasurement, TUnit>
        : IMeasurement<TUnit>, IEquatable<TMeasurement>, IComparable<TMeasurement>, IComparable
        where TMeasurement : struct, IMeasurement<TUnit>
        where TUnit : struct, Enum
    {
        TMeasurement In(TUnit unit);
    }
}
