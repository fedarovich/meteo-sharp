using System;
using System.Collections.Generic;
using System.Text;
using MeteoSharp.Measurements;
using NUnit.Framework;

namespace MeteoSharp.Tests.Measurements
{
    [TestFixture(TestOf = typeof(Length))]
    [Parallelizable(ParallelScope.All)]
    public class LengthTest
    {
        private static readonly Length[] UnitLengths = 
        {
            Length.Meter,
            Length.Kilometer,
            Length.Foot,
            Length.StatuteMile, 
            Length.NauticalMile
        };

        [Test]
        public void Constructor(
            [Values(-5.45, -3, 0, 5, 12.4)] decimal value, 
            [Values] LengthUnit unit)
        {
            Length length = new Length(value, unit);
            Assert.That(length.Value, Is.EqualTo(value));
            Assert.That(length.Unit, Is.EqualTo(unit));
        }

        [Test]
        public void FromTuple(
            [Values(-5.45, -3, 0, 5, 12.4)] decimal value,
            [Values] LengthUnit unit)
        {
            Length length = (value, unit);
            Assert.That(length.Value, Is.EqualTo(value));
            Assert.That(length.Unit, Is.EqualTo(unit));
        }

        [Test]
        public void FromTuple(
            [Values(-3, 0, 5)] int value,
            [Values] LengthUnit unit)
        {
            Length length = (value, unit);
            Assert.That(length.Value, Is.EqualTo(value));
            Assert.That(length.Unit, Is.EqualTo(unit));
        }

        [Test]
        public void Add(
            [Values(-5.45, 0, 5)] decimal value1, 
            [Values(-5, 8)] decimal value2,
            [Values] LengthUnit unit)
        {
            Length len1 = new Length(value1, unit);
            Length len2 = new Length(value2, unit);
            Length sum = len1 + len2;
            Assert.That(sum.Value, Is.EqualTo(value1 + value2));
            Assert.That(sum.Unit, Is.EqualTo(unit));
        }

        [Test]
        public void Add(
            [ValueSource(nameof(UnitLengths))] Length len1,
            [ValueSource(nameof(UnitLengths))] Length len2)
        {
            Length sum = len1 + len2;
            Assert.That(sum.Value, Is.EqualTo(len1.Value + len2.ValueIn(len1.Unit)));
            Assert.That(sum.Unit, Is.EqualTo(len1.Unit));
        }

        [Test]
        public void AddAssign(
            [ValueSource(nameof(UnitLengths))] Length len1,
            [ValueSource(nameof(UnitLengths))] Length len2)
        {
            Length original = len1;
            len1 += len2;
            Assert.That(len1.Value, Is.EqualTo(original.Value + len2.ValueIn(original.Unit)));
            Assert.That(len1.Unit, Is.EqualTo(original.Unit));
        }

        [Test]
        public void Subtract(
            [Values(-5.45, 0, 5)] decimal value1,
            [Values(-5, 8)] decimal value2,
            [Values] LengthUnit unit)
        {
            Length len1 = new Length(value1, unit);
            Length len2 = new Length(value2, unit);
            Length diff = len1 - len2;
            Assert.That(diff.Value, Is.EqualTo(value1 - value2));
            Assert.That(diff.Unit, Is.EqualTo(unit));
        }

        [Test]
        public void Subtract(
            [ValueSource(nameof(UnitLengths))] Length len1,
            [ValueSource(nameof(UnitLengths))] Length len2)
        {
            Length sum = len1 - len2;
            Assert.That(sum.Value, Is.EqualTo(len1.Value - len2.ValueIn(len1.Unit)));
            Assert.That(sum.Unit, Is.EqualTo(len1.Unit));
        }

        [Test]
        public void SubtractAssign(
            [ValueSource(nameof(UnitLengths))] Length len1,
            [ValueSource(nameof(UnitLengths))] Length len2)
        {
            Length original = len1;
            len1 += len2;
            Assert.That(len1.Value, Is.EqualTo(original.Value + len2.ValueIn(original.Unit)));
            Assert.That(len1.Unit, Is.EqualTo(original.Unit));
        }

        [Test]
        public void Multiply(
            [Values(-5.45, -3, 0, 5, 12.4)] decimal value,
            [ValueSource(nameof(UnitLengths))] Length unitLength)
        {
            Length length = value * unitLength;
            Assert.That(length.Value, Is.EqualTo(value));
            Assert.That(length.Unit, Is.EqualTo(unitLength.Unit));
        }

        [Test]
        public void Multiply(
            [Values(-3, 0, 5)] int value,
            [ValueSource(nameof(UnitLengths))] Length unitLength)
        {
            Length length = value * unitLength;
            Assert.That(length.Value, Is.EqualTo(value));
            Assert.That(length.Unit, Is.EqualTo(unitLength.Unit));
        }

        [Test]
        public void Multiply(
            [ValueSource(nameof(UnitLengths))] Length unitLength,
            [Values(-5.45, -3, 0, 5, 12.4)] decimal value)
        {
            Length length = unitLength * value;
            Assert.That(length.Value, Is.EqualTo(value));
            Assert.That(length.Unit, Is.EqualTo(unitLength.Unit));
        }

        [Test]
        public void Multiply(
            [ValueSource(nameof(UnitLengths))] Length unitLength,
            [Values(-3, 0, 5)] int value)
        {
            Length length = unitLength * value;
            Assert.That(length.Value, Is.EqualTo(value));
            Assert.That(length.Unit, Is.EqualTo(unitLength.Unit));
        }

        [Test]
        public void MultiplyAssign(
            [ValueSource(nameof(UnitLengths))] Length length,
            [Values(-5.45, -3, 0, 5, 12.4)] decimal value)
        {
            var originalUnit = length.Unit;
            length *= value;
            Assert.That(length.Value, Is.EqualTo(value));
            Assert.That(length.Unit, Is.EqualTo(originalUnit));
        }

        [Test]
        public void MultiplyAssign(
            [ValueSource(nameof(UnitLengths))] Length length,
            [Values(-3, 0, 5)] int value)
        {
            var originalUnit = length.Unit;
            length *= value;
            Assert.That(length.Value, Is.EqualTo(value));
            Assert.That(length.Unit, Is.EqualTo(originalUnit));
        }

        [Test]
        public void In(
            [Values] LengthUnit unit1,
            [Values] LengthUnit unit2,
            [Values] LengthUnit unit3)
        {
            var len1 = new Length(2.5m, unit1);
            var len2 = len1.In(unit2);
            var len3 = len1.In(unit3);
            var len23 = len2.In(unit3);

            var err = Math.Abs(len23.Value - len3.Value) / len3.Value;
            Assert.That(err, Is.LessThan(1e-8m));
            Assert.That(len23.Unit, Is.EqualTo(len3.Unit));
        }

        [Test]
        public void ValueIn(
            [Values] LengthUnit unit1,
            [Values] LengthUnit unit2,
            [Values] LengthUnit unit3)
        {
            var len = new Length(2.5m, unit1);
            var val3 = len.ValueIn(unit3);
            var val23 = len.In(unit2).ValueIn(unit3);

            var err = Math.Abs(val23 - val3) / val3;
            Assert.That(err, Is.LessThan(1e-8m));
        }
    }
}
