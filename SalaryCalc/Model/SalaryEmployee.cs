namespace Model
{
    /// <summary>
    /// Сотрудник с фиксированным окладом.
    /// </summary>
    [Serializable]
    public class SalaryEmployee : EmployeeBase
    {
        /// <summary>
        /// Оклад.
        /// </summary>
        private double _monthlySalary;

        /// <summary>
        /// Ежемесячный оклад.
        /// </summary>
        public double MonthlySalary
        {
            get => _monthlySalary;
            set => _monthlySalary = CheckValue(value);
        }

        /// <summary>
        /// Параметры оплаты в отформатированном виде.
        /// </summary>
        public override string Parameters => $"Оклад = {_monthlySalary:F0} руб.";

        /// <summary>
        /// Объем работы в отформатированном виде.
        /// </summary>
        public override string Workload => "Полная ставка";

        /// <summary>
        /// Информация о типе оплаты.
        /// </summary>
        public override string Info => "Оклад";

        /// <summary>
        /// Инициализирует новый экземпляр класса SalaryEmployee.
        /// </summary>
        public SalaryEmployee() { }

        /// <summary>
        /// Инициализирует новый экземпляр класса SalaryEmployee 
        /// с указанными параметрами.
        /// </summary>
        /// <param name="name">Имя сотрудника.</param>
        /// <param name="surname">Фамилия сотрудника.</param>
        /// <param name="patronymic">Отчество сотрудника.</param>
        /// <param name="hireDate">Дата приема на работу.</param>
        /// <param name="monthlySalary">Ежемесячный оклад.</param>
        public SalaryEmployee(string name, string surname, string patronymic,
            string hireDate, double monthlySalary)
        {
            Name = name;
            Surname = surname;
            Patronymic = patronymic;
            HireDate = hireDate;
            MonthlySalary = monthlySalary;
        }

        /// <summary>
        /// Рассчитывает точную зарплату без округления.
        /// </summary>
        /// <returns>Точное значение зарплаты.</returns>
        public override decimal CalculateExactSalary()
        {
            return (decimal)_monthlySalary;
        }
    }
}