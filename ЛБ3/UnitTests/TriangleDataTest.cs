using NUnit.Framework;
using Model;

namespace UnitTests.Model
{
    /// <summary>
    /// Представляет данные треугольника для сохранения и загрузки.
    /// </summary>
    [TestFixture]
    public class TriangleDataTest
    {
        [Test]
        public void SideA_SetValue_GetReturnsSameValue()
        {
            var data = new TriangleData();

            data.SideA = 3.0;

            Assert.That(data.SideA, Is.EqualTo(3.0));
        }

        [Test]
        public void SideB_SetValue_GetReturnsSameValue()
        {
            var data = new TriangleData();

            data.SideB = 4.0;

            Assert.That(data.SideB, Is.EqualTo(4.0));
        }

        [Test]
        public void SideC_SetValue_GetReturnsSameValue()
        {
            var data = new TriangleData();

            data.SideC = 5.0;

            Assert.That(data.SideC, Is.EqualTo(5.0));
        }
    }
}