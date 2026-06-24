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
        /// Проверяет, что свойства SideA, SideB и SideC сохраняют и
        /// возвращают заданные значения.
        /// </summary>
        [Test(Description = "Проверяет, что свойства SideA, SideB и SideC " +
            "сохраняют и возвращают заданные значения.")]
        public void Properties_SetValues_GetReturnsSameValues()
        {
            //TODO: to const+
            const double sideA = 3.0;
            const double sideB = 4.0;
            const double sideC = 5.0;

            var data = new TriangleData();

            data.SideA = sideA;
            data.SideB = sideB;
            data.SideC = sideC;

            Assert.That(data.SideA, Is.EqualTo(sideA));
            Assert.That(data.SideB, Is.EqualTo(sideB));
            Assert.That(data.SideC, Is.EqualTo(sideC));
        }
    }
}