using System;
using System.Linq;

namespace Model
{
    /// <summary>
    /// Представляет треугольник.
    /// </summary>
    public class Triangle : IShape
    {
        //TODO: duplication
        /// <summary>
        /// Формат для округления вещественных чисел при выводе.
        /// </summary>
        private const string FormatPrecision = "F2";

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
            // Используем метод ValidateSide из Validator
            // Передаём имя переменной (не свойства), так как они ещё не инициализированы
            Validator.ValidateSide(sideA, nameof(sideA));
            Validator.ValidateSide(sideB, nameof(sideB));
            Validator.ValidateSide(sideC, nameof(sideC));

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
            if (_sideA + _sideB <= _sideC 
                || _sideA + _sideC <= _sideB
                || _sideB + _sideC <= _sideA)
            {
                throw new ArgumentException(
                    $"Треугольник со сторонами {_sideA}, {_sideB}, " +
                    $"{_sideC} не существует. Сумма любых двух " +
                    "сторон должна быть больше третьей.");
            }
        }

        /// <summary>
        /// Вычисляет площадь треугольника по формуле Герона.
        /// </summary>
        /// <returns>Площадь треугольника.</returns>
        public double CalculateArea()
        {
            double perimeter = CalculatePerimeter();
            double semiPerimeter = perimeter / 2;
            return Math.Sqrt(semiPerimeter * (semiPerimeter - _sideA)
                * (semiPerimeter - _sideB) * (semiPerimeter - _sideC));
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
            return FormatToString(
                Name,
                "сторонами",
                _sideA,
                _sideB,
                _sideC);
        }

        /// <summary>
        /// Форматирует строковое представление фигуры.
        /// </summary>
        /// <param name="name">Название фигуры.</param>
        /// <param name="paramName">Название параметров.</param>
        /// <param name="values">Значения параметров.</param>
        /// <returns>Отформатированная строка.</returns>
        private static string FormatToString(
            string name,
            //TODO: RSDN
            string paramName,
            params double[] values)
        {
            //TODO: RSDN
            var formattedValues = string.Join(", ", values.Select(v => v.ToString(FormatPrecision)));
            return $"{name} с {paramName.ToLower()} {formattedValues}";
        }
    }
}