using System;
using System.Collections.Generic;
using System.Text;
using MeteoSharp.Core;
using MeteoSharp.Measurements;
using NUnit.Framework;

namespace MeteoSharp.Tests.Measurements
{
    [TestFixture(TestOf = typeof(Pressure))]
    [Parallelizable(ParallelScope.All)]
    public class PressureTest
    {
        private static readonly Pressure[] UnitPressure =
       {
           Pressure.Pascal,
           Pressure.HektoPascal,
           Pressure.MillimeterOfMercury,
           Pressure.InchOfMercury
          };

        [Test]
        public void Constructor(
            [Values(-5.45, -3, 0, 5, 12.4)] decimal value,
            [Values] PressureUnit unit)
        {
            Pressure pressure = new Pressure(value, unit);
            Assert.That(pressure.Value, Is.EqualTo(value));
            Assert.That(pressure.Unit, Is.EqualTo(unit));
        }

        [Test]
        public void FromTuple(
            [Values(-5.45, -3, 0, 5, 12.4)] decimal value,
            [Values] PressureUnit unit)
        {
            Pressure pressure = (value, unit);
            Assert.That(pressure.Value, Is.EqualTo((SmallDecimal) value));
            Assert.That(pressure.Unit, Is.EqualTo(unit));
        }

        [Test]
        public void FromTuple(
            [Values(-3, 0, 5)] int value,
            [Values] PressureUnit unit)
        {
            Pressure pressure = (value, unit);
            Assert.That(pressure.Value, Is.EqualTo((SmallDecimal) value));
            Assert.That(pressure.Unit, Is.EqualTo(unit));
        }

        [Test]
        public void Add(
            [Values(-5.45, 0, 5)] decimal value1,
            [Values(-5, 8)] decimal value2,
            [Values] PressureUnit unit)
        {
            Pressure pres1 = new Pressure(value1, unit);
            Pressure pres2 = new Pressure(value2, unit);
            Pressure sum = pres1 + pres2;
            Assert.That(sum.Value, Is.EqualTo((SmallDecimal) (value1 + value2)));
            Assert.That(sum.Unit, Is.EqualTo(unit));
        }

        [Test]
        public void Add(
            [ValueSource(nameof(UnitPressure))] Pressure pres1,
            [ValueSource(nameof(UnitPressure))] Pressure pres2)
        {
            Pressure sum = pres1 + pres2;
            Assert.That(sum.Value, Is.EqualTo(pres1.Value + pres2.ValueIn(pres1.Unit)));
            Assert.That(sum.Unit, Is.EqualTo(pres1.Unit));
        }

        [Test]
        public void AddAssign(
            [ValueSource(nameof(UnitPressure))] Pressure pres1,
            [ValueSource(nameof(UnitPressure))] Pressure pres2)
        {
            Pressure original = pres1;
            pres1 += pres2;
            Assert.That(pres1.Value, Is.EqualTo(original.Value + pres2.ValueIn(original.Unit)));
            Assert.That(pres1.Unit, Is.EqualTo(original.Unit));
        }

        [Test]
        public void Subtract(
            [Values(-5.45, 0, 5)] decimal value1,
            [Values(-5, 8)] decimal value2,
            [Values] PressureUnit unit)
        {
            Pressure pres1 = new Pressure(value1, unit);
            Pressure pres2 = new Pressure(value2, unit);
            Pressure diff = pres1 - pres2;
            Assert.That(diff.Value, Is.EqualTo((SmallDecimal) (value1 - value2)));
            Assert.That(diff.Unit, Is.EqualTo(unit));
        }

        [Test]
        public void Subtract(
            [ValueSource(nameof(UnitPressure))] Pressure pres1,
            [ValueSource(nameof(UnitPressure))] Pressure pres2)
        {
            Pressure sum = pres1 - pres2;
            Assert.That(sum.Value, Is.EqualTo(pres1.Value - pres2.ValueIn(pres1.Unit)));
            Assert.That(sum.Unit, Is.EqualTo(pres1.Unit));
        }

        [Test]
        public void SubtractAssign(
            [ValueSource(nameof(UnitPressure))] Pressure pres1,
            [ValueSource(nameof(UnitPressure))] Pressure pres2)
        {
            Pressure original = pres1;
            pres1 += pres2;
            Assert.That(pres1.Value, Is.EqualTo(original.Value + pres2.ValueIn(original.Unit)));
            Assert.That(pres1.Unit, Is.EqualTo(original.Unit));
        }

        [Test]
        public void Multiply(
            [Values(-5.45, -3, 0, 5, 12.4)] decimal value,
            [ValueSource(nameof(UnitPressure))] Pressure unitPressure)
        {
            Pressure pressure = value * unitPressure;
            Assert.That(pressure.Value, Is.EqualTo((SmallDecimal) value));
            Assert.That(pressure.Unit, Is.EqualTo(unitPressure.Unit));
        }

        [Test]
        public void Multiply(
            [Values(-3, 0, 5)] int value,
            [ValueSource(nameof(UnitPressure))] Pressure unitPressure)
        {
            Pressure pressure = value * unitPressure;
            Assert.That(pressure.Value, Is.EqualTo((SmallDecimal) value));
            Assert.That(pressure.Unit, Is.EqualTo(unitPressure.Unit));
        }

        [Test]
        public void Multiply(
            [ValueSource(nameof(UnitPressure))] Pressure unitPressure,
            [Values(-5.45, -3, 0, 5, 12.4)] decimal value)
        {
            Pressure pressure = unitPressure * value;
            Assert.That(pressure.Value, Is.EqualTo((SmallDecimal) value));
            Assert.That(pressure.Unit, Is.EqualTo(unitPressure.Unit));
        }

        [Test]
        public void Multiply(
            [ValueSource(nameof(UnitPressure))] Pressure unitPressure,
            [Values(-3, 0, 5)] int value)
        {
            Pressure pressure = unitPressure * value;
            Assert.That(pressure.Value, Is.EqualTo((SmallDecimal) value));
            Assert.That(pressure.Unit, Is.EqualTo(unitPressure.Unit));
        }

        [Test]
        public void MultiplyAssign(
            [ValueSource(nameof(UnitPressure))] Pressure pressure,
            [Values(-5.45, -3, 0, 5, 12.4)] decimal value)
        {
            var originalUnit = pressure.Unit;
            pressure *= value;
            Assert.That(pressure.Value, Is.EqualTo((SmallDecimal) value));
            Assert.That(pressure.Unit, Is.EqualTo(originalUnit));
        }

        [Test]
        public void MultiplyAssign(
            [ValueSource(nameof(UnitPressure))] Pressure pressure,
            [Values(-3, 0, 5)] int value)
        {
            var originalUnit = pressure.Unit;
            pressure *= value;
            Assert.That(pressure.Value, Is.EqualTo((SmallDecimal) value));
            Assert.That(pressure.Unit, Is.EqualTo(originalUnit));
        }

        [Test]
        public void In(
            [Values] PressureUnit unit1,
            [Values] PressureUnit unit2,
            [Values] PressureUnit unit3)
        {
            var pres1 = new Pressure(2.5m, unit1);
            var pres2 = pres1.In(unit2);
            var pres3 = pres1.In(unit3);
            var pres23 = pres2.In(unit3);

            var err = Math.Abs(pres23.Value - pres3.Value) / pres3.Value;
            Assert.That(err.ToDecimal(), Is.LessThan(1e-7m));
            Assert.That(pres23.Unit, Is.EqualTo(pres3.Unit));
        }

        [Test]
        public void ValueIn(
            [Values] PressureUnit unit1,
            [Values] PressureUnit unit2,
            [Values] PressureUnit unit3)
        {
            var pres = new Pressure(2.5m, unit1);
            var val3 = pres.ValueIn(unit3);
            var val23 = pres.In(unit2).ValueIn(unit3);

            var err = Math.Abs(val23 - val3) / val3;
            Assert.That(err.ToDecimal(), Is.LessThan(1e-7m));
        }
    }
}
