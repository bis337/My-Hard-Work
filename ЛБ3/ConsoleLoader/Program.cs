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

            CreateAndDisplayShape(
                "--- Круг ---",
                "Введите радиус круга (положительное число): ",
                () =>
                {
                    double radius = ReadPositiveDoubleFromConsole("радиус");
                    return new Circle(radius); 
                });

            Console.WriteLine();
            CreateAndDisplayShape(
                "--- Прямоугольник ---",
                "Введите ширину прямоугольника (положительное число): ",
                () =>
                {
                    double width = ReadPositiveDoubleFromConsole("ширину");
                    Console.Write(
                        "Введите высоту прямоугольника " +
                        "(положительное число): ");
                    double height = ReadPositiveDoubleFromConsole("высоту");
                    return new Rectangle(width, height); 
                });

            Console.WriteLine();
            CreateAndDisplayShape(
                "--- Треугольник ---",
                "Введите длину первой стороны (положительное число): ",
                () =>
                {
                    double a = ReadPositiveDoubleFromConsole("первую сторону");
                    Console.Write(
                        "Введите длину второй стороны " +
                        "(положительное число): ");
                    double b = ReadPositiveDoubleFromConsole("вторую сторону");
                    Console.Write(
                        "Введите длину третьей стороны " +
                        "(положительное число): ");
                    double c = ReadPositiveDoubleFromConsole("третью сторону");
                  
                    try
                    {
                       
                        new Triangle(a, b, c);
                    }
                    catch (ArgumentException ex)
                    {
                        
                        throw ex; 
                    }
                    return new Triangle(a, b, c); 
                });

            Console.WriteLine();
            Console.WriteLine(
                "=== Демонстрация валидации (обработка исключений) ===");
            Console.WriteLine();

            try
            {
                Console.WriteLine(
                    "Попытка создать круг с отрицательным радиусом...");
                IShape shape = new Circle(-5);
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
                IShape shape = new Triangle(1, 2, 10);
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
        /// Создаёт фигуру и отображает информацию о ней.
        /// </summary>
        /// <param name="title">Заголовок фигуры.</param>
        /// <param name="prompt">Запрос для ввода данных.</param>
        /// <param name="factory">Фабричный метод создания фигуры.</param>
        private static void CreateAndDisplayShape(
            string title,
            string prompt,
            Func<IShape> factory)
        {
            Console.WriteLine(title);
            Console.Write(prompt);
            try
            {
                IShape shape = factory(); 
                DisplayShapeInfo(shape);
            }
            catch (ArgumentOutOfRangeException ex) 
            {
                Console.WriteLine(
                    $"Ошибка при создании фигуры: {ex.Message}");
            }
            catch (ArgumentException ex) 
            {
                Console.WriteLine(
                    $"Ошибка при создании фигуры: {ex.Message}");
            }
        }

        /// <summary>
        /// Читает положительное число типа double из консоли.
        /// </summary>
        /// <param name="paramName">Название параметра для сообщения об ошибке.</param>
        /// <returns>Введенное положительное число.</returns>
        private static double ReadPositiveDoubleFromConsole(string paramName)
        {
            while (true)
            {
                string? input = Console.ReadLine();
                if (double.TryParse(input, out double result))
                {
                    if (result > 0)
                    {
                        return result; 
                    }
                    else
                    {
                 
                        Console.Write(
                            $"Значение для {paramName} должно быть положительным числом." +
                            $" " +$"Повторите ввод: ");
                    }
                }
                else
                {
                    Console.Write(
                        $"Некорректный ввод. Введите число: ");
                }
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