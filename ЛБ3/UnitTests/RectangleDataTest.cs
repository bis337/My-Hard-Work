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
        /// Значение ширины прямоугольника.
        /// </summary>
        private const double Width = 3.0;

        /// <summary>
        /// Значение высоты прямоугольника.
        /// </summary>
        private const double Height = 4.0;

        //TODO: RSDN +
        /// <summary>
        /// Проверяет, что свойства Width и Height сохраняют и
        /// возвращают заданные значения.
        /// </summary>
        [Test(Description = "Проверяет, что свойства Width и Height сохраняют и " +
            "возвращают заданные значения.")]
        public void Properties_SetValues_GetReturnsSameValues()
        {
            var data = new RectangleData();

            //TODO: to const+
            data.Width = Width;
            data.Height = Height;

            Assert.That(data.Width, Is.EqualTo(Width));
            Assert.That(data.Height, Is.EqualTo(Height));
        }
    }
}