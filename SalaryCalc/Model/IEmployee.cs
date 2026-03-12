namespace Model
{
    /// <summary>
    /// Интерфейс, представляющий сотрудника фирмы.
    /// </summary>
    public interface IEmployee
    {
        /// <summary>
        /// Имя сотрудника.
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// Фамилия сотрудника.
        /// </summary>
        string Surname { get; set; }

        /// <summary>
        /// Отчество сотрудника.
        /// </summary>
        string? Patronymic { get; set; }

        /// <summary>
        /// Полное имя сотрудника.
        /// </summary>
        string FullName { get; }

        /// <summary>
        /// Дата приема на работу в формате строки.
        /// </summary>
        string HireDate { get; set; }

        /// <summary>
        /// Параметры оплаты в отформатированном виде.
        /// </summary>
        string Parameters { get; }

        /// <summary>
        /// Объем работы в отформатированном виде.
        /// </summary>
        string Workload { get; }

        /// <summary>
        /// Информация о типе оплаты.
        /// </summary>
        string Info { get; }

        /// <summary>
        /// Рассчитывает точную зарплату без округления.
        /// </summary>
        /// <returns>Точное значение зарплаты.</returns>
        decimal CalculateExactSalary();
    }
}
