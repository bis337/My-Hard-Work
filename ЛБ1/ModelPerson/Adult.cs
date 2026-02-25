using Bogus;

namespace ModelPerson
{
    /// <summary>
    /// Класс, представляющий взрослого.
    /// </summary>
    public class Adult: PersonBase
    {
        /// <summary>
        /// Супруг
        /// </summary>
        private Adult? _spouse;

        /// <summary>
        /// Минимальный возраст взрослого.
        /// </summary>
        public new const int MinAge = 18;

        /// <summary>
        /// Максимальный возраст взрослого.
        /// </summary>
        public new const int MaxAge = 125;


        /// <summary>
        /// Паспорт взрослого.
        /// </summary>
        public Passport Passport { get; set; }


        /// <summary>
        /// Работодатель.
        /// </summary>
        public string? Employer { get; set; }

        /// <summary>
        /// Супруг.
        /// </summary>
        public Adult? Spouse 
        {
            get => _spouse;
            set 
            {
                CheckSpouseGender(value);
                _spouse = value;
            }
        }

        /// <summary>
        /// Конструктор взрослого.
        /// </summary>
        /// <param name="name">Имя персоны.</param>
        /// <param name="surname">Фамилия персоны.</param>
        /// <param name="age">Возраст персоны.</param>
        /// <param name="sex">Пол персоны.</param>
        /// <param name="passport">Паспорт персоны.</param>
        /// <param name="spouse">Супруг.</param>
        /// <param name="employer">Работодатель.</param>
        public Adult(string name, string surname, int age,
            Sex sex, Passport passport, Adult spouse,
            string employer) : base(name, surname, age, sex)
        {
            Passport = passport;
            Employer = employer;
            Spouse = spouse;
        }

        /// <summary>
        /// Конструктор по-умолчанию.
        /// </summary>
        public Adult() : this("Unknown", "Unknown", 19,
            Sex.Unknown, new Passport(), spouse: null, employer: null)
        { }
        

        /// <summary>
        /// Метод создающий случайного взрослого
        /// </summary>
        /// <param name="language"></param>
        /// <returns></returns>
        public static Adult GetRandomAdult(Language language)
        {
            ModelPerson.Adult adult = new ModelPerson.Adult();
            var faker = language == Language.Ru
                ? new Faker("ru")
                : new Faker();

            adult.Name = faker.Person.FirstName;
            adult.Surname = faker.Person.LastName;
            adult.Age = faker.Random.Int(ModelPerson.Adult.MinAge,
                ModelPerson.Adult.MaxAge);
            adult.Sex = (Sex)Enum.Parse(typeof(Sex), 
                faker.Person.Gender.ToString());

            var passportSeries = faker.Random.Int(
                Passport.PassportSeriesLowBound + 1,
                Passport.PassportSeriesHighBound -1 );
            var passportNumber = faker.Random.Int(
                Passport.PassportNumberLowBound + 1,
                Passport.PassportNumberHighBound - 1);
            adult.Passport = new Passport(passportSeries, passportNumber);
            adult.Employer = faker.Person.Company.Name;

            bool isMarried = faker.Random.Bool();

            if (isMarried)
            {
                adult.Spouse = adult.GetRandomAdultSpouse(language);
            }

            return adult;
        }


        /// <summary>
        /// Метод создающий случайного супруга для взрослого
        /// </summary>
        /// <param name="language"></param>
        /// <returns></returns>
        public Adult GetRandomAdultSpouse(Language language)
        {
            ModelPerson.Adult adult = new ModelPerson.Adult();

            while (this.Sex == adult.Sex || adult.Sex == Sex.Unknown)
            {
                var faker = language == Language.Ru
                    ? new Faker("ru")
                    : new Faker();
                adult.Name = faker.Person.FirstName;
                adult.Surname = faker.Person.LastName;

                adult.Age = faker.Random.Int(ModelPerson.Adult.MinAge + 1,
                    ModelPerson.Adult.MaxAge - 1);
                adult.Sex = (Sex)Enum.Parse(typeof(Sex), 
                    faker.Person.Gender.ToString());

                var passportSeries = faker.Random.Int(
                    Passport.PassportSeriesLowBound + 1, 
                    Passport.PassportSeriesHighBound - 1);
                var passportNumber = faker.Random.Int(
                    Passport.PassportNumberLowBound + 1,
                    Passport.PassportNumberHighBound - 1);
                adult.Passport = new Passport(passportSeries, passportNumber);
                adult.Employer = faker.Person.Company.Name;

            }
            adult.Surname = this.Surname;
            adult.Spouse = this;

            return adult;
        }

        /// <summary>
        /// Формирует всю информацию о взрослом в строку.
        /// </summary>
        /// <returns>Информация о взрослом.</returns>
        public override string GetInfo()
        {
            var marrigaeStatus = "Not married";
            if (Spouse != null)
            {
                marrigaeStatus = $"Married to:" +
                    $" {Spouse.GetPersonNameSurname()}";
            }

            var employerStatus = "Unemployed";
            if (!string.IsNullOrEmpty(Employer))
            {
                employerStatus = $"Current job: {Employer}";
            }

            return $"{GetPersonInfo()};\n " +
                $"Passport number: {Passport.Series} {Passport.Number};" +
                $" {marrigaeStatus}; {employerStatus}\n ";

        }

        /// <summary>
        /// Поныть
        /// </summary>
        public void ToWhine()
        {
            Console.WriteLine("Опять счета, опять аврал, (-_-#)");
            Console.WriteLine("А кофе стынет – я устал… (Х_х)");
            Console.WriteLine("Когда же отпуск, где мой рай? (T_T)");
            Console.WriteLine("Откройте дверь, я просто поныть! (u_u)");
        }

        /// <summary>
        /// Проверить пол супруга.
        /// </summary>
        private void CheckSpouseGender(Adult spouse)
        {
            if (spouse is not null) 
            {
                if (Sex == spouse.Sex)
                {
                    throw new ArgumentException
                        ("Пол супруга должен быть другим");
                }
            }
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
