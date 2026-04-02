using System;

namespace Model
{
    /// <summary>
    /// Представляет валидатор для проверки значений.
    /// </summary>
    internal static class Validator
    {
        /// <summary>
        /// Сообщение об ошибке для положительного числа.
        /// </summary>
        private const string PositiveNumberMessage =
            "Должно быть положительным числом.";

        /// <summary>
        /// Проверяет, что значение является положительным числом.
        /// </summary>
        /// <param name="value">Проверяемое значение.</param>
        /// <param name="paramName">Имя параметра.</param>
        /// <param name="message">Сообщение об ошибке.</param>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Генерируется, если значение меньше или равно нулю.
        /// </exception>
        public static void ValidatePositive(
            double value,
            string paramName,
            string message)
        {
            if (value <= 0)
            {
                throw new ArgumentOutOfRangeException(paramName, message);
            }
        }

        /// <summary>
        /// Проверяет, что значение стороны является положительным числом.
        /// </summary>
        /// <param name="value">Проверяемое значение.</param>
        /// <param name="paramName">Имя параметра.</param>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Генерируется, если значение меньше или равно нулю.
        /// </exception>
        public static void ValidateSide(
            double value,
            string paramName)
        {
            ValidatePositive(value, paramName, GetSideMessage(paramName));
        }

        /// <summary>
        /// Получает сообщение об ошибке для стороны фигуры.
        /// </summary>
        /// <param name="paramName">Имя параметра.</param>
        /// <returns>Сообщение об ошибке.</returns>
        private static string GetSideMessage(string paramName)
        {
            return $"Длина {paramName.ToLower()} должна быть " +
                PositiveNumberMessage;
        }
    }
}
