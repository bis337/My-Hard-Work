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
        /// Значение радиуса круга.
        /// </summary>
        private const double Radius = 5.0;

        //TODO: RSDN +
        /// <summary>
        /// Проверяет, что свойство Radius сохраняет и возвращает заданное значение.
        /// </summary>
        [Test(Description = "Проверяет, что свойство Radius сохраняет и" +
            " возвращает заданное значение.")]
        public void Radius_SetValue_GetReturnsSameValue()
        {
            var data = new CircleData();

            //TODO: to const+
            data.Radius = Radius;

            Assert.That(data.Radius, Is.EqualTo(Radius));
        }
    }
}