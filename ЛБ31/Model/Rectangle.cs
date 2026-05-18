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
        /// Получает или задает ширину прямоугольника.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Генерируется, если ширина меньше или равна нулю.
        /// </exception>
        public double Width
        {
            get => _width;
            init
            {
                Validator.ValidatePositive(
                    value,
                    nameof(value),
                    "Ширина прямоугольника должна быть " +
                    "положительным числом.");
                _width = value;
            }
        }

        /// <summary>
        /// Получает или задает высоту прямоугольника.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Генерируется, если высота меньше или равна нулю.
        /// </exception>
        public double Height
        {
            get => _height;
            init
            {
                Validator.ValidatePositive(
                    value,
                    nameof(value),
                    "Высота прямоугольника должна быть " +
                    "положительным числом.");
                _height = value;
            }
        }

        /// <summary>
        /// Инициализирует новый экземпляр класса
        /// <see cref="Rectangle"/>.
        /// </summary>
        /// <param name="width">Ширина прямоугольника.</param>
        /// <param name="height">Высота прямоугольника.</param>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Генерируется, если ширина или высота меньше или
        /// равны нулю.
        /// </exception>
        public Rectangle(double width, double height)
        {
            Width = width;
            Height = height;
        }

        /// <summary>
        /// Получает название фигуры.
        /// </summary>
        public string Name => "Прямоугольник";

        /// <summary>
        /// Вычисляет площадь прямоугольника.
        /// </summary>
        /// <returns>Площадь прямоугольника.</returns>
        public double CalculateArea()
        {
            return _width * _height;
        }

        /// <summary>
        /// Вычисляет периметр прямоугольника.
        /// </summary>
        /// <returns>Периметр прямоугольника.</returns>
        public double CalculatePerimeter()
        {
            return 2 * (_width + _height);
        }

        /// <summary>
        /// Возвращает строковое представление прямоугольника.
        /// </summary>
        /// <returns>Строка с описанием прямоугольника.</returns>
        public override string ToString()
        {
            return $"{Name} с шириной {_width.ToString(Constants.FormatPrecision)} " +
                $"и высотой {_height.ToString(Constants.FormatPrecision)}";
        }
    }
}