using System;

namespace Model
{
    /// <summary>
    /// Представляет данные круга для сохранения и загрузки.
    /// </summary>
    public class CircleData
    {
        /// <summary>
        /// Радиус круга.
        /// </summary>
        public double Radius { get; set; }
    }

    /// <summary>
    /// Представляет данные прямоугольника для сохранения и загрузки.
    /// </summary>
    public class RectangleData
    {
        /// <summary>
        /// Ширина прямоугольника.
        /// </summary>
        public double Width { get; set; }

        /// <summary>
        /// Высота прямоугольника.
        /// </summary>
        public double Height { get; set; }
    }

    /// <summary>
    /// Представляет данные треугольника для сохранения и загрузки.
    /// </summary>
    public class TriangleData
    {
        /// <summary>
        /// Первая сторона треугольника.
        /// </summary>
        public double SideA { get; set; }

        /// <summary>
        /// Вторая сторона треугольника.
        /// </summary>
        public double SideB { get; set; }

        /// <summary>
        /// Третья сторона треугольника.
        /// </summary>
        public double SideC { get; set; }
    }
}