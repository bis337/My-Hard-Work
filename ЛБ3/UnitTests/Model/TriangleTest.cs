using System;
using NUnit.Framework;
using Model;

namespace UnitTests.Model
{
    /// <summary>
    /// Набор тестов для класса Triangle.
    /// </summary>
    [TestFixture]
    public class TriangleTest
    {
        [TestCase(3.0, 4.0, 5.0,
            TestName = "Создание прямоугольного треугольника 3-4-5.")]
        [TestCase(1.0, 1.0, 1.0,
            TestName = "Создание равностороннего треугольника 1-1-1.")]
        [TestCase(5.0, 5.0, 8.0,
            TestName = "Создание равнобедренного треугольника 5-5-8.")]
        [TestCase(0.001, 0.001, 0.001,
            TestName = "Создание треугольника с минимальными сторонами 0.001.")]
        [TestCase(10.0, 10.0, 10.0,
            TestName = "Создание равностороннего треугольника 10-10-10.")]
        public void Constructor_ValidSides_SetsSides(
            double sideA, double sideB, double sideC)
        {
            var triangle = new Triangle(sideA, sideB, sideC);
            Assert.That(triangle.SideA, Is.EqualTo(sideA));
            Assert.That(triangle.SideB, Is.EqualTo(sideB));
            Assert.That(triangle.SideC, Is.EqualTo(sideC));
        }

        [TestCase(0.0, 1.0, 1.0,
            TestName = "Сторона A = 0 вызывает ArgumentOutOfRangeException.")]
        [TestCase(-1.0, 1.0, 1.0,
            TestName = "Сторона A = -1 вызывает ArgumentOutOfRangeException.")]
        [TestCase(double.MinValue, 1.0, 1.0,
            TestName = "Сторона A = MinValue вызывает ArgumentOutOfRangeException.")]
        [TestCase(1.0, 0.0, 1.0,
            TestName = "Сторона B = 0 вызывает ArgumentOutOfRangeException.")]
        [TestCase(1.0, -1.0, 1.0,
            TestName = "Сторона B = -1 вызывает ArgumentOutOfRangeException.")]
        [TestCase(1.0, 1.0, 0.0,
            TestName = "Сторона C = 0 вызывает ArgumentOutOfRangeException.")]
        [TestCase(1.0, 1.0, -1.0,
            TestName = "Сторона C = -1 вызывает ArgumentOutOfRangeException.")]
        public void Constructor_NonPositiveSide_ThrowsArgumentOutOfRangeException(
            double sideA, double sideB, double sideC)
        {
            Assert.Throws<ArgumentOutOfRangeException>(
                () => new Triangle(sideA, sideB, sideC));
        }

        [TestCase(1.0, 1.0, 3.0,
            TestName = "A+B<=C: треугольник не существует (1,1,3).")]
        [TestCase(1.0, 3.0, 1.0,
            TestName = "A+C<=B: треугольник не существует (1,3,1).")]
        [TestCase(3.0, 1.0, 1.0,
            TestName = "B+C<=A: треугольник не существует (3,1,1).")]
        [TestCase(1.0, 2.0, 10.0,
            TestName = "Стороны 1-2-10: треугольник не существует.")]
        [TestCase(10.0, 1.0, 1.0,
            TestName = "Стороны 10-1-1: треугольник не существует.")]
        public void Constructor_TriangleInequalityViolated_ThrowsArgumentException(
            double sideA, double sideB, double sideC)
        {
            Assert.Throws<ArgumentException>(
                () => new Triangle(sideA, sideB, sideC));
        }

        [Test]
        public void Name_Always_ReturnsТреугольник()
        {
            var triangle = new Triangle(3.0, 4.0, 5.0);
            Assert.That(triangle.Name, Is.EqualTo("Треугольник"));
        }

        [TestCase(3.0, 4.0, 5.0, 6.0,
            TestName = "Площадь прямоугольного треугольника 3-4-5 = 6.")]
        [TestCase(5.0, 5.0, 6.0, 12.0,
            TestName = "Площадь треугольника 5-5-6 = 12.")]
        [TestCase(6.0, 8.0, 10.0, 24.0,
            TestName = "Площадь прямоугольного треугольника 6-8-10 = 24.")]
        [TestCase(5.0, 12.0, 13.0, 30.0,
            TestName = "Площадь прямоугольного треугольника 5-12-13 = 30.")]
        [TestCase(7.0, 24.0, 25.0, 84.0,
            TestName = "Площадь прямоугольного треугольника 7-24-25 = 84.")]
        public void CalculateArea_ValidSides_ReturnsCorrectArea(
            double sideA, double sideB, double sideC, double expectedArea)
        {
            var triangle = new Triangle(sideA, sideB, sideC);
            Assert.That(triangle.CalculateArea(),
                Is.EqualTo(expectedArea).Within(1e-10));
        }

        [TestCase(3.0, 4.0, 5.0, 12.0,
            TestName = "Периметр треугольника 3-4-5 = 12.")]
        [TestCase(1.0, 1.0, 1.0, 3.0,
            TestName = "Периметр равностороннего треугольника 1-1-1 = 3.")]
        [TestCase(5.0, 5.0, 8.0, 18.0,
            TestName = "Периметр равнобедренного треугольника 5-5-8 = 18.")]
        [TestCase(6.0, 8.0, 10.0, 24.0,
            TestName = "Периметр треугольника 6-8-10 = 24.")]
        [TestCase(2.0, 3.0, 4.0, 9.0,
            TestName = "Периметр треугольника 2-3-4 = 9.")]
        public void CalculatePerimeter_ValidSides_ReturnsCorrectPerimeter(
            double sideA, double sideB, double sideC, double expectedPerimeter)
        {
            var triangle = new Triangle(sideA, sideB, sideC);
            Assert.That(triangle.CalculatePerimeter(),
                Is.EqualTo(expectedPerimeter).Within(1e-10));
        }

        [TestCase(3.0, 4.0, 5.0,
            TestName = "ToString для треугольника 3-4-5.")]
        [TestCase(1.0, 1.0, 1.0,
            TestName = "ToString для треугольника 1-1-1.")]
        [TestCase(2.5, 3.5, 4.5,
            TestName = "ToString для треугольника 2.5-3.5-4.5.")]
        [TestCase(5.0, 5.0, 8.0,
            TestName = "ToString для равнобедренного треугольника 5-5-8.")]
        [TestCase(6.0, 8.0, 10.0,
            TestName = "ToString для треугольника 6-8-10.")]
        public void ToString_ValidSides_ReturnsCorrectString(
            double sideA, double sideB, double sideC)
        {
            var triangle = new Triangle(sideA, sideB, sideC);
            string a = sideA.ToString(Constants.FormatPrecision);
            string b = sideB.ToString(Constants.FormatPrecision);
            string c = sideC.ToString(Constants.FormatPrecision);
            string expected = $"Треугольник с сторонами {a}, {b}, {c}";
            Assert.That(triangle.ToString(), Is.EqualTo(expected));
        }
    }
}
