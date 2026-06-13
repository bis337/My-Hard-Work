using System;

namespace Model
{
    /// <summary>
    /// Создает фигуры и преобразует их в объекты данных.
    /// </summary>
    public static class ShapeFactory
    {
        /// <summary>
        /// Создает фигуру на основе DTO.
        /// </summary>
        /// <param name="data">Объект DTO.</param>
        /// <returns>Созданная фигура.</returns>
        /// <exception cref="ArgumentException">
        /// Генерируется, если DTO некорректен или тип фигуры неизвестен.
        /// </exception>
        public static IShape CreateShape(object data)
        {
            return data switch
            {
                CircleData circleData => new Circle(circleData.Radius),
                RectangleData rectangleData => new Rectangle(rectangleData.Width, 
                rectangleData.Height),
                TriangleData triangleData => new Triangle(triangleData.SideA, 
                triangleData.SideB, triangleData.SideC),
                _ => throw new ArgumentException("Неизвестный тип фигуры")
            };
        }

        /// <summary>
        /// Преобразует фигуру в DTO.
        /// </summary>
        /// <param name="shape">Фигура.</param>
        /// <returns>DTO объекта фигуры.</returns>
        public static object ConvertToData(IShape shape)
        {
            return shape switch
            {
                Circle c => new CircleData { Radius = c.Radius },
                Rectangle r => new RectangleData { Width = r.Width, 
                    Height = r.Height },
                Triangle t => new TriangleData { SideA = t.SideA, SideB = t.SideB, 
                    SideC = t.SideC },
                _ => throw new ArgumentException("Неизвестный тип фигуры")
            };
        }
    }
}