using Bogus.DataSets;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Text.RegularExpressions;

namespace ModelPerson
{
    /// <summary>
    /// Класс, представляющий человека.
    /// </summary>
    public class Person
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
        /// Возраст человека.
        /// </summary>
        private int? _age;

        /// <summary>
        /// Значение по умолчанию для неизвестного имени/фамилии.
        /// </summary>
        private const string DefaultUnknownValue = "Unknown";

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
                LanguageVerification();
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
                LanguageVerification();
            }
        }

        /// <summary>
        /// Минимальный возраст персоны.
        /// </summary>
        public const int MinAge = 0;

        /// <summary>
        /// Максимальный возраст персоны.
        /// </summary>
        public const int MaxAge = 125;

        /// <summary>
        /// Возраст человека. Может быть null, если информация отсутствует.
        /// </summary>
        /// <exception cref="ArgumentException">
        /// Выбрасывается, если значение возраста находится 
        /// в диапазоне от {MinAge} до {MaxAge}. </exception >
        public int? Age
        {
            get { return _age; }
            set
            {
                if (value == null)
                {
                    _age = null;
                }
                else if ((value < MinAge) ||
                    (value > MaxAge))
                {
                    throw new ArgumentException(
                        $"Возраст должен быть  " +
                        $"в диапазоне от {MinAge} до {MaxAge} ");
                }
                else
                {
                    _age = value;
                }
            }
        }


        /// <summary>
        /// Пол человека.
        /// </summary>
        public Sex Sex { get; set; }

        /// <summary>
        /// Конструктор класса Person с параметрами по умолчанию.
        /// </summary>
        public Person() : this(DefaultUnknownValue,
                               DefaultUnknownValue,
                               99, Sex.Unknown)
        { }

        /// <summary>
        /// Конструктор класса Person.
        /// </summary>
        /// <param name="name">Имя человека.</param>
        /// <param name="surname">Фамилия человека.</param>
        /// <param name="age">Возраст человека.</param>
        /// <param name="sex">Пол человека.</param>
        public Person(string name, string surname, int? age, Sex sex)
        {
            Name = name;
            Surname = surname;
            Age = age;
            Sex = sex;
        }

        /// <summary>
        /// Регулярное выражение для проверки допустимых символов 
        /// Также используется для определения латиницы и кириллицы.
        /// </summary>
        /// //TODO: duplication
        private static readonly Regex _validNamePattern = new Regex(@"^[a-zA-Zа-яёА-ЯЁ\s\-']+$");


        /// <summary>
        /// Проверяет, содержит ли строка латинские и/или кириллические буквы.
        /// </summary>
        /// <param name="name">Строка для проверки.</param>
        /// <returns>Кортеж с флагами: Item1 - содержит латиницу, 
        /// Item2 - содержит кириллицу.</returns>
        private static (bool hasLatin,
            bool hasCyrillic) ContainsLatinOrCyrillic(string name)
        {
            bool hasLatin = Regex.IsMatch(name, @"[a-zA-Z]");
            bool hasCyrillic = Regex.IsMatch(name, @"[а-яёА-ЯЁ]");
            return (hasLatin, hasCyrillic);
        }

        /// <summary>
        /// Метод для определения языка на основе имени
        /// </summary>
        /// <param name="name">Имя для анализа.</param>
        /// <returns>Код языка ("ru-RU", "en-EN", 
        /// "mix" или "неизвестный язык").</returns>
        public static Language LanguageDetect(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return Language.Unknown;
            }

            var (hasLatin, hasCyrillic) = ContainsLatinOrCyrillic(name);

            if (hasLatin && !hasCyrillic)
            {
                return Language.En;
            }
            else if (hasCyrillic && !hasLatin)
            {
                return Language.Ru;
            }
            else if (hasLatin && hasCyrillic)
            {

                return Language.Unknown;
            }
            else
            {

                if (!_validNamePattern.IsMatch(name))
                {
                    throw new ArgumentException($"Некорректный ввод. " +
                        $" Пожалуйста, попробуйте снова! ");
                }

                return Language.Unknown;
            }
        }

        /// <summary>
        /// Метод проверки на язык
        /// </summary>
        /// <exception cref="FormatException"> </exception>
        private void LanguageVerification()
        {
            if (!string.IsNullOrEmpty(_name)
                && !string.IsNullOrEmpty(_surname)
                 && _name != DefaultUnknownValue
                    && _surname != DefaultUnknownValue)
            {
                Language firstNameLanguage = LanguageDetect(_name);
                Language lastNameLanguage = LanguageDetect(_surname);

                if (firstNameLanguage != Language.Unknown
                    && lastNameLanguage != Language.Unknown
                    && firstNameLanguage != lastNameLanguage)
                {
                    throw new FormatException("Имя и фамилия  " +
                        "должны быть на одном языке. ");
                }
            }
        }


        /// <summary>
        /// Проверка формата имени и фамилии
        /// </summary>
        /// <param name="name">Имя в формате строки</param>
        private void CheckName(string name, string argumentName)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException(
                    argumentName,
                    $"Свойство {argumentName} должно быть заполнено. ");
            }
            if (!_validNamePattern.IsMatch(name))
            {
                throw new FormatException(
                    $"Свойство {argumentName} должно содержать только" +
                    $" буквы, пробелы, тире и апострофы. ");
            }

            var (hasLatin, hasCyrillic) = ContainsLatinOrCyrillic(name);

            if ((hasLatin && hasCyrillic) || (!hasLatin && !hasCyrillic))
            {
                throw new FormatException(
                    $"Свойство {argumentName} должно быть только на кириллице, " +
                    $" либо только на латинице. ");
            }
        }

        /// <summary>
        /// Производит форматирование имени или фамилии.
        /// </summary>
        /// <param name="word">Имя или фамилия пользователя</param>
        /// <returns>Отформатированное имя или фамилия 
        /// с заглавной первой буквой.</returns>
        private static string ToCorrectFormate(string word)
        {
            word = word.Trim('-');
            word = System.Text.RegularExpressions.Regex.Replace(word, "--+", "-");

            TextInfo textInfo = CultureInfo.CurrentCulture.TextInfo;

            return textInfo.ToTitleCase(word.ToLower());
        }
    }
}