using System;

namespace Model
{
    /// <summary>
    /// Представляет треугольник.
    /// </summary>
    public class Triangle : IShape
    {
        /// <summary>
        /// Длина первой стороны треугольника.
        /// </summary>
        private readonly double _sideA;

        /// <summary>
        /// Длина второй стороны треугольника.
        /// </summary>
        private readonly double _sideB;

        /// <summary>
        /// Длина третьей стороны треугольника.
        /// </summary>
        private readonly double _sideC;

        /// <summary>
        /// Получает длину первой стороны.
        /// </summary>
        public double SideA => _sideA;

        /// <summary>
        /// Получает длину второй стороны.
        /// </summary>
        public double SideB => _sideB;

        /// <summary>
        /// Получает длину третьей стороны.
        /// </summary>
        public double SideC => _sideC;

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
        public Triangle(double sideA, double sideB, double sideC)
        {
            ValidateSide(sideA, nameof(sideA));
            ValidateSide(sideB, nameof(sideB));
            ValidateSide(sideC, nameof(sideC));

            _sideA = sideA;
            _sideB = sideB;
            _sideC = sideC;

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
            if (_sideA + _sideB <= _sideC || _sideA + _sideC <= _sideB
                || _sideB + _sideC <= _sideA)
            {
                throw new ArgumentException(
                    $"Треугольник со сторонами {_sideA}, {_sideB}, " +
                    $"{_sideC} не существует. Сумма любых двух " +
                    "сторон должна быть больше третьей.");
            }
        }

        //TODO: duplication
        /// <summary>
        /// Проверяет корректность значения стороны.
        /// </summary>
        /// <param name="value">Значение стороны.</param>
        /// <param name="paramName">Имя параметра.</param>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Генерируется, если сторона меньше или равна нулю.
        /// </exception>
        private static void ValidateSide(double value, string paramName)
        {
            if (value <= 0)
            {
                throw new ArgumentOutOfRangeException(
                    paramName,
                    "Длина стороны должна быть " +
                    "положительным числом.");
            }
        }

        /// <summary>
        /// Вычисляет площадь треугольника по формуле Герона.
        /// </summary>
        /// <returns>Площадь треугольника.</returns>
        public double CalculateArea()
        {
            //TODO: RSDN
            //TODO: duplication
            double p = (_sideA + _sideB + _sideC) / 2;
            return Math.Sqrt(p * (p - _sideA) * (p - _sideB)
                * (p - _sideC));
        }

        /// <summary>
        /// Вычисляет периметр треугольника.
        /// </summary>
        /// <returns>Периметр треугольника.</returns>
        public double CalculatePerimeter()
        {
            return _sideA + _sideB + _sideC;
        }

        /// <summary>
        /// Возвращает строковое представление треугольника.
        /// </summary>
        /// <returns>Строка с описанием треугольника.</returns>
        public override string ToString()
        {
            //TODO: duplication
            return $"{Name} со сторонами {_sideA:F2}, {_sideB:F2}, " +
                $"{_sideC:F2}";
        }
    }
}
