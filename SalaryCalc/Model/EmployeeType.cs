namespace Model
{
    /// <summary>
    /// Перечисление, представляющее тип оплаты труда сотрудника.
    /// </summary>
    public enum EmployeeType
    {
        /// <summary>
        /// Элемент перечисления "почасовая оплата".
        /// </summary>
        Hourly,

        /// <summary>
        /// Элемент перечисления "оплата по окладу".
        /// </summary>
        Salary,

        /// <summary>
        /// Элемент перечисления "оплата по ставке".
        /// </summary>
        Commission
    }
}