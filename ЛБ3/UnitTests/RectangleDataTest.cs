using NUnit.Framework;
using Model;

namespace UnitTests.Model
{
    /// <summary>
    /// Представляет данные прямоугольника для сохранения и загрузки.
    /// </summary>
    [TestFixture]
    public class RectangleDataTest
    {
        //TODO: refactor
        [Test]
        public void Width_SetValue_GetReturnsSameValue()
        {
            var data = new RectangleData();

            data.Width = 3.0;

            Assert.That(data.Width, Is.EqualTo(3.0));
        }

        [Test]
        public void Height_SetValue_GetReturnsSameValue()
        {
            var data = new RectangleData();

            data.Height = 4.0;

            Assert.That(data.Height, Is.EqualTo(4.0));
        }
    }
}