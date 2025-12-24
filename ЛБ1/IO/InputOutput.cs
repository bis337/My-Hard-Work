using Bogus;
using ModelPerson;
using System.Globalization;
using System.Text.RegularExpressions;

namespace IO
{
    /// <summary>
    /// Класс для чтения и записи данных о персоне.
    /// </summary>
    public class InputOutput
    {
        /// <summary>
        /// Читает информацию о персоне с консоли и возвращает объект 
        /// <see cref="ModelPerson.Person"/>.
        /// </summary>
        /// <returns>Объект <see cref="ModelPerson.Person"/> 
        /// с данными, введенными пользователем.</returns>
        public static ModelPerson.Person ReadPerson()
        {
            ModelPerson.Person personReader = new ModelPerson.Person();

            var actionList = new List<PropertyHandlerDTO>
            {
                new PropertyHandlerDTO("имя",
                    new List<Type>
                        {
                           typeof(ArgumentNullException),
                           typeof(FormatException),
                        },
                    () => { personReader.Name = Console.ReadLine(); }),
                 new PropertyHandlerDTO("фамилию",
                    new List<Type>
                        {
                           typeof(ArgumentNullException),
                           typeof(FormatException),
                        },
                    () => { personReader.Surname = Console.ReadLine(); }),
                  new PropertyHandlerDTO("возраст",
                    new List<Type>
                        {
                           typeof(ArgumentException),
                           typeof(FormatException),
                        },
                    () => { string input = Console.ReadLine();
                        personReader.Age = string.IsNullOrEmpty(input)
                        ? null
                        : Convert.ToInt32(input); }),
                   new PropertyHandlerDTO("пол",
                    new List<Type>
                        {
                           typeof(ArgumentException),
                        },
                    () => { string[] sex_male_list = 
                        ["мужчина", "м", "1", "man", "m"];
                            string[] sex_female_list = 
                        ["женщина", "ж", "0", "woman", "w"];
                            string ReadSexPerson = Console.ReadLine();
                            if (string.IsNullOrEmpty(ReadSexPerson))
                            { 
                                personReader.Sex = Sex.Unknown;
                            }
                            else if (sex_male_list.Contains(ReadSexPerson.
                                ToLower()))
                            {
                                personReader.Sex = Sex.Male;
                            }
                            else if (sex_female_list.Contains(ReadSexPerson.
                                ToLower()))
                            {
                                personReader.Sex = Sex.Female;
                            }
                            else
                            {
                                throw new ArgumentException(
                                    "Для мужчин значения пола могут иметь " +
                                    "значения 'мужчина', 'м', '1', 'man', 'm'\n" +
                                    "Для женщин значения пола могут иметь " +
                                    "значения 'женщина', 'ж', '0', 'woman', 'w'");
                            }
                            })

            };

            for (int i = 0; i < actionList.Count; i++)
            {
                PersonPropertiesHandler(actionList[i]);
            }

            WritePerson(personReader);
            return personReader;
        }

        /// <summary>
        /// Метод распаковки actionList
        /// </summary>
        /// <param name="propertyHandelerDto">actionList</param>
        private static void PersonPropertiesHandler(
            PropertyHandlerDTO propertyHandelerDto)
        {
            var personField = propertyHandelerDto.PropertyName;
            var personTypes = propertyHandelerDto.ExceptionTypes;
            var personAction = propertyHandelerDto.PropertyHandlingAction;
            Console.WriteLine($"Введите {personField} персоны:");
            while (true)
            {
                try
                {
                    personAction.Invoke();
                    break;
                }
                catch (Exception ex)
                {
                    if (personTypes.Contains(ex.GetType()))
                    {
                        Console.WriteLine(ex.Message);
                        Console.WriteLine($"Введите {personField} заново");
                        continue;
                    }
                    throw ex;
                }
            }
        }

        /// <summary>
        /// Выводит информацию о персоне в консоль 
        /// в формате "Имя Фамилия, Возраст, Пол".
        /// </summary>
        public static void WritePerson(ModelPerson.Person person)
        {
            Language language = ModelPerson.Person.LanguageDetect(person.Name);
            string age;
            if (person.Age.HasValue)
            {
                age = person.Age.Value.ToString();
            }
            else
            {
               age = language == Language.Ru 
                    ? "нет информации о возрасте" 
                    : "no info about age";
            }
            string sex = _sexLocale[language][person.Sex];
            Console.WriteLine($"{person.Name} {person.Surname}, {age}, {sex};");
        }

        /// <summary>
        /// Выводит информацию о всех персонах в списке в консоль.
        /// </summary>
        public static void WritePersons((string listName, PersonList personList) list)
        {
            if (list.personList.Count == 0)
            {
                Console.WriteLine($"Список {list.listName} пуст.");
                return;
            }
            else
            {
                Console.WriteLine($"Список {list.listName}:");
                foreach (ModelPerson.Person person in list.personList)
                {
                    WritePerson(person);
                }
            }
        }

        /// <summary>
        /// Преобразует строку в тип перечисления "Пол".
        /// </summary>
        /// <param name="strSex"> - пол в формате строки.</param>
        /// <returns>Элемент перечисления <see cref="Sex"/>.</returns>
        public static Sex StringToSex(string strSex)
        {
            switch (strSex.ToLower())
            {
                case "женщина":
                case "ж":
                case "female":
                case "f":
                case "0":
                    return Sex.Female;
                case "мужчина":
                case "м":
                case "male":
                case "m":
                case "1":
                    return Sex.Male;
                default:
                    return Sex.Unknown;
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
        public static ModelPerson.Person GetRandomPerson(Language language)
        {
            ModelPerson.Person person = new ModelPerson.Person();
            if (language == Language.Ru)
            {
                var fakerRu = new Faker("ru");

                person.Name = fakerRu.Person.FirstName;
                person.Surname = fakerRu.Person.LastName;
                person.Age = fakerRu.Random.Int(ModelPerson.Person.MinAge, 
                    ModelPerson.Person.MaxAge);
                person.Sex = StringToSex(fakerRu.Person.Gender.ToString());
            }
            else
            {
                var fakerEn = new Faker();

                person.Name = fakerEn.Person.FirstName;
                person.Surname = fakerEn.Person.LastName;
                person.Age = fakerEn.Random.Int(ModelPerson.Person.MinAge, 
                    ModelPerson.Person.MaxAge);
                person.Sex = StringToSex(fakerEn.Person.Gender.ToString());
            }
            return person;
        }

        /// <summary>
        /// Создает список случайных персон.
        /// </summary>
        /// <param name="listName">Имя списка.</param>
        /// <param name="language">Локаль для генерации случайных данных.</param>
        /// <param name="count">Количество персон в списке.</param>
        /// <returns>Список случайных персон.</returns>
        public static (string, PersonList) GetRandomPersonList(
            string listName, Language language, int count)
        {
            PersonList personList = new PersonList();
            for (int i = 0; i < count; i++)
            {
                personList.AddPerson(GetRandomPerson(language));
            }
            return (listName, personList);
        }


        /// <summary>
        /// Для возможности вывода информации о поле на разных языках 
        /// </summary>
        private static Dictionary<Language, Dictionary<Sex, string>> _sexLocale =
            new Dictionary<Language, Dictionary<Sex, string>>()
            {
                { 
                    Language.Ru, new Dictionary<Sex, string>() 
                    {
                        { Sex.Female,   "женщина" },
                        { Sex.Male,     "мужчина" },
                        { Sex.Unknown,  "нет информации о поле" },
                    }
                },
                {
                    Language.En, new Dictionary<Sex, string>() 
                    {
                        { Sex.Female,   "female" },
                        { Sex.Male,     "male" },
                        { Sex.Unknown,  "no information about the sex" },
                    }
                }
            };

        /// <summary>
        /// 
        /// </summary>
        /// <param name="text"></param>
        /// <param name="color"></param>
        public static void WriteTextColorful(string text, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(text);
            Console.ResetColor();
        }
    }
}
