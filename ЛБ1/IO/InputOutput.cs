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
        /// Читает информацию о персоне с консоли и возвращает объект <see cref="ModelPerson.Person"/>.
        /// </summary>
        /// <returns>Объект <see cref="ModelPerson.Person"/> с данными, введёнными пользователем.</returns>
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
                    () => { string inputSex = Console.ReadLine();
                            Sex parsedSex = StringToSex(inputSex);
                            if (string.IsNullOrEmpty(inputSex) && parsedSex == Sex.Unknown)
                            {
                                
                                personReader.Sex = Sex.Unknown;
                            }
                            else if (parsedSex != Sex.Unknown)
                            {
                            
                                personReader.Sex = parsedSex;
                            }
                            else
                            {
                              
                                //TODO: duplication +
                                string maleValuesStr = string.Join(", ", GetMaleSexValues().Select(v => $"'{v}'"));
                                string femaleValuesStr = string.Join(", ", GetFemaleSexValues().Select(v => $"'{v}'"));

                                throw new ArgumentException(
                                    $"Для мужчин значения пола могут иметь " +
                                    $"значения {maleValuesStr}\n" +
                                    $"Для женщин значения пола могут иметь " +
                                    $"значения {femaleValuesStr}");
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
        /// Метод распаковки actionList.
        /// </summary>
        /// <param name="propertyHandlerDto">DTO для обработки свойства.</param>
        private static void PersonPropertiesHandler(
            PropertyHandlerDTO propertyHandlerDto)
        {
            var personField = propertyHandlerDto.PropertyName;
            var personTypes = propertyHandlerDto.ExceptionTypes;
            var personAction = propertyHandlerDto.PropertyHandlingAction;
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
        /// Выводит информацию о персоне в консоль в формате "Имя Фамилия, Возраст, Пол".
        /// </summary>
        /// <param name="person">Объект персоны для вывода.</param>
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
        /// <param name="list">Кортеж, содержащий имя списка и сам список персон.</param>
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
        /// <param name="strSex">Пол в формате строки.</param>
        /// <returns>Элемент перечисления <see cref="Sex"/>.</returns>
        public static Sex StringToSex(string strSex)
        {

            if (string.IsNullOrEmpty(strSex))
                return Sex.Unknown;

            string lowerStrSex = strSex.ToLower();

            //TODO: {}+
                       if (IsMaleSex(lowerStrSex))
            {
                return Sex.Male;
            }

            //TODO: {}+
                       if (IsFemaleSex(lowerStrSex))
            {
                return Sex.Female;
            }

                       return Sex.Unknown;
        }

        /// <summary>
        /// Проверяет, является ли строка обозначением мужского пола.
        /// </summary>
        /// <param name="input">Входная строка.</param>
        /// <returns>True, если строка соответствует мужскому полу.</returns>
        private static bool IsMaleSex(string input)
        {
            return GetMaleSexValues().Contains(input);
        }

        /// <summary>
        /// Проверяет, является ли строка обозначением женского пола.
        /// </summary>
        /// <param name="input">Входная строка.</param>
        /// <returns>True, если строка соответствует женскому полу.</returns>
        private static bool IsFemaleSex(string input)
        {
            return GetFemaleSexValues().Contains(input);
        }

        /// <summary>
        /// Возвращает массив допустимых строк для мужского пола.
        /// </summary>
        /// <returns>Массив строк.</returns>
        private static string[] GetMaleSexValues()
        {
            return ["мужчина", "м", "1", "man", "m"];
        }

        /// <summary>
        /// Возвращает массив допустимых строк для женского пола.
        /// </summary>
        /// <returns>Массив строк.</returns>
        private static string[] GetFemaleSexValues()
        {
            return ["женщина", "ж", "0", "woman", "w"];
        }


        /// <summary>
        /// Генерирует случайного человека с заданной локализацией.
        /// </summary>
        /// <param name="language">Код локализации ("ru" для русского, иначе для английского).</param>
        /// <returns>Созданный объект <see cref="Person"/> с случайными данными.</returns>
        /// <exception cref="ArgumentException">Выбрасывается, если данные не могут быть сгенерированы.</exception>
        /// <remarks>Использует библиотеку Bogus для генерации случайных данных</remarks>
        public static ModelPerson.Person GetRandomPerson(Language language)
        {
            ModelPerson.Person person = new ModelPerson.Person();
            //TODO: WTF? что такое faker разобраться +
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
        /// Создаёт список случайных персон.
        /// </summary>
        /// <param name="listName">Имя списка.</param>
        /// <param name="language">Локаль для генерации случайных данных.</param>
        /// <param name="count">Количество персон в списке.</param>
        /// <returns>Кортеж, содержащий имя списка и список случайных персон.</returns>
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
        /// Словарь для перевода значений перечисления <see cref="Sex"/> на разные языки.
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
        /// Выводит текст в консоль с указанным цветом.
        /// </summary>
        /// <param name="text">Текст для вывода.</param>
        /// <param name="color">Цвет текста.</param>
        public static void WriteTextColorful(string text, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(text);
            Console.ResetColor();
        }
    }

   }