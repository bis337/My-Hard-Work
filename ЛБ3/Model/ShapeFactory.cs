using System;

namespace Model
{
    /// <summary>
    /// Создает фигуры и преобразует их в объекты данных.
    /// </summary>
    public static class ShapeFactory
    {
        /// <summary>
        /// Создает фигуру на основе объекта данных.
        /// </summary>
        /// <param name="data">Данные фигуры.</param>
        /// <returns>Созданная фигура.</returns>
        /// <exception cref="ArgumentException">
        /// Генерируется, если тип фигуры неизвестен.
        /// </exception>
        public static IShape CreateShape(ShapeData data)
        {
            switch (data.Type)
            {
                case ShapeTypes.Circle:
                    return new Circle(data.Value1);
                case ShapeTypes.Rectangle:
                    return new Rectangle(data.Value1, data.Value2);
                case ShapeTypes.Triangle:
                    return new Triangle(
                        data.Value1,
                        data.Value2,
                        data.Value3);
                default:
                    throw new ArgumentException("Неизвестный тип фигуры");
            }
        }

        /// <summary>
        /// Преобразует фигуру в объект данных.
        /// </summary>
        /// <param name="shape">Фигура.</param>
        /// <returns>Объект данных фигуры.</returns>
        /// <exception cref="ArgumentException">
        /// Генерируется, если тип фигуры неизвестен.
        /// </exception>
        public static ShapeData ConvertToData(IShape shape)
        {
            if (shape is Circle circle)
            {
                return new ShapeData
                {
                    Type = ShapeTypes.Circle,
                    Value1 = circle.Radius
                };
            }

            if (shape is Rectangle rectangle)
            {
                return new ShapeData
                {
                    Type = ShapeTypes.Rectangle,
                    Value1 = rectangle.Width,
                    Value2 = rectangle.Height
                };
            }

            if (shape is Triangle triangle)
            {
                return new ShapeData
                {
                    Type = ShapeTypes.Triangle,
                    Value1 = triangle.SideA,
                    Value2 = triangle.SideB,
                    Value3 = triangle.SideC
                };
            }

            throw new ArgumentException("Неизвестный тип фигуры");
        }
    }
}