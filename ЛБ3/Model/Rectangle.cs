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
        //TODO: XML +
        private readonly double _width;
        /// <summary>
        /// Высота прямоугольника.
        /// </summary>
        //TODO: XML +
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
            //TODO: WTF? +
            init
            {
                //TODO: duplication +
                ValidateWidth(value);
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
                //TODO: duplication +
                ValidateHeight(value);
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
            return $"{Name} с шириной {_width:F2} и высотой {_height:F2}";
        }

        /// <summary>
        /// Проверяет корректность значения ширины.
        /// </summary>
        /// <param name="value">Значение ширины.</param>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Генерируется, если ширина меньше или равна нулю.
        /// </exception>
        private static void ValidateWidth(double value)
        {
            if (value <= 0)
            {
                throw new ArgumentOutOfRangeException(
                    nameof(value),
                    "Ширина прямоугольника должна быть " +
                    "положительным числом.");
            }
        }

        /// <summary>
        /// Проверяет корректность значения высоты.
        /// </summary>
        /// <param name="value">Значение высоты.</param>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Генерируется, если высота меньше или равна нулю.
        /// </exception>
        private static void ValidateHeight(double value)
        {
            if (value <= 0)
            {
                throw new ArgumentOutOfRangeException(
                    nameof(value),
                    "Высота прямоугольника должна быть " +
                    "положительным числом.");
            }
        }
    }
}
