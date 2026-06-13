using System;
using NUnit.Framework;
using Model;

namespace UnitTests.Model
{
    /// <summary>
    /// Набор тестов для класса Circle.
    /// </summary>
    [TestFixture]
    public class CircleTest
    {
        [TestCase(1.0,
            TestName = "Создание круга с радиусом 1.")]
        [TestCase(0.001,
            TestName = "Создание круга с радиусом 0.001.")]
        [TestCase(100.0,
            TestName = "Создание круга с радиусом 100.")]
        [TestCase(1000000.0,
            TestName = "Создание круга с радиусом 1000000.")]
        [TestCase(double.Epsilon,
            TestName = "Создание круга с радиусом double.Epsilon.")]
        public void Constructor_ValidRadius_SetsRadius(double radius)
        {
            var circle = new Circle(radius);
            Assert.That(circle.Radius, Is.EqualTo(radius));
        }

        [TestCase(0.0,
            TestName = "Радиус 0 вызывает ArgumentOutOfRangeException.")]
        [TestCase(-1.0,
            TestName = "Радиус -1 вызывает ArgumentOutOfRangeException.")]
        [TestCase(-100.0,
            TestName = "Радиус -100 вызывает ArgumentOutOfRangeException.")]
        [TestCase(double.MinValue,
            TestName = "Радиус MinValue вызывает ArgumentOutOfRangeException.")]
        [TestCase(double.NegativeInfinity,
            TestName = "Радиус NegativeInfinity вызывает ArgumentOutOfRangeException.")]
        public void Constructor_InvalidRadius_ThrowsArgumentOutOfRangeException(
            double radius)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new Circle(radius));
        }

        [Test]
        public void Name_Always_ReturnsКруг()
        {
            var circle = new Circle(1.0);
            Assert.That(circle.Name, Is.EqualTo("Круг"));
        }

        [TestCase(1.0,
            TestName = "Площадь круга с радиусом 1.")]
        [TestCase(2.0,
            TestName = "Площадь круга с радиусом 2.")]
        [TestCase(5.0,
            TestName = "Площадь круга с радиусом 5.")]
        [TestCase(0.5,
            TestName = "Площадь круга с радиусом 0.5.")]
        [TestCase(10.0,
            TestName = "Площадь круга с радиусом 10.")]
        public void CalculateArea_ValidRadius_ReturnsCorrectArea(double radius)
        {
            var circle = new Circle(radius);
            double expected = Math.PI * radius * radius;
            Assert.That(circle.CalculateArea(),
                Is.EqualTo(expected).Within(1e-10));
        }

        [TestCase(1.0,
            TestName = "Периметр круга с радиусом 1.")]
        [TestCase(2.0,
            TestName = "Периметр круга с радиусом 2.")]
        [TestCase(5.0,
            TestName = "Периметр круга с радиусом 5.")]
        [TestCase(0.5,
            TestName = "Периметр круга с радиусом 0.5.")]
        [TestCase(10.0,
            TestName = "Периметр круга с радиусом 10.")]
        public void CalculatePerimeter_ValidRadius_ReturnsCorrectPerimeter(
            double radius)
        {
            var circle = new Circle(radius);
            double expected = 2 * Math.PI * radius;
            Assert.That(circle.CalculatePerimeter(),
                Is.EqualTo(expected).Within(1e-10));
        }

        [TestCase(1.0,
            TestName = "ToString для круга с радиусом 1.")]
        [TestCase(2.5,
            TestName = "ToString для круга с радиусом 2.5.")]
        [TestCase(10.0,
            TestName = "ToString для круга с радиусом 10.")]
        [TestCase(0.1,
            TestName = "ToString для круга с радиусом 0.1.")]
        [TestCase(100.0,
            TestName = "ToString для круга с радиусом 100.")]
        public void ToString_ValidRadius_ReturnsCorrectString(double radius)
        {
            var circle = new Circle(radius);
            string expected = $"Круг с радиусом " +
                $"{radius.ToString(Constants.FormatPrecision)}";
            Assert.That(circle.ToString(), Is.EqualTo(expected));
        }
    }
}
