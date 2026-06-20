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
        //TODO: RSDN
        [Test(Description = "Проверяет, что свойства SideA, SideB и SideC сохраняют и возвращают заданные значения.")]
        public void Properties_SetValues_GetReturnsSameValues()
        {
            var data = new TriangleData();

            //TODO: to const
            data.SideA = 3.0;
            data.SideB = 4.0;
            data.SideC = 5.0;

            Assert.That(data.SideA, Is.EqualTo(3.0));
            Assert.That(data.SideB, Is.EqualTo(4.0));
            Assert.That(data.SideC, Is.EqualTo(5.0));
        }
    }
}