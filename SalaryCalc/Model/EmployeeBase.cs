using System.ComponentModel;
using System.Xml.Serialization;

namespace Model
{
    /// <summary>
    /// Абстрактный базовый класс для сотрудников, реализующий интерфейс IEmployee.
    /// </summary>
    [XmlInclude(typeof(HourlyEmployee))]
    [XmlInclude(typeof(SalaryEmployee))]
    [XmlInclude(typeof(CommissionEmployee))]
    public abstract class EmployeeBase : PersonBase, IEmployee
    {
        /// <summary>
        /// Минимальное значение вводимых данных
        /// </summary>
        private const double MinValue = 0.0001;

        /// <summary>
        /// Дата приема на работу
        /// </summary>
        private DateTime _hireDate;

        /// <summary>
        /// Полное имя сотрудника.
        /// </summary>
        public new string FullName =>
            $"{Surname} {Name} {Patronymic}".Trim();

        /// <summary>
        /// Дата приема на работу в формате строки.
        /// </summary>
        /// <exception cref="ArgumentException">
        /// Выбрасывается, если дата некорректна или в будущем.
        /// </exception>
        public string HireDate
        {
            get => _hireDate.ToString("dd.MM.yyyy");
            set
            {
                if (!DateTime.TryParse(value, out DateTime date) ||
                    date > DateTime.Now)
                {
                    throw new ArgumentException(
                        "Дата приема на работу некорректна.");
                }
                _hireDate = date;
            }
        }

        /// <summary>
        /// Дата приема на работу как DateTime.
        /// </summary>
        [Browsable(false)]
        public DateTime HireDateValue => _hireDate;

        /// <summary>
        /// Параметры оплаты в отформатированном виде.
        /// </summary>
        public abstract string Parameters { get; }

        /// <summary>
        /// Объем работы в отформатированном виде.
        /// </summary>
        public abstract string Workload { get; }

        /// <summary>
        /// Информация о типе оплаты.
        /// </summary>
        public abstract string Info { get; }

        /// <summary>
        /// Инициализирует новый экземпляр класса EmployeeBase.
        /// </summary>
        protected EmployeeBase() { }

        /// <summary>
        /// Проверяет значение на корректность.
        /// </summary>
        /// <param name="value">Значение для проверки.</param>
        /// <returns>Проверенное значение.</returns>
        /// <exception cref="ArgumentException">
        /// Выбрасывается, если значение некорректно.
        /// </exception>
        protected static double CheckValue(double value)
        {
            if (double.IsNaN(value) || value <= MinValue)
            {
                throw new ArgumentException(
                    "Значение не может быть отрицательным.");
            }
            return value;
        }

        /// <summary>
        /// Рассчитывает точную зарплату без округления.
        /// </summary>
        /// <returns>Точное значение зарплаты.</returns>
        public abstract decimal CalculateExactSalary();
    }
}