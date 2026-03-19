using System;

namespace Model
{
    /// <summary>
    /// Представляет треугольник.
    /// </summary>
    public class Triangle : IShape
    {
        private readonly double _a;
        private readonly double _b;
        private readonly double _c;

        /// <summary>
        /// Получает длину первой стороны.
        /// </summary>
        public double SideA => _a;

        /// <summary>
        /// Получает длину второй стороны.
        /// </summary>
        public double SideB => _b;

        /// <summary>
        /// Получает длину третьей стороны.
        /// </summary>
        public double SideC => _c;

        /// <summary>
        /// Инициализирует новый экземпляр класса
        /// <see cref="Triangle"/>.
        /// </summary>
        /// <param name="a">Длина первой стороны.</param>
        /// <param name="b">Длина второй стороны.</param>
        /// <param name="c">Длина третьей стороны.</param>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Генерируется, если сторона меньше или равна нулю.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// Генерируется, если треугольник с такими сторонами
        /// не существует.
        /// </exception>
        public Triangle(double a, double b, double c)
        {
            if (a <= 0)
            {
                throw new ArgumentOutOfRangeException(
                    nameof(a),
                    "Длина стороны должна быть " +
                    "положительным числом.");
            }
            if (b <= 0)
            {
                throw new ArgumentOutOfRangeException(
                    nameof(b),
                    "Длина стороны должна быть " +
                    "положительным числом.");
            }
            if (c <= 0)
            {
                throw new ArgumentOutOfRangeException(
                    nameof(c),
                    "Длина стороны должна быть " +
                    "положительным числом.");
            }

            _a = a;
            _b = b;
            _c = c;

            ValidateTriangle();
        }

        /// <summary>
        /// Получает название фигуры.
        /// </summary>
        public string Name => "Треугольник";

        /// <summary>
        /// Проверяет существование треугольника по неравенству.
        /// </summary>
        /// <exception cref="ArgumentException">
        /// Генерируется, если треугольник не существует.
        /// </exception>
        private void ValidateTriangle()
        {
            if (_a + _b <= _c || _a + _c <= _b || _b + _c <= _a)
            {
                throw new ArgumentException(
                    $"Треугольник со сторонами {_a}, {_b}, {_c} " +
                    "не существует. Сумма любых двух сторон " +
                    "должна быть больше третьей.");
            }
        }

        /// <summary>
        /// Вычисляет площадь треугольника по формуле Герона.
        /// </summary>
        /// <returns>Площадь треугольника.</returns>
        public double CalculateArea()
        {
            double p = (_a + _b + _c) / 2;
            return Math.Sqrt(p * (p - _a) * (p - _b) * (p - _c));
        }

        /// <summary>
        /// Вычисляет периметр треугольника.
        /// </summary>
        /// <returns>Периметр треугольника.</returns>
        public double CalculatePerimeter()
        {
            return _a + _b + _c;
        }

        /// <summary>
        /// Возвращает строковое представление треугольника.
        /// </summary>
        /// <returns>Строка с описанием треугольника.</returns>
        public override string ToString()
        {
            return $"{Name} со сторонами {_a:F2}, {_b:F2}, {_c:F2}";
        }
    }
}
