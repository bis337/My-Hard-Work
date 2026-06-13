using System;
using NUnit.Framework;
using Model;

namespace UnitTests.Model
{
    /// <summary>
    /// Набор тестов для класса Rectangle.
    /// </summary>
    [TestFixture]
    public class RectangleTest
    {
        [TestCase(1.0, 1.0,
            TestName = "Создание прямоугольника 1x1.")]
        [TestCase(3.0, 4.0,
            TestName = "Создание прямоугольника 3x4.")]
        [TestCase(0.001, 0.001,
            TestName = "Создание прямоугольника с минимальными сторонами.")]
        [TestCase(1000.0, 2000.0,
            TestName = "Создание прямоугольника с большими сторонами.")]
        [TestCase(double.Epsilon, double.Epsilon,
            TestName = "Создание прямоугольника со сторонами double.Epsilon.")]
        public void Constructor_ValidSides_SetsWidthAndHeight(
            double width, double height)
        {
            var rect = new Rectangle(width, height);
            Assert.That(rect.Width, Is.EqualTo(width));
            Assert.That(rect.Height, Is.EqualTo(height));
        }

        [TestCase(0.0, 1.0,
            TestName = "Ширина 0 вызывает ArgumentException.")]
        [TestCase(-1.0, 1.0,
            TestName = "Ширина -1 вызывает ArgumentException.")]
        [TestCase(-100.0, 1.0,
            TestName = "Ширина -100 вызывает ArgumentException.")]
        [TestCase(double.MinValue, 1.0,
            TestName = "Ширина MinValue вызывает ArgumentException.")]
        [TestCase(double.NegativeInfinity, 1.0,
            TestName = "Ширина NegativeInfinity вызывает ArgumentException.")]
        [TestCase(double.NaN, 1.0,
            TestName = "Ширина NaN вызывает ArgumentException.")]
        [TestCase(double.PositiveInfinity, 1.0,
            TestName = "Ширина PositiveInfinity вызывает ArgumentException.")]
        public void Constructor_InvalidWidth_ThrowsArgumentException(
            double width, double height)
        {
            Assert.Throws<ArgumentException>(() => new Rectangle(width, height));
        }

        [TestCase(1.0, 0.0,
            TestName = "Высота 0 вызывает ArgumentException.")]
        [TestCase(1.0, -1.0,
            TestName = "Высота -1 вызывает ArgumentException.")]
        [TestCase(1.0, -100.0,
            TestName = "Высота -100 вызывает ArgumentException.")]
        [TestCase(1.0, double.MinValue,
            TestName = "Высота MinValue вызывает ArgumentException.")]
        [TestCase(1.0, double.NegativeInfinity,
            TestName = "Высота NegativeInfinity вызывает ArgumentException.")]
        [TestCase(1.0, double.NaN,
            TestName = "Высота NaN вызывает ArgumentException.")]
        [TestCase(1.0, double.PositiveInfinity,
            TestName = "Высота PositiveInfinity вызывает ArgumentException.")]
        public void Constructor_InvalidHeight_ThrowsArgumentException(
            double width, double height)
        {
            Assert.Throws<ArgumentException>(() => new Rectangle(width, height));
        }

        [Test]
        public void Name_Always_ReturnsПрямоугольник()
        {
            var rect = new Rectangle(1.0, 1.0);
            Assert.That(rect.Name, Is.EqualTo("Прямоугольник"));
        }

        [TestCase(3.0, 4.0,
            TestName = "Площадь прямоугольника 3x4.")]
        [TestCase(1.0, 1.0,
            TestName = "Площадь прямоугольника 1x1.")]
        [TestCase(5.0, 10.0,
            TestName = "Площадь прямоугольника 5x10.")]
        [TestCase(2.5, 4.0,
            TestName = "Площадь прямоугольника 2.5x4.")]
        [TestCase(100.0, 200.0,
            TestName = "Площадь прямоугольника 100x200.")]
        public void CalculateArea_ValidSides_ReturnsCorrectArea(
            double width, double height)
        {
            var rect = new Rectangle(width, height);
            Assert.That(rect.CalculateArea(),
                Is.EqualTo(width * height).Within(1e-10));
        }

        [TestCase(3.0, 4.0,
            TestName = "Периметр прямоугольника 3x4.")]
        [TestCase(1.0, 1.0,
            TestName = "Периметр прямоугольника 1x1.")]
        [TestCase(5.0, 10.0,
            TestName = "Периметр прямоугольника 5x10.")]
        [TestCase(2.5, 4.0,
            TestName = "Периметр прямоугольника 2.5x4.")]
        [TestCase(100.0, 200.0,
            TestName = "Периметр прямоугольника 100x200.")]
        public void CalculatePerimeter_ValidSides_ReturnsCorrectPerimeter(
            double width, double height)
        {
            var rect = new Rectangle(width, height);
            Assert.That(rect.CalculatePerimeter(),
                Is.EqualTo(2 * (width + height)).Within(1e-10));
        }

        [TestCase(3.0, 4.0,
            TestName = "ToString для прямоугольника 3x4.")]
        [TestCase(1.0, 1.0,
            TestName = "ToString для прямоугольника 1x1.")]
        [TestCase(2.5, 7.5,
            TestName = "ToString для прямоугольника 2.5x7.5.")]
        [TestCase(10.0, 20.0,
            TestName = "ToString для прямоугольника 10x20.")]
        [TestCase(0.5, 0.5,
            TestName = "ToString для прямоугольника 0.5x0.5.")]
        public void ToString_ValidSides_ReturnsCorrectString(
            double width, double height)
        {
            var rect = new Rectangle(width, height);
            string expected = $"Прямоугольник с шириной " +
                $"{width.ToString(Constants.FormatPrecision)} " +
                $"и высотой {height.ToString(Constants.FormatPrecision)}";
            Assert.That(rect.ToString(), Is.EqualTo(expected));
        }
    }
}
