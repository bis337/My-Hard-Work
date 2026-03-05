namespace ModelPerson
{
    /// <summary>
    /// Паспорт человека
    /// </summary>
    public class Passport
    {
        /// <summary>
        /// Номер паспорта.
        /// </summary>
        private int _series;

        /// <summary>
        /// Номер паспорта.
        /// </summary>
        private int _number;

        /// <summary>
        /// Номер паспорта.
        /// </summary>
        public int Series
        {
            get { return _series; }
            set
            {
                //TODO: rewrite
                CheckPassportSeries(value);
                _series = value;
            }
        }

        /// <summary>
        /// Номер паспорта.
        /// </summary>
        public int Number
        {
            get { return _number; }
            set
            {
                //TODO: rewrite
                CheckPassportNumber(value);
                _number = value;
            }
        }

        /// <summary>
        /// Нижняя граница номера паспорта.
        /// </summary>
        public const int PassportSeriesLowBound = 100;

        /// <summary>
        /// Верхняя граница номера паспорта.
        /// </summary>
        public const int PassportSeriesHighBound = 9999;

        /// <summary>
        /// Нижняя граница номера паспорта.
        /// </summary>
        public const int PassportNumberLowBound = 0;

        /// <summary>
        /// Верхняя граница номера паспорта.
        /// </summary>
        public const int PassportNumberHighBound = 999999;


        /// <summary>
        /// Конструктор класса Person с параметрами по умолчанию.
        /// </summary>
        public Passport() : this(6715,
                               513313)
        { }

        /// <summary>
        /// Конструктор класса Passport.
        /// </summary>
        /// <param name="series">Имя человека.</param>
        /// <param name="number">Фамилия человека.</param>
        public Passport(int series, int number)
        {
            Series = series;
            Number = number;
        }

        //TODO: remove
        /// <summary>
        /// Проверить серию паспорта человека.
        /// </summary>
        /// <param name="passportSeries">Серия паспорта человека.</param>
        private static void CheckPassportSeries(int passportSeries)
        {
            CheckPassportValue(
                passportSeries,
                PassportSeriesLowBound,
                PassportSeriesHighBound,
                "Серия паспорта");
        }

        //TODO: remove
        /// <summary>
        /// Проверить номер паспорта человека.
        /// </summary>
        /// <param name="passportNumber">Номер паспорта человека.</param>
        private static void CheckPassportNumber(int passportNumber)
        {
            CheckPassportValue(
                passportNumber,
                PassportNumberLowBound,
                PassportNumberHighBound,
                "Номер паспорта");
        }

        /// <summary>
        /// Проверить значение паспорта на соответствие диапазону.
        /// </summary>
        /// <param name="value">Значение для проверки.</param>
        /// <param name="min">Минимальная граница.</param>
        /// <param name="max">Максимальная граница.</param>
        /// <param name="fieldName">Название поля для сообщения об ошибке.</param>
        private static void CheckPassportValue(
            int value,
            int min,
            int max,
            string fieldName)
        {
            if (value < min || value > max)
            {
                throw new ArgumentException($"{fieldName} должен" +
                    $" быть в диапазоне [{min}:{max}]");
            }
        }
    }
}
