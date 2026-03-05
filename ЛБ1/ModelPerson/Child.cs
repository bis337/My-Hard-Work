namespace ModelPerson
{
    using Bogus;
    using System;

    /// <summary>
    /// Класс, представляющий ребенка.
    /// </summary>
    public class Child: PersonBase
    {
        /// <summary>
        /// Отец ребенка.
        /// </summary>
        private Adult? _father;

        /// <summary>
        /// Мать ребенка.
        /// </summary>
        private Adult? _mother;

        /// <summary>
        /// Школа.
        /// </summary>
        private string _school;

        /// <summary>
        /// Школа.
        /// </summary>
        private string _kinderGarten;

        /// <summary>
        /// Минимальный возраст ребенка.
        /// </summary>
        private new const int MinAge = 0;

        /// <summary>
        /// Максимальный возраст ребенка.
        /// </summary>
        private new const int MaxAge = 17;

        /// <summary>
        /// Минимальный возраст для школы.
        /// </summary>
        public const int MinSchoolAge = 6;

        /// <summary>
        /// Отец ребенка.
        /// </summary>
        public Adult? Father
        {
            get => _father;
            set
            {
                CheckParentGender(value, Sex.Female);
                _father = value;
            }
        }

        /// <summary>
        /// Мать ребенка.
        /// </summary>
        public Adult? Mother
        {
            get => _mother;
            set
            {
                CheckParentGender(value, Sex.Male);
                _mother = value;
            }
        }

        /// <summary>
        /// Школа.
        /// </summary>
        public string? School
        {
            get => _school;
            set
            {
                if (!(string.IsNullOrWhiteSpace(value)) && Age < MinSchoolAge)
                {
                    throw new ArgumentException("Ребенок младше " +
                        $"{MinSchoolAge} лет не может ходить в школу.");
                }
                _school = value;
            }
        }

        /// <summary>
        /// Детский сад.
        /// </summary>
        public string? KinderGarten
        {
            get => _kinderGarten;
            set
            {
                if (!(string.IsNullOrWhiteSpace(value)) && Age >= MinSchoolAge)
                {
                    throw new ArgumentException("Ребенок старше " +
                        $"{MinSchoolAge} лет не может ходить в детский сад.");
                }
                _kinderGarten = value;
            }
        }

        /// <summary>
        /// Конструктор класса Child.
        /// </summary>
        /// <param name="name">Имя.</param>
        /// <param name="surname">Фамилия.</param>
        /// <param name="age">Возраст.</param>
        /// <param name="sex">Пол.</param>
        /// <param name="father">Отец.</param>
        /// <param name="mother">Мать.</param>
        /// <param name="school">Школа.</param>
        public Child(string name, string surname, int age,
            Sex sex, Adult father, Adult mother,
            string school) : base(name, surname, age, sex)
        {
            Father = father;
            Mother = mother;
            School = school;
        }

        /// <summary>
        /// Конструктор Child по-умолчанию.
        /// </summary>
        public Child() : this("Unknown", "Unknown", 11,
            Sex.Unknown, null, null, null)
        { }

        /// <summary>
        /// Проверить пол родителя.
        /// </summary>
        /// <param name="parent">Родитель.</param>
        /// <param name="gender">Сравниваемый пол.</param>
        /// <exception cref="ArgumentException">Пол родителя 
        /// задан неверно.</exception>
        private static void CheckParentGender(Adult parent, Sex sex)
        {
            if (parent != null && parent.Sex == sex)
            {
                throw new ArgumentException
                    ("Пол родителей должен быть разным");
            }
        }

        /// <summary>
        /// Генерирует случайного человека с заданной локализацией.
        /// </summary>
        /// <param name="language">Код локализации 
        /// ("ru" для русского, иначе для английского).</param>
        /// <returns>Созданный объект <see cref="Person"/> 
        /// с случайными данными.</returns>
        /// <exception cref="ArgumentException">Выбрасывается, 
        /// если данные не могут быть сгенерированы.</exception>
        /// <remarks>Использует библиотеку Bogus 
        /// для генерации случайных данных</remarks>
        public static ModelPerson.Child GetRandomChild(Language language)
        {
            ModelPerson.Child child = new ModelPerson.Child();
            var faker = language == Language.Ru
                ? new Faker("ru")
                : new Faker();

            child.Name = faker.Person.FirstName;
            child.Surname = faker.Person.LastName;
            child.Age = faker.Random.Int(ModelPerson.Child.MinAge,
                ModelPerson.Child.MaxAge);
            child.Sex = (Sex)Enum.Parse(typeof(Sex),
                faker.Person.Gender.ToString());
            if (child.Age < MinSchoolAge)
            {
                child.KinderGarten = Locale.FieldLocale[language]["KinderGarten"]
                    + " #" + faker.Random.Int(1, 100);
            }
            else
            {
                child.School = Locale.FieldLocale[language]["School"]
                    + " #" + faker.Random.Int(1, 100);
            }


            Adult tempParent = Adult.GetRandomAdult(language);
            switch (tempParent.Sex)
            {
                case Sex.Female:
                {
                    child.Mother = tempParent;
                    child.Mother.Surname = child.Surname;
                    if (tempParent.Spouse is not null)
                    {
                        child.Father = tempParent.Spouse;
                        child.Father.Surname = child.Surname;
                    }
                    break;
                }
                case Sex.Male:
                {
                    child.Father = tempParent;
                    child.Father.Surname = child.Surname;
                    if (tempParent.Spouse is not null)
                    {
                        child.Mother = tempParent.Spouse;
                        child.Mother.Surname = child.Surname;
                    }
                    break;
                }
                case Sex.Unknown:
                default:
                    break;
            }
            return child;
        }

        /// <summary>
        /// Формирует всю информацию о ребенке в строку.
        /// </summary>
        /// <returns>Информация о ребенке.</returns>
        public override string GetInfo()
        {
            var language = LanguageDetect(Name);
            //TODO: RSDN +
            var locale = Locale.FieldLocale[language];

            string fatherStatus = Father != null
                ? $"{locale["Father"]}: {Father.GetPersonNameSurname()}"
                : $"{locale["Father"]}: {locale["NoParent"]}";

            string motherStatus = Mother != null
                ? $"{locale["Mother"]}: {Mother.GetPersonNameSurname()}"
                : $"{locale["Mother"]}: {locale["NoParent"]}";

            string kinderGarndenStatus = !string.IsNullOrEmpty(School)
                ? $"{locale["Studying"]}: {School}"
                : $"{locale["NotStudying"]}";

            string schoolStatus = !string.IsNullOrEmpty(KinderGarten)
                ? $"{locale["GoesInKD"]}: {School}"
                : $"{locale["NotGoesInKD"]}";

            return $"{GetPersonInfo()};\n {fatherStatus}; " +
                $"{motherStatus}; {kinderGarndenStatus}; {schoolStatus}\n";
        }

        /// <summary>
        /// Радоваться
        /// </summary>
        /// <returns>Строка с текстом радости.</returns>
        public string ToEnjoy()
        {
            return "Шарики! (=^.^=) Бабочки! ＼(＾▽＾)／ Единороги!";
        }

        /// <summary>
        /// Проверить возраст человека.
        /// </summary>
        /// <param name="age">Person's age.</param>
        protected override void CheckAge(int age)
        {
            if (age < MinAge || age > MaxAge)
            {
                throw new ArgumentException($"Возраст должен быть " +
                    $"в диапазоне от {MinAge} до {MaxAge}");
            }
        }
    }
}
