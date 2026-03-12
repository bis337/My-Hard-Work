using Model;

namespace ConsoleLoader
{
    /// <summary>
    /// Класс для тестирования библиотеки классов Model через консоль
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Точка входа в программу
        /// </summary>
        /// <param name="args">Параметры командной строки</param>
        public static void Main(string[] args)
        {
            Console.WriteLine("Добро пожаловать в программу " +
                "для управления сотрудниками!\n\n" +
                "Нажмите любую клавишу, чтобы начать...");
            Console.ReadKey();

            // Список для хранения сотрудников
            List<IEmployee> employees = new List<IEmployee>();

            while (true)
            {
                Console.WriteLine("\nВыберите действие:");
                Console.WriteLine("1 - Добавить сотрудника с почасовой оплатой");
                Console.WriteLine("2 - Добавить сотрудника с фиксированным окладом");
                Console.WriteLine("3 - Добавить сотрудника с комиссионной оплатой");
                Console.WriteLine("4 - Добавить случайного сотрудника");
                Console.WriteLine("5 - Показать всех сотрудников");
                Console.WriteLine("6 - Выход из программы");

                var choice = Console.ReadLine();
                IEmployee? employee = null;

                switch (choice)
                {
                    case "1":
                    {
                        employee = AddConsoleEmployee.
                            GetNewHourlyEmployeeFromKeyboard();
                        employees.Add(employee);
                        GetEmployeeInfo(employee);
                        break;
                    }
                    case "2":
                    {
                        employee = AddConsoleEmployee.
                            GetNewSalaryEmployeeFromKeyboard();
                        employees.Add(employee);
                        GetEmployeeInfo(employee);
                        break;
                    }
                    case "3":
                    {
                        employee = AddConsoleEmployee.
                            GetNewCommissionEmployeeFromKeyboard();
                        employees.Add(employee);
                        GetEmployeeInfo(employee);
                        break;
                    }
                    case "4":
                    {
                        employee = CreateRandomEmployee();
                        employees.Add(employee);
                        GetEmployeeInfo(employee);
                        break;
                    }
                    case "5":
                    {
                        Console.WriteLine("\n=== Список всех сотрудников ===");
                        if (employees.Count == 0)
                        {
                            Console.WriteLine("Список сотрудников пуст.");
                        }
                        else
                        {
                            foreach (var emp in employees)
                            {
                                GetEmployeeInfo(emp);
                            }
                        }
                        break;
                    }
                    case "6":
                    {
                        Console.WriteLine("Выход из программы...");
                        Environment.Exit(0);
                        break;
                    }
                    default:
                    {
                        Console.WriteLine("Неизвестная команда. " +
                            "Ожидается число от 1 до 6.");
                        break;
                    }
                }
            }
        }

        /// <summary>
        /// Метод вывода информации о сотруднике в консоль
        /// </summary>
        /// <param name="employee">Экземпляр класса IEmployee</param>
        public static void GetEmployeeInfo(IEmployee employee)
        {
            Console.WriteLine($"\n=== Информация о сотруднике ===");
            Console.WriteLine($"ФИО: {employee.FullName}");
            Console.WriteLine($"Дата приема: {employee.HireDate}");
            Console.WriteLine($"Тип оплаты: {employee.Info}");
            Console.WriteLine($"Параметры: {employee.Parameters}");
            Console.WriteLine($"Объем работы: {employee.Workload}");
            Console.WriteLine($"Зарплата: {Math.Round(
                employee.CalculateExactSalary(), 2):F2} руб.");
            Console.WriteLine("================================\n");
        }

        /// <summary>
        /// Метод создания случайного сотрудника
        /// </summary>
        /// <returns>Случайный сотрудник</returns>
        private static IEmployee CreateRandomEmployee()
        {
            var random = new Random();
            var types = new[]
            {
                EmployeeType.Hourly,
                EmployeeType.Salary,
                EmployeeType.Commission
            };
            var randomType = types[random.Next(types.Length)];
            return new RandomEmployee().GetRandomParameters(randomType);
        }
    }
}