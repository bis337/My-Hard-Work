namespace Model
{
    /// <summary>
    /// Сотрудник с комиссионной оплатой труда.
    /// </summary>
    [Serializable]
    public class CommissionEmployee : EmployeeBase
    {
        /// <summary>
        /// Ставка комиссии (от 0 до 1).
        /// </summary>
        private double _commissionRate;

        /// <summary>
        /// Сумма продаж.
        /// </summary>
        private double _salesAmount;

        /// <summary>
        /// Ставка комиссии (от 0 до 1).
        /// </summary>
        /// <exception cref="ArgumentException">
        /// Выбрасывается, если значение больше 1.
        /// </exception>
        public double CommissionRate
        {
            get => _commissionRate;
            set
            {
                if (value > 1)
                {
                    throw new ArgumentException(
                        "Ставка комиссии не может превышать 1.");
                }
                _commissionRate = CheckValue(value);
            }
        }

        /// <summary>
        /// Сумма продаж.
        /// </summary>
        public double SalesAmount
        {
            get => _salesAmount;
            set => _salesAmount = CheckValue(value);
        }

        /// <summary>
        /// Параметры оплаты в отформатированном виде.
        /// </summary>
        public override string Parameters =>
            $"Ставка = {_commissionRate * 100:F1}%, " +
            $"Продажи = {_salesAmount:F0} руб.";

        /// <summary>
        /// Объем работы в отформатированном виде.
        /// </summary>
        public override string Workload => $"{_salesAmount:F0} руб.";

        /// <summary>
        /// Информация о типе оплаты.
        /// </summary>
        public override string Info => "Комиссионная ставка";

        /// <summary>
        /// Инициализирует новый экземпляр класса CommissionEmployee.
        /// </summary>
        public CommissionEmployee() { }

        /// <summary>
        /// Инициализирует новый экземпляр класса CommissionEmployee 
        /// с указанными параметрами.
        /// </summary>
        /// <param name="name">Имя сотрудника.</param>
        /// <param name="surname">Фамилия сотрудника.</param>
        /// <param name="patronymic">Отчество сотрудника.</param>
        /// <param name="hireDate">Дата приема на работу.</param>
        /// <param name="commissionRate">Ставка комиссии.</param>
        /// <param name="salesAmount">Сумма продаж.</param>
        public CommissionEmployee(string name, string surname, string patronymic,
            string hireDate, double commissionRate, double salesAmount)
        {
            Name = name;
            Surname = surname;
            Patronymic = patronymic;
            HireDate = hireDate;
            CommissionRate = commissionRate;
            SalesAmount = salesAmount;
        }

        /// <summary>
        /// Рассчитывает точную зарплату без округления.
        /// </summary>
        /// <returns>Точное значение зарплаты.</returns>
        public override decimal CalculateExactSalary()
        {
            return (decimal)(_commissionRate * _salesAmount);
        }
    }
}