using NUnit.Framework;
using Model;

namespace UnitTests.Model
{
    /// <summary>
    /// Набор тестов для класса CircleData.
    /// </summary>
    [TestFixture]
    public class CircleDataTest
    {
        /// <summary>
        /// Проверяет, что свойство Radius сохраняет и возвращает
        /// заданное значение.
        /// </summary>
        [Test(Description = "Проверяет, что свойство Radius сохраняет и " +
            "возвращает заданное значение.")]
        public void Radius_SetValue_GetReturnsSameValue()
        {
            //TODO: to const+
            const double radius = 5.0;

            var data = new CircleData();

            data.Radius = radius;

            Assert.That(data.Radius, Is.EqualTo(radius));
        }
    }
}