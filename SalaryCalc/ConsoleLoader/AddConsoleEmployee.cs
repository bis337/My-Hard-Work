using Model;

namespace ConsoleLoader
{
    /// <summary>
    /// Добавление сотрудников через консольный ввод
    /// </summary>
    public static class AddConsoleEmployee
    {
        /// <summary>
        /// Метод ввода данных о сотруднике с почасовой оплатой
        /// </summary>
        /// <returns>Экземпляр класса IEmployee</returns>
        public static IEmployee GetNewHourlyEmployeeFromKeyboard()
        {
            var employee = new HourlyEmployee();
            var actions = new List<Action>()
            {
                new Action(() =>
                {
                    Console.WriteLine("Имя сотрудника: ");
                    employee.Name = ReadStringFromConsole();
                }),
                new Action(() =>
                {
                    Console.WriteLine("Фамилия сотрудника: ");
                    employee.Surname = ReadStringFromConsole();
                }),
                new Action(() =>
                {
                    Console.WriteLine("Отчество сотрудника (необязательно): ");
                    employee.Patronymic = ReadOptionalStringFromConsole();
                }),
                new Action(() =>
                {
                    Console.WriteLine("Дата приема на работу (дд.мм.гггг): ");
                    employee.HireDate = ReadDateFromConsole();
                }),
                new Action(() =>
                {
                    Console.WriteLine("Почасовая ставка (руб./час): ");
                    employee.HourlyRate = ReadDoubleFromConsole();
                }),
                new Action(() =>
                {
                    Console.WriteLine("Отработанные часы: ");
                    employee.HoursWorked = ReadDoubleFromConsole();
                })
            };
            actions.ForEach(SetValue);
            return employee;
        }

        /// <summary>
        /// Метод ввода данных о сотруднике с фиксированным окладом
        /// </summary>
        /// <returns>Экземпляр класса IEmployee</returns>
        public static IEmployee GetNewSalaryEmployeeFromKeyboard()
        {
            var employee = new SalaryEmployee();
            var actions = new List<Action>()
            {
                new Action(() =>
                {
                    Console.WriteLine("Имя сотрудника: ");
                    employee.Name = ReadStringFromConsole();
                }),
                new Action(() =>
                {
                    Console.WriteLine("Фамилия сотрудника: ");
                    employee.Surname = ReadStringFromConsole();
                }),
                new Action(() =>
                {
                    Console.WriteLine("Отчество сотрудника (необязательно): ");
                    employee.Patronymic = ReadOptionalStringFromConsole();
                }),
                new Action(() =>
                {
                    Console.WriteLine("Дата приема на работу (дд.мм.гггг): ");
                    employee.HireDate = ReadDateFromConsole();
                }),
                new Action(() =>
                {
                    Console.WriteLine("Ежемесячный оклад (руб.): ");
                    employee.MonthlySalary = ReadDoubleFromConsole();
                })
            };
            actions.ForEach(SetValue);
            return employee;
        }

        /// <summary>
        /// Метод ввода данных о сотруднике с комиссионной оплатой
        /// </summary>
        /// <returns>Экземпляр класса IEmployee</returns>
        public static IEmployee GetNewCommissionEmployeeFromKeyboard()
        {
            var employee = new CommissionEmployee();
            var actions = new List<Action>()
            {
                new Action(() =>
                {
                    Console.WriteLine("Имя сотрудника: ");
                    employee.Name = ReadStringFromConsole();
                }),
                new Action(() =>
                {
                    Console.WriteLine("Фамилия сотрудника: ");
                    employee.Surname = ReadStringFromConsole();
                }),
                new Action(() =>
                {
                    Console.WriteLine("Отчество сотрудника (необязательно): ");
                    employee.Patronymic = ReadOptionalStringFromConsole();
                }),
                new Action(() =>
                {
                    Console.WriteLine("Дата приема на работу (дд.мм.гггг): ");
                    employee.HireDate = ReadDateFromConsole();
                }),
                new Action(() =>
                {
                    Console.WriteLine("Ставка комиссии (от 0 до 1, например 0.15): ");
                    employee.CommissionRate = ReadDoubleFromConsole();
                }),
                new Action(() =>
                {
                    Console.WriteLine("Сумма продаж (руб.): ");
                    employee.SalesAmount = ReadDoubleFromConsole();
                })
            };
            actions.ForEach(SetValue);
            return employee;
        }

        /// <summary>
        /// Метод чтения строки с консоли
        /// </summary>
        /// <returns>Введенная строка</returns>
        public static string ReadStringFromConsole()
        {
            return Console.ReadLine().Trim();
        }

        /// <summary>
        /// Метод чтения необязательной строки с консоли
        /// </summary>
        /// <returns>Введенная строка или null если пустая</returns>
        public static string ReadOptionalStringFromConsole()
        {
            var input = Console.ReadLine().Trim();
            return string.IsNullOrEmpty(input) ? null : input;
        }

        /// <summary>
        /// Метод чтения даты с консоли
        /// </summary>
        /// <returns>Дата в формате строки</returns>
        public static string ReadDateFromConsole()
        {
            return Console.ReadLine().Trim();
        }

        /// <summary>
        /// Метод чтения числа с консоли и преобразования в double
        /// </summary>
        /// <returns>Введенное число</returns>
        public static double ReadDoubleFromConsole()
        {
            return double.Parse(Console.ReadLine().Replace('.', ','));
        }

        /// <summary>
        /// Метод получения пользовательского ввода и задания параметра
        /// </summary>
        /// <param name="action">Действие для выполнения</param>
        public static void SetValue(Action action)
        {
            while (true)
            {
                try
                {
                    action.Invoke();
                    return;
                }
                catch (Exception e)
                {
                    Console.WriteLine($"\nОшибка: {e.Message}\n");
                    Console.WriteLine("Пожалуйста, введите значение заново:");
                }
            }
        }
    }
}