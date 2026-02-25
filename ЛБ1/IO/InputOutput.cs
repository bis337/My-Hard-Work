using ModelPerson;

namespace IO
{
    /// <summary>
    /// Класс для чтения и записи данных о персоне.
    /// </summary>
    public class InputOutput
    {
        /// <summary>
        /// Метод для чтения информаации о человеке с консоли
        /// </summary>
        /// <param name="person"></param>
        public static void ReadProperties(PersonBase person)
        {
            switch (person)
            {
                case Adult adult:
                {
                    WriteTextColorful("Ввод данных о взрослом", ConsoleColor.Cyan);
                    ReadBaseProperties(adult);
                    ReadAdultProperties(adult);
                    break;
                }
                case Child child:
                {
                    WriteTextColorful("Ввод данных о ребенке", ConsoleColor.Cyan);
                    ReadBaseProperties(child);
                    ReadChildProperties(child);
                    break;
                }
            }
        }

        /// <summary>
        /// Обобщённая версия метода ReadProperties: 
        /// принимает объект и возвращает его после заполнения.
        /// </summary>
        public static T ReadProperties<T>(T person) where T : PersonBase
        {
            ReadProperties((PersonBase)person);
            return person;
        }


        /// <summary>
        /// Выводит информацию о персоне в консоль 
        /// в формате "Имя Фамилия, Возраст, Пол".
        /// </summary>
        public static void WritePerson(ModelPerson.PersonBase person)
        {
            if (person is not null)
            {
                string info = person.GetInfo();
                Console.WriteLine(info);
            }
            else
            {
                Console.WriteLine("No info");
            }
        }

        /// <summary>
        /// Выводит информацию о всех персонах в списке в консоль.
        /// </summary>
        public static void WritePersons(
            (string listName, PersonList personList) list)
        {
            Language language = PersonBase.LanguageDetect(list.listName);

            if (list.personList.Count == 0)
            {

                var msg = string.Format(
                    Locale.FieldLocale[language]["ListEmpty"], list.listName);
                Console.WriteLine(msg);
                return;
            }
            else
            {
                language = PersonBase.LanguageDetect(list.personList[0].Name);
                var header = string.Format(
                    Locale.FieldLocale[language]["ListHeader"], list.listName);
                Console.WriteLine(header);
                foreach (PersonBase person in list.personList)
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
            while (personList.Count < count)
            {
                Random random = new Random();
                bool isAdult = random.Next(2) == 0;
                if (isAdult)
                {
                    personList.AddPerson(Adult.GetRandomAdult(language));
                }
                else
                {
                    personList.AddPerson(Child.GetRandomChild(language));
                }
            }
            return (listName, personList);
        }

        /// <summary>
        /// Вывести цветной текст в консоль.
        /// </summary>
        /// <param name="text">Текст вывода.</param>
        /// <param name="color">Цвет текста.</param>
        public static void WriteTextColorful(string text, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(text);
            Console.ResetColor();
        }

        /// <summary>
        /// Читает информацию о персоне с консоли и заполняет поля.
        /// </summary>
        /// <param name="personReader">Персона для заполнения информации.</param>
        private static void ReadBaseProperties(ModelPerson.PersonBase personReader)
        {
            var actionList = new List<PropertyHandlerDTO>
            {
                new PropertyHandlerDTO(
                    "имя",
                    new List<Type>
                        {
                           typeof(ArgumentNullException),
                           typeof(FormatException),
                        },
                    () => { personReader.Name = Console.ReadLine(); }),
                new PropertyHandlerDTO(
                    "фамилию",
                    new List<Type>
                        {
                           typeof(ArgumentNullException),
                           typeof(FormatException),
                        },
                    () => { personReader.Surname = Console.ReadLine(); }),
                new PropertyHandlerDTO(
                    "возраст",
                    new List<Type>
                        {
                           typeof(ArgumentException),
                           typeof(FormatException),
                        },
                    () => { personReader.Age = IntParse("Возраст"); }),
                new PropertyHandlerDTO(
                    "пол",
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
                            }),

            };

            for (int i = 0; i < actionList.Count; i++)
            {
                PersonPropertiesHandler(actionList[i]);
            }
        }

        /// <summary>
        /// Метод чтения числа с консоли.
        /// </summary>
        private static int IntParse(string propertyName)
        {
            string input = Console.ReadLine();
            bool success = int.TryParse(input, out int number);
            if (success)
            {
                return Convert.ToInt32(number);
            }
            else
            {
                throw new FormatException($"{propertyName} задается " +
                    "в формате целого числа");
            }
        }

        /// <summary>
        /// Читает информацию о взрослом.
        /// </summary>
        /// <param name="adult">Взрослый для заполнения информации.</param>
        private static void ReadAdultProperties(Adult adult)
        {
            adult.Passport = new Passport();
            var actionList = new List<PropertyHandlerDTO>
            {
                new PropertyHandlerDTO(
                    "работодателя",
                    new List<Type> { typeof(FormatException) },
                    () => adult.Employer = Console.ReadLine()),
                new PropertyHandlerDTO(
                    "серию паспорта",
                    new List<Type>
                            {
                               typeof(ArgumentException),
                               typeof(FormatException),
                            },
                    () => { adult.Passport.Series = IntParse("Серия паспорта"); }),
                new PropertyHandlerDTO(
                    "номер паспорта",
                    new List<Type>
                            {
                               typeof(ArgumentException),
                               typeof(FormatException),
                            },
                    () => { adult.Passport.Number = IntParse("Номер паспорта"); }),
                new PropertyHandlerDTO(
                    "данные супруга. Нажмите любую клавишу чтобы продолжить " +
                    "или enter, чтобы пропустить",
                    new List<Type> { typeof(ArgumentException) },
                    () =>
                    {
                        string input = Console.ReadLine();
                        if (!string.IsNullOrEmpty(input))
                        {
                            Adult spouse = new Adult();
                            adult.Spouse = ReadProperties(spouse);
                            spouse.Spouse = adult;
                        }
                    }),
            };

            foreach (var action in actionList)
            {
                PersonPropertiesHandler(action);
            }
        }

        /// <summary>
        /// Читает информацию о ребенке.
        /// </summary>
        /// <param name="child">Ребенок для заполнения информации.</param>
        private static void ReadChildProperties(Child child)
        {
            var actionList = new List<PropertyHandlerDTO>
            {
                new PropertyHandlerDTO(
                        "детский сад",
                        new List<Type> { typeof(ArgumentException) },
                        () => child.KinderGarten = Console.ReadLine()
                    ),
                new PropertyHandlerDTO(
                        "школу",
                        new List<Type> { typeof(ArgumentException) },
                        () => child.School = Console.ReadLine()
                    ),
                new PropertyHandlerDTO(
                        "данные отца. Нажмите enter, чтобы пропустить",
                        new List<Type> { typeof(ArgumentException) },
                        () =>
                        {
                            string input = Console.ReadLine();
                            if (!string.IsNullOrEmpty(input))
                            {
                                Adult father = new Adult();
                                child.Father = ReadProperties(father);
                                if (father.Spouse is not null)
                                {
                                    father.Spouse.Spouse = father;
                                }
                            }
                        }
                    ),
                new PropertyHandlerDTO(
                        "данные матери. Нажмите enter, чтобы пропустить",
                        new List<Type> { typeof(ArgumentException) },
                        () =>
                        {
                            string input = Console.ReadLine();
                            if (!string.IsNullOrEmpty(input))
                            {
                                Adult mother = new Adult();
                                child.Mother = ReadProperties(mother);
                                if (mother.Spouse is not null)
                                {
                                    mother.Spouse.Spouse = mother;
                                }
                            }
                        }
                    ),
            };
            if (child.Age < 6)
            {
                actionList.RemoveAt(1);
            }
            else
            {
                actionList.RemoveAt(0);
            }

            foreach (var action in actionList)
            {
                PersonPropertiesHandler(action);
            }
        }

        /// <summary>
        /// Метод распаковки actionList.
        /// </summary>
        /// <param name="propertyHandelerDto">Список действий.</param>
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
    }
}
