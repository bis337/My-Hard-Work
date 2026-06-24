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
        /// <summary>
        /// Проверяет, что свойства Width и Height сохраняют и
        /// возвращают заданные значения.
        /// </summary>
        [Test(Description = "Проверяет, что свойства Width и Height сохраняют и " +
            "возвращают заданные значения.")]
        public void Properties_SetValues_GetReturnsSameValues()
        {
            //TODO: to const+
            const double width = 3.0;
            const double height = 4.0;

            var data = new RectangleData();

            data.Width = width;
            data.Height = height;

            Assert.That(data.Width, Is.EqualTo(width));
            Assert.That(data.Height, Is.EqualTo(height));
        }
    }
}