namespace Model
{
    /// <summary>
    /// Представляет данные фигуры для сохранения и загрузки.
    /// </summary>
    public class ShapeData
    {
        /// <summary>
        /// Получает или задает тип фигуры.
        /// </summary>
        public string Type { get; set; } = string.Empty;

        /// <summary>
        /// Получает или задает первое значение фигуры.
        /// </summary>
        public double Value1 { get; set; }

        /// <summary>
        /// Получает или задает второе значение фигуры.
        /// </summary>
        public double Value2 { get; set; }

        /// <summary>
        /// Получает или задает третье значение фигуры.
        /// </summary>
        public double Value3 { get; set; }
    }
}