namespace Model
{
    //TODO: WTF?
    /// <summary>
    /// Представляет DTO-объект фигуры. (объекты для передачи данных)
    /// </summary>
    public class ShapeDto
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