using System.Globalization;
using System.Text.RegularExpressions;

namespace Model
{
    /// <summary>
    /// Базовый класс, представляющий человека.
    /// </summary>
    public abstract class PersonBase
    {
        /// <summary>
        /// Имя человека.
        /// </summary>
        private string _name;

        /// <summary>
        /// Фамилия человека.
        /// </summary>
        private string _surname;

        /// <summary>
        /// Отчество человека.
        /// </summary>
        private string _patronymic;

        /// <summary>
        /// Имя человека.
        /// </summary>
        public string Name
        {
            get => _name;
            set
            {
                CheckName(value, nameof(Name));
                _name = ToCorrectFormate(value);
            }
        }

        /// <summary>
        /// Фамилия человека.
        /// </summary>
        public string Surname
        {
            get => _surname;
            set
            {
                CheckName(value, nameof(Surname));
                _surname = ToCorrectFormate(value);
            }
        }

        /// <summary>
        /// Отчество человека.
        /// </summary>
        public string Patronymic
        {
            get => _patronymic;
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    CheckName(value, nameof(Patronymic));
                    _patronymic = ToCorrectFormate(value);
                }
                else
                {
                    _patronymic = value;
                }
            }
        }

        /// <summary>
        /// Метод проверки на язык
        /// </summary>
        private void LanguageVerification()
        {
            // Проверяем только если все обязательные поля заполнены
            if (!string.IsNullOrEmpty(_name) && !string.IsNullOrEmpty(_surname))
            {
                Language nameLanguage = LanguageDetect(_name);
                Language surnameLanguage = LanguageDetect(_surname);

                if (nameLanguage != Language.Unknown
                    && surnameLanguage != Language.Unknown
                    && nameLanguage != surnameLanguage)
                {
                    throw new FormatException("Имя и фамилия должны быть на одном языке.");
                }

                Language commonLanguage = nameLanguage != Language.Unknown
                    ? nameLanguage
                    : surnameLanguage;

                // Проверяем отчество только если оно заполнено
                if (!string.IsNullOrEmpty(_patronymic))
                {
                    Language patronymicLanguage = LanguageDetect(_patronymic);
                    if (commonLanguage != Language.Unknown
                        && patronymicLanguage != Language.Unknown
                        && commonLanguage != patronymicLanguage)
                    {
                        throw new FormatException("Отчество должно быть на том же языке, что имя и фамилия.");
                    }
                }
            }
        }

        /// <summary>
        /// Метод для определения языка с лучшей обработкой смешанного содержания
        /// </summary>
        public static Language LanguageDetect(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
                return Language.Unknown;

            var lettersOnly = Regex.Replace(text, @"[^A-Za-zА-Яа-яЁё]", "", RegexOptions.IgnoreCase);

            if (lettersOnly.Length == 0)
                return Language.Unknown;

            bool hasLatin = Regex.IsMatch(lettersOnly, @"[A-Za-z]");
            bool hasCyrillic = Regex.IsMatch(lettersOnly, @"[А-Яа-яЁё]");

            if (hasLatin && hasCyrillic)
                throw new ArgumentException($"Строка '{text}' содержит символы разных алфантов.");

            if (hasLatin) return Language.En;
            if (hasCyrillic) return Language.Ru;

            return Language.Unknown;
        }

        /// <summary>
        /// Регулярное выражение для проверки латиницы.
        /// </summary>
        private static readonly Regex _latinSymbols = new Regex(@"^[A-Za-z\- ]+$");

        /// <summary>
        /// Регулярное выражение для проверки кириллицы.
        /// </summary>
        private static readonly Regex _cyrillicSymbols = new Regex(@"^[А-Яа-яёЁ\- ]+$");

        /// <summary>
        /// Проверка полей ФИО
        /// </summary>
        private static void CheckName(string name, string argumentName)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException(
                    $"Свойство {argumentName} должно быть заполнено.");
            }

            // Убираем пробелы и дефисы для проверки
            string cleanedName = name.Replace(" ", "").Replace("-", "");

            if (string.IsNullOrEmpty(cleanedName))
            {
                throw new FormatException(
                    $"Свойство {argumentName} должно содержать буквы.");
            }

            if (!_latinSymbols.IsMatch(name) && !_cyrillicSymbols.IsMatch(name))
            {
                throw new FormatException(
                    $"Свойство {argumentName} должно быть только на кириллице или только на латинице.");
            }
        }

        /// <summary>
        /// Метод коррекции формата строки.
        /// </summary>
        private static string ToCorrectFormate(string word)
        {
            word = word.Trim();
            if (string.IsNullOrEmpty(word)) return word;

            word = word.Trim('-');
            word = Regex.Replace(word, @"--+", "-");
            return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(word.ToLower());
        }

        /// <summary>
        /// Конструктор класса Person с параметрами по умолчанию.
        /// </summary>
        public PersonBase() : this("Unknown", "Unknown", "Unknown")
        { }

        /// <summary>
        /// Конструктор класса Person.
        /// </summary>
        public PersonBase(string name, string surname, string patronymic)
        {
            // Устанавливаем значения напрямую в поля, чтобы избежать
            // множественных вызовов LanguageVerification()
            _name = ToCorrectFormate(name);
            _surname = ToCorrectFormate(surname);
            _patronymic = string.IsNullOrEmpty(patronymic) ? null : ToCorrectFormate(patronymic);

            // Выполняем проверку один раз после установки всех значений
            LanguageVerification();
        }
    }
}