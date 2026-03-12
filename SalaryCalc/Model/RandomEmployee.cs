namespace Model
{
    /// <summary>
    /// Класс для генерации случайных сотрудников.
    /// </summary>
    public class RandomEmployee
    {
        /// <summary>
        /// Генерирует случайное число в диапазоне с фиксированной точностью.
        /// </summary>
        /// <param name="minimum">Минимальное значение.</param>
        /// <param name="maximum">Максимальное значение.</param>
        /// <returns>Случайное число, округленное до 2 знаков после запятой.</returns>
        public static decimal GetRandomNumber(double minimum, double maximum)
        {
            Random random = new Random();
            double value = random.NextDouble() * (maximum - minimum) + minimum;
            return Math.Round((decimal)value, 2);
        }

        /// <summary>
        /// Генерирует случайные параметры сотрудника.
        /// </summary>
        /// <param name="employeeType">Тип сотрудника.</param>
        /// <returns>Случайный сотрудник.</returns>
        public EmployeeBase GetRandomParameters(EmployeeType employeeType)
        {
            Random random = new Random();
            const double minHourlyRate = 50;
            const double maxHourlyRate = 200;
            const double minHoursWorked = 100;
            const double maxHoursWorked = 200;
            const double minMonthlySalary = 30000;
            const double maxMonthlySalary = 100000;
            const double minCommissionRate = 0.05;
            const double maxCommissionRate = 0.2;
            const double minSalesAmount = 50000;
            const double maxSalesAmount = 500000;

            string[] surnames = { "Иванов", "Петров", 
                "Сидоров", "Кузнецов", "Смирнов" };
            string[] names = { "Иван", "Петр", "Сидор", 
                "Алексей", "Дмитрий" };
            string[] patronymics = { "Иванович", "Петрович", 
                "Сидорович", "Алексеевич", "Дмитриевич" };

            string randomSurname = 
                surnames[random.Next(surnames.Length)];
            string randomName = 
                names[random.Next(names.Length)];
            string randomPatronymic = 
                patronymics[random.Next(patronymics.Length)];

            string randomFullName = $"{randomSurname} " +
                $"{randomName} {randomPatronymic}";

            string randomHireDate = DateTime.Now.
                AddDays(-random.Next(1, 365)).ToString("dd.MM.yyyy");

            switch (employeeType)
            {
                case EmployeeType.Hourly:
                { 
                    decimal hourlyRate = GetRandomNumber(minHourlyRate, 
                        maxHourlyRate);
                    decimal hoursWorked = GetRandomNumber(minHoursWorked, 
                        maxHoursWorked);
                    return new HourlyEmployee(
                        randomName,
                        randomSurname, 
                        randomPatronymic,
                        randomHireDate,
                        (double)hourlyRate,
                        (double)hoursWorked
                    );
                }

                case EmployeeType.Salary:
                {
                    decimal monthlySalary = GetRandomNumber(minMonthlySalary, 
                        maxMonthlySalary);
                    return new SalaryEmployee(
                        randomName,
                        randomSurname,
                        randomPatronymic,
                        randomHireDate,
                        (double)monthlySalary
                    );
                }

                case EmployeeType.Commission:
                { 
                    decimal commissionRate = GetRandomNumber(minCommissionRate, 
                        maxCommissionRate);
                    decimal salesAmount = GetRandomNumber(minSalesAmount, 
                        maxSalesAmount);
                    return new CommissionEmployee(
                        randomName,
                        randomSurname,
                        randomPatronymic,
                        randomHireDate,
                        (double)commissionRate,
                        (double)salesAmount
                    );
                }
                default:
                    throw new ArgumentException("Неизвестный тип сотрудника.");
            }
        }
    }
}