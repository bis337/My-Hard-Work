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
        //TODO: RSDN
        [Test(Description = "Проверяет, что свойство Radius сохраняет и возвращает заданное значение.")]
        public void Radius_SetValue_GetReturnsSameValue()
        {
            var data = new CircleData();

            //TODO: to const
            data.Radius = 5.0;

            Assert.That(data.Radius, Is.EqualTo(5.0));
        }
    }
}