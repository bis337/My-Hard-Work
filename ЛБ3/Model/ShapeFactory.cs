using System;

namespace Model
{
    /// <summary>
    /// Создает фигуры и преобразует их в DTO-объекты.
    /// </summary>
    public static class ShapeFactory
    {
        public static IShape CreateShape(ShapeDto dto)
        {
            switch (dto.Type)
            {
                case "Круг":
                    return new Circle(dto.Value1);
                case "Прямоугольник":
                    return new Rectangle(dto.Value1, dto.Value2);
                case "Треугольник":
                    return new Triangle(dto.Value1, dto.Value2, dto.Value3);
                default:
                    throw new ArgumentException("Неизвестный тип фигуры");
            }
        }

        public static ShapeDto ConvertToDto(IShape shape)
        {
            if (shape is Circle circle)
                return new ShapeDto { Type = "Круг", Value1 = circle.Radius };

            if (shape is Rectangle rectangle)
                return new ShapeDto { Type = "Прямоугольник", 
                    Value1 = rectangle.Width, Value2 = rectangle.Height };

            if (shape is Triangle triangle)
                return new ShapeDto { Type = "Треугольник",
                    Value1 = triangle.SideA, Value2 = triangle.SideB, 
                    Value3 = triangle.SideC };

            throw new ArgumentException("Неизвестный тип фигуры");
        }
    }
}