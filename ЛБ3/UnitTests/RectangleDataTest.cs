using NUnit.Framework;
using Model;

namespace UnitTests.Model
{
    /// <summary>
    /// Набор тестов для класса RectangleData.
    /// </summary>
    [TestFixture]
    public class RectangleDataTest
    {
        [Test(Description = "Проверяет, что свойства Width и Height сохраняют и возвращают заданные значения.")]
        public void Properties_SetValues_GetReturnsSameValues()
        {
            var data = new RectangleData();

            data.Width = 3.0;
            data.Height = 4.0;

            Assert.That(data.Width, Is.EqualTo(3.0));
            Assert.That(data.Height, Is.EqualTo(4.0));
        }
    }
}