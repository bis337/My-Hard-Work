using System.Globalization;
using System.Text.RegularExpressions;

namespace ModelPerson
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
        /// Возраст человека.
        /// </summary>
        private int _age;

        /// <summary>
        /// Флаг добавляющий проверку языка
        /// </summary>
        private bool _languageCheckFlag = false;

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
        public readonly int MinAge = 0;

        /// <summary>
        /// Максимальный возраст персоны.
        /// </summary>
        public readonly int MaxAge = 125;

        /// <summary>
        /// Возраст человека. Может быть null, если информация отсутствует.
        /// </summary>
        /// <exception cref="ArgumentException">
        /// Выбрасывается, если значение возраста находится 
        /// вне допустимого диапазона (0-125).</exception>
        public int Age
        {
            get { return _age; }
            set
            {
                CheckAge(value);
                _age = value;
            }
        }


        /// <summary>
        /// Пол человека.
        /// </summary>
        public Sex Sex { get; set; }

        /// <summary>
        /// Конструктор класса Person с параметрами по умолчанию.
        /// </summary>
        public PersonBase() : this("Unknown",
                               "Unknown",
                               99, Sex.Unknown)
        { }

        /// <summary>
        /// Конструктор класса Person.
        /// </summary>
        /// <param name="name">Имя человека.</param>
        /// <param name="surname">Фамилия человека.</param>
        /// <param name="age">Возраст человека.</param>
        /// <param name="sex">Пол человека.</param>
        public PersonBase(string name, string surname, int age, Sex sex)
        {
            Name = name;
            Surname = surname;
            Age = age;
            Sex = sex;
            
        }

        /// <summary>
        /// Регулярное выражение для определения латиницы (только буквы и дефис).
        /// </summary>
        private static readonly Regex _latinSymbols = new Regex(@"^[A-Za-z]+(?:-[A-Za-z]+)*$");

        /// <summary>
        /// Регулярное выражение для определения кириллицы (только буквы и дефис).
        /// </summary>
        private static readonly Regex _cyrillicSymbols = new Regex(@"^[А-Яа-яЁё]+(?:-[А-Яа-яЁё]+)*$");

        /// <summary>
        /// Метод для определения языка на основе имени
        /// </summary>
        /// <param name="name">Имя для анализа.</param>
        /// <returns>Код языка ("ru-RU", "en-EN", 
        /// "mix" или "неизвестный язык").</returns>
        public static Language LanguageDetect(string name)
        {
            if (!string.IsNullOrEmpty(name))
            {
                if (_latinSymbols.IsMatch(name))
                {
                    return Language.En;
                }
                else if (_cyrillicSymbols.IsMatch(name))
                {
                    return Language.Ru;
                }
                else
                {
                    throw new ArgumentException($"Некорректный ввод." +
                        $" Пожалуйста, попробуйте снова!");
                }
            }

            return Language.Unknown;
        }

        /// <summary>
        /// Метод проверки на язык
        /// </summary>
        /// <exception cref="FormatException"></exception>
        private void LanguageVerification()
        {
            if (!string.IsNullOrEmpty(_name)
                && !string.IsNullOrEmpty(_surname)
                && _languageCheckFlag)
            {
                Language firstNameLanguage = LanguageDetect(_name);
                Language lastNameLanguage = LanguageDetect(_surname);

                if (firstNameLanguage != Language.Unknown
                    && lastNameLanguage != Language.Unknown
                    && firstNameLanguage != lastNameLanguage)
                {
                    throw new FormatException("Имя и фамилия " +
                        "должны быть на одном языке.");
                }
                _languageCheckFlag = false;
            }
            else
            {
                _languageCheckFlag = true;
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
                    $"Свойство {argumentName} должно быть заполнено.");
            }

            if (!_latinSymbols.IsMatch(name) 
                && !_cyrillicSymbols.IsMatch(name))
            {
                throw new FormatException(
                    $"Свойство {argumentName} должно быть только на кириллице," +
                    $" либо только на латинице.");
            }
        }


        /// <summary>
        /// Производит валидацию и форматирование имени или фамилии.
        /// </summary>
        /// <param name="word">Имя или фамилия пользователя</param>
        /// <returns>Отформатированное имя или фамилия 
        /// с заглавной первой буквой.</returns>
        private static string ToCorrectFormate(string word)
        {
            word = word.Trim('-');
            word = Regex.Replace(word, "--+", "-");
            return CultureInfo.CurrentCulture.TextInfo.
                ToTitleCase(word.ToLower());
        }

        /// <summary>
        /// Получить информацию о персоне на заданном языке.
        /// </summary>
        /// <returns>Информация о персоне.</returns>
        public string GetPersonInfo()
        {
            var language = LanguageDetect(Name);

            string ageLabel = Locale.FieldLocale[language]["Age"];
            string sexLabel = Locale.FieldLocale[language]["Sex"];
            string sexValue = Locale.SexLocale[language][Sex];
            return $"{Name} {Surname}: {ageLabel} — {Age}; " +
                $"{sexLabel} — {sexValue}";
        }

        /// <summary>
        /// Получить имя и фамилию персоны.
        /// </summary>
        /// <returns>Имя и фамилия персоны.</returns>
        public string GetPersonNameSurname()
        {
            return $"{Name} {Surname}";
        }

        /// <summary>
        /// Получить информацию о персоне.
        /// </summary>
        /// <returns>Информация о персоне.</returns>
        public abstract string GetInfo();

        /// <summary>
        /// Проверить возраст человека.
        /// </summary>
        /// <param name="age">Person's age.</param>
        protected virtual void CheckAge(int age)
        {
            if (age < MinAge || age > MaxAge)
            {
                throw new ArgumentException($"Возраст должен быть " +
                    $"в диапазоне от {MinAge} до {MaxAge}");
            }
        }
    }
}
