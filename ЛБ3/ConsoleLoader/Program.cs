using System;
using Model;

namespace ConsoleLoader
{
    /// <summary>
    /// Консольное приложение для тестирования бизнес-логики.
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Точка входа в приложение.
        /// </summary>
        /// <param name="args">Аргументы командной строки.</param>
        private static void Main(string[] args)
        {
            Console.WriteLine(
                "=== Лабораторная работа №3: Геометрические фигуры ===");
            Console.WriteLine();

            IShape shape;
            //TODO: duplication
            try
            {
                Console.WriteLine("--- Круг ---");
                Console.Write(
                    "Введите радиус круга (положительное число): ");
                double radius = ReadDoubleFromConsole();
                shape = new Circle(radius);
                DisplayShapeInfo(shape);
            }
            //TODO: Specify exception
            catch (Exception ex)
            {
                Console.WriteLine(
                    $"Ошибка при создании круга: {ex.Message}");
            }

            Console.WriteLine();
            //TODO: duplication
            try
            {
                Console.WriteLine("--- Прямоугольник ---");
                Console.Write(
                    "Введите ширину прямоугольника " +
                    "(положительное число): ");
                double width = ReadDoubleFromConsole();
                Console.Write(
                    "Введите высоту прямоугольника " +
                    "(положительное число): ");
                double height = ReadDoubleFromConsole();
                shape = new Rectangle(width, height);
                DisplayShapeInfo(shape);
            }
            //TODO: Specify exception
            catch (Exception ex)
            {
                Console.WriteLine(
                    $"Ошибка при создании прямоугольника: {ex.Message}");
            }

            Console.WriteLine();
            //TODO: duplication
            try
            {
                Console.WriteLine("--- Треугольник ---");
                Console.Write(
                    "Введите длину первой стороны " +
                    "(положительное число): ");
                double a = ReadDoubleFromConsole();
                Console.Write(
                    "Введите длину второй стороны " +
                    "(положительное число): ");
                double b = ReadDoubleFromConsole();
                Console.Write(
                    "Введите длину третьей стороны " +
                    "(положительное число): ");
                double c = ReadDoubleFromConsole();
                shape = new Triangle(a, b, c);
                DisplayShapeInfo(shape);
            }
            //TODO: Specify exception
            catch (Exception ex)
            {
                Console.WriteLine(
                    $"Ошибка при создании треугольника: {ex.Message}");
            }

            Console.WriteLine();
            Console.WriteLine(
                "=== Демонстрация валидации (обработка исключений) ===");
            Console.WriteLine();

            try
            {
                Console.WriteLine(
                    "Попытка создать круг с отрицательным радиусом...");
                shape = new Circle(-5);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine(
                    $"Перехвачено исключение: {ex.Message}");
            }

            Console.WriteLine();

            try
            {
                Console.WriteLine(
                    "Попытка создать треугольник со сторонами (1, 2, 10)...");
                shape = new Triangle(1, 2, 10);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(
                    $"Перехвачено исключение: {ex.Message}");
            }
             
            Console.WriteLine();
            Console.WriteLine("Нажмите любую клавишу для выхода...");
            Console.Read();
        }

        /// <summary>
        /// Читает число типа double из консоли.
        /// </summary>
        /// <returns>Введенное число.</returns>
        private static double ReadDoubleFromConsole()
        {
            while (true)
            {
                string? input = Console.ReadLine();
                if (double.TryParse(input, out double result))
                {
                    return result;
                }
                Console.Write(
                    "Некорректный ввод. Введите число: ");
            }
        }

        /// <summary>
        /// Отображает информацию о фигуре.
        /// </summary>
        /// <param name="shape">Фигура.</param>
        private static void DisplayShapeInfo(IShape shape)
        {
            Console.WriteLine($"Фигура: {shape.Name}");
            Console.WriteLine($"Описание: {shape}");
            Console.WriteLine($"Площадь: {shape.CalculateArea():F2}");
            Console.WriteLine(
                $"Периметр: {shape.CalculatePerimeter():F2}");
        }
    }
}
