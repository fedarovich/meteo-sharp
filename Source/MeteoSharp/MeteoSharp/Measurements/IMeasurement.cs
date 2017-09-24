using System;
using System.Collections.Generic;
using System.Text;

namespace MeteoSharp.Measurements
{
    public interface IMeasurement<TUnit>
        where TUnit : struct
    {
        decimal Value { get; }

        TUnit Unit { get; }

        decimal ValueIn(TUnit unit);
    }

    public interface IMeasurement<TMeasurement, TUnit>
        : IMeasurement<TUnit>, IEquatable<TMeasurement>, IComparable<TMeasurement>, IComparable
        where TMeasurement : IMeasurement<TUnit>
        where TUnit : struct
    {
        TMeasurement In(TUnit unit);
    }
}
