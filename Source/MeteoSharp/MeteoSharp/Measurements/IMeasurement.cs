using System;

namespace MeteoSharp.Measurements
{
    public interface IMeasurement<TUnit>
        where TUnit : struct, Enum
    {
        decimal Value { get; }

        TUnit Unit { get; }

        decimal ValueIn(TUnit unit);
    }

    public interface IMeasurement<TMeasurement, TUnit>
        : IMeasurement<TUnit>, IEquatable<TMeasurement>, IComparable<TMeasurement>, IComparable
        where TMeasurement : struct, IMeasurement<TUnit>
        where TUnit : struct, Enum
    {
        TMeasurement In(TUnit unit);
    }
}
