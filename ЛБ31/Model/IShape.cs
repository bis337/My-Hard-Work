namespace Model
{
    /// <summary>
    /// Представляет интерфейс геометрической фигуры.
    /// </summary>
    public interface IShape
    {
        /// <summary>
        /// Получает название фигуры.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Вычисляет площадь фигуры.
        /// </summary>
        /// <returns>Площадь фигуры.</returns>
        double CalculateArea();

        /// <summary>
        /// Вычисляет периметр фигуры.
        /// </summary>
        /// <returns>Периметр фигуры.</returns>
        double CalculatePerimeter();
    }
}
