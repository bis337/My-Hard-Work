using NUnit.Framework;
using Model;

namespace UnitTests.Model
{
    /// <summary>
    /// Набор тестов для класса Circle.
    /// </summary>
    [TestFixture]
    public class CircleDataTest
    {
        [Test]
        public void Radius_SetValue_GetReturnsSameValue()
        {
            var data = new CircleData();

            data.Radius = 5.0;

            Assert.That(data.Radius, Is.EqualTo(5.0));
        }
    }
}