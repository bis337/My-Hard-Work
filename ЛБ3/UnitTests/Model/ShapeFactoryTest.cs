using System;
using NUnit.Framework;
using Model;

namespace UnitTests.Model
{
    /// <summary>
    /// Набор тестов для класса ShapeFactory.
    /// </summary>
    [TestFixture]
    public class ShapeFactoryTest
    {
        [Test]
        public void CreateShape_CircleData_ReturnsCircleWithCorrectRadius()
        {
            var data = new CircleData { Radius = 5.0 };
            var shape = ShapeFactory.CreateShape(data);
            Assert.That(shape, Is.InstanceOf<Circle>());
            Assert.That(((Circle)shape).Radius, Is.EqualTo(5.0));
        }

        [Test]
        public void CreateShape_RectangleData_ReturnsRectangleWithCorrectSides()
        {
            var data = new RectangleData { Width = 3.0, Height = 4.0 };
            var shape = ShapeFactory.CreateShape(data);
            Assert.That(shape, Is.InstanceOf<Rectangle>());
            Assert.That(((Rectangle)shape).Width, Is.EqualTo(3.0));
            Assert.That(((Rectangle)shape).Height, Is.EqualTo(4.0));
        }

        [Test]
        public void CreateShape_TriangleData_ReturnsTriangleWithCorrectSides()
        {
            var data = new TriangleData
            {
                SideA = 3.0,
                SideB = 4.0,
                SideC = 5.0
            };

            var shape = ShapeFactory.CreateShape(data);

            Assert.That(shape, Is.InstanceOf<Triangle>());
            Assert.That(((Triangle)shape).SideA, Is.EqualTo(3.0));
            Assert.That(((Triangle)shape).SideB, Is.EqualTo(4.0));
            Assert.That(((Triangle)shape).SideC, Is.EqualTo(5.0));
        }

        [Test]
        public void CreateShape_UnknownObject_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(
                () => ShapeFactory.CreateShape(new object()));
        }

        [Test]
        public void CreateShape_NullData_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(
                () => ShapeFactory.CreateShape(null!));
        }

        [Test]
        public void ConvertToData_Circle_ReturnsCircleDataWithCorrectRadius()
        {
            var circle = new Circle(7.0);
            var data = ShapeFactory.ConvertToData(circle);
            Assert.That(data, Is.InstanceOf<CircleData>());
            Assert.That(((CircleData)data).Radius, Is.EqualTo(7.0));
        }

        [Test]
        public void ConvertToData_Rectangle_ReturnsRectangleDataWithCorrectSides()
        {
            var rect = new Rectangle(3.0, 4.0);
            var data = ShapeFactory.ConvertToData(rect);
            Assert.That(data, Is.InstanceOf<RectangleData>());
            Assert.That(((RectangleData)data).Width, Is.EqualTo(3.0));
            Assert.That(((RectangleData)data).Height, Is.EqualTo(4.0));
        }

        [Test]
        public void ConvertToData_Triangle_ReturnsTriangleDataWithCorrectSides()
        {
            var triangle = new Triangle(3.0, 4.0, 5.0);
            var data = ShapeFactory.ConvertToData(triangle);
            Assert.That(data, Is.InstanceOf<TriangleData>());
            Assert.That(((TriangleData)data).SideA, Is.EqualTo(3.0));
            Assert.That(((TriangleData)data).SideB, Is.EqualTo(4.0));
            Assert.That(((TriangleData)data).SideC, Is.EqualTo(5.0));
        }

        [Test]
        public void ConvertToData_UnknownShape_ThrowsArgumentException()
        {
            var shape = new UnknownShape();
            Assert.That(shape.Name, Is.EqualTo("Unknown"));
            Assert.That(shape.CalculateArea(), Is.EqualTo(0.0));
            Assert.That(shape.CalculatePerimeter(), Is.EqualTo(0.0));
            Assert.Throws<ArgumentException>(
                () => ShapeFactory.ConvertToData(shape));
        }

        [Test]
        public void ConvertToData_NullShape_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(
                () => ShapeFactory.ConvertToData(null!));
        }

        /// <summary>
        /// Вспомогательная реализация IShape для тестирования
        /// обработки неизвестного типа в ShapeFactory.
        /// </summary>
        private class UnknownShape : IShape
        {
            //TODO: XML+
            /// <summary>
            /// Получает название неизвестной фигуры.
            /// </summary>
            public string Name => "Unknown";

            //TODO: XML+
            /// <summary>
            /// Возвращает площадь неизвестной фигуры.
            /// </summary>
            /// <returns>Площадь неизвестной фигуры.</returns>
            public double CalculateArea() => 0;

            //TODO: XML+
            /// <summary>
            /// Возвращает периметр неизвестной фигуры.
            /// </summary>
            /// <returns>Периметр неизвестной фигуры.</returns>
            public double CalculatePerimeter() => 0;
        }
    }
}