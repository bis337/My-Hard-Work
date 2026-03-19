using System;

namespace Model
{
    /// <summary>
    /// Представляет круг.
    /// </summary>
    public class Circle : IShape
    {
        private readonly double _radius;

        /// <summary>
        /// Получает или задает радиус круга.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Генерируется, если радиус меньше или равен нулю.
        /// </exception>
        public double Radius
        {
            get => _radius;
            init
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException(
                        nameof(value),
                        "Радиус круга должен быть положительным числом.");
                }
                _radius = value;
            }
        }

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="Circle"/>.
        /// </summary>
        /// <param name="radius">Радиус круга.</param>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Генерируется, если радиус меньше или равен нулю.
        /// </exception>
        public Circle(double radius)
        {
            Radius = radius;
        }

        /// <summary>
        /// Получает название фигуры.
        /// </summary>
        public string Name => "Круг";

        /// <summary>
        /// Вычисляет площадь круга.
        /// </summary>
        /// <returns>Площадь круга.</returns>
        public double CalculateArea()
        {
            return Math.PI * _radius * _radius;
        }

        /// <summary>
        /// Вычисляет периметр круга (длину окружности).
        /// </summary>
        /// <returns>Длина окружности.</returns>
        public double CalculatePerimeter()
        {
            return 2 * Math.PI * _radius;
        }

        /// <summary>
        /// Возвращает строковое представление круга.
        /// </summary>
        /// <returns>Строка с описанием круга.</returns>
        public override string ToString()
        {
            return $"{Name} с радиусом {_radius:F2}";
        }
    }
}
