namespace Model
{
    /// <summary>
    /// Сотрудник с почасовой оплатой труда.
    /// </summary>
    [Serializable]
    public class HourlyEmployee : EmployeeBase
    {
        /// <summary>
        /// Почасовая ставка.
        /// </summary>
        private double _hourlyRate;

        /// <summary>
        /// Отработанные часы.
        /// </summary>
        private double _hoursWorked;

        /// <summary>
        /// Почасовая ставка.
        /// </summary>
        public double HourlyRate
        {
            get => _hourlyRate;
            set => _hourlyRate = CheckValue(value);
        }

        /// <summary>
        /// Отработанные часы.
        /// </summary>
        /// <exception cref="ArgumentException">
        /// Выбрасывается, если количество часов превышает 744.
        /// </exception>
        public double HoursWorked
        {
            get => _hoursWorked;
            set
            {
                if (value > 744)
                {
                    throw new ArgumentException(
                        "Количество часов не может превышать 744.");
                }
                _hoursWorked = CheckValue(value);
            }
        }

        /// <summary>
        /// Параметры оплаты в отформатированном виде.
        /// </summary>
        public override string Parameters =>
            $"Ставка = {_hourlyRate:F1} руб./час, " +
            $"Часы = {_hoursWorked:F1} ч.";

        /// <summary>
        /// Объем работы в отформатированном виде.
        /// </summary>
        public override string Workload => $"{_hoursWorked:F1} ч.";

        /// <summary>
        /// Информация о типе оплаты.
        /// </summary>
        public override string Info => "Почасовая оплата";

        /// <summary>
        /// Инициализирует новый экземпляр класса HourlyEmployee.
        /// </summary>
        public HourlyEmployee() { }

        /// <summary>
        /// Инициализирует новый экземпляр класса HourlyEmployee 
        /// с указанными параметрами.
        /// </summary>
        /// <param name="name">Имя сотрудника.</param>
        /// <param name="surname">Фамилия сотрудника.</param>
        /// <param name="patronymic">Отчество сотрудника.</param>
        /// <param name="hireDate">Дата приема на работу.</param>
        /// <param name="hourlyRate">Почасовая ставка.</param>
        /// <param name="hoursWorked">Отработанные часы.</param>
        public HourlyEmployee(string name, string surname, string patronymic,
            string hireDate, double hourlyRate, double hoursWorked)
        {
            Name = name;
            Surname = surname;
            Patronymic = patronymic;
            HireDate = hireDate;
            HourlyRate = hourlyRate;
            HoursWorked = hoursWorked;
        }

        /// <summary>
        /// Рассчитывает точную зарплату без округления.
        /// </summary>
        /// <returns>Точное значение зарплаты.</returns>
        public override decimal CalculateExactSalary()
        {
            return (decimal)(_hourlyRate * _hoursWorked);
        }
    }
}