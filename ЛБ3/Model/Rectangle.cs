using System;

namespace Model
{
    /// <summary>
    /// Представляет прямоугольник.
    /// </summary>
    public class Rectangle : IShape
    {
        /// <summary>
        /// Ширина прямоугольника.
        /// </summary>
        private readonly double _width;

        /// <summary>
        /// Высота прямоугольника.
        /// </summary>
        private readonly double _height;

        /// <summary>
        /// Получает ширину прямоугольника.
        /// </summary>
        public double Width => _width;

        /// <summary>
        /// Получает высоту прямоугольника.
        /// </summary>
        public double Height => _height;

        /// <summary>
        /// Инициализирует новый экземпляр класса
        /// <see cref="Rectangle"/>.
        /// </summary>
        /// <param name="width">
        /// Ширина прямоугольника.
        /// </param>
        /// <param name="height">
        /// Высота прямоугольника.
        /// </param>
        /// <exception cref="ArgumentException">
        /// Генерируется, если ширина или высота меньше
        /// или равны нулю.
        /// </exception>
        public Rectangle(double width, double height)
        {
            if (width <= 0)
            {
                throw new ArgumentException(
                    "Width must be greater than zero.");
            }

            if (height <= 0)
            {
                throw new ArgumentException(
                    "Height must be greater than zero.");
            }

            _width = width;
            _height = height;
        }

        /// <summary>
        /// Получает название фигуры.
        /// </summary>
        public string Name => "Прямоугольник";

        /// <summary>
        /// Вычисляет площадь прямоугольника.
        /// </summary>
        /// <returns>
        /// Площадь прямоугольника.
        /// </returns>
        public double CalculateArea()
        {
            return _width * _height;
        }

        /// <summary>
        /// Вычисляет периметр прямоугольника.
        /// </summary>
        /// <returns>
        /// Периметр прямоугольника.
        /// </returns>
        public double CalculatePerimeter()
        {
            return 2 * (_width + _height);
        }

        /// <summary>
        /// Возвращает строковое представление
        /// прямоугольника.
        /// </summary>
        /// <returns>
        /// Строка с описанием прямоугольника.
        /// </returns>
        public override string ToString()
        {
            return $"{Name}: Width = {_width}, " +
                   $"Height = {_height}";
        }
    }
}