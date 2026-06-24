using NUnit.Framework;
using Model;

namespace UnitTests.Model
{
    /// <summary>
    /// Набор тестов для класса TriangleData.
    /// </summary>
    [TestFixture]
    public class TriangleDataTest
    {
        /// <summary>
        /// Значение первой стороны треугольника.
        /// </summary>
        private const double SideA = 3.0;

        /// <summary>
        /// Значение второй стороны треугольника.
        /// </summary>
        private const double SideB = 4.0;

        /// <summary>
        /// Значение третьей стороны треугольника.
        /// </summary>
        private const double SideC = 5.0;

        /// <summary>
        /// Проверяет, что свойства SideA, SideB и SideC сохраняют и 
        /// возвращают заданные значения.
        /// </summary>
        [Test(Description = "Проверяет, что свойства SideA, SideB и SideC " +
            "сохраняют и возвращают заданные значения.")]
        public void Properties_SetValues_GetReturnsSameValues()
        {
            var data = new TriangleData();

            //TODO: to const
            data.SideA = SideA;
            data.SideB = SideB;
            data.SideC = SideC;

            Assert.That(data.SideA, Is.EqualTo(SideA));
            Assert.That(data.SideB, Is.EqualTo(SideB));
            Assert.That(data.SideC, Is.EqualTo(SideC));
        }
    }
}