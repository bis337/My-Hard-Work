namespace ModelPerson
{
    /// <summary>
    /// Класс реализующий локализацию
    /// </summary>
    public class Locale
    {
        /// <summary>
        /// Словарь для вывода информации о поле на разных языках
        /// </summary>
        public static Dictionary<Language, Dictionary<Sex, string>> SexLocale =
            new() 
            {
                { 
                    Language.Ru, 
                    new() 
                    {
                        { Sex.Female, "женщина" },
                        { Sex.Male, "мужчина" },
                        { Sex.Unknown, "нет информации о поле" }
                    }
                },
                { 
                    Language.En, 
                    new() 
                    {
                        { Sex.Female, "female" },
                        { Sex.Male, "male" },
                        { Sex.Unknown, "no information about the sex" }
                    }
                }
            };

        /// <summary>
        /// Словарь для вывода информации на разных языках
        /// </summary>
        public static Dictionary<Language, Dictionary<string, string>> FieldLocale =
            new() 
            {
                { Language.Ru, 
                    new() 
                    {
                        { "Father", "Отец" },
                        { "Mother", "Мать" },
                        { "NoParent", "родитель неизвестен" },
                        { "Studying", "Учится в" },
                        { "School", "Школа" },
                        { "GoesInKD", "Ходит в детский сад" },
                        { "NotGoesInKD", "Не ходит в детский сад" },
                        { "KinderGarten", "Детский сад" },
                        { "NotStudying", "Не учится" },
                        { "MarriedTo", "Женат/замужем за" },
                        { "NotMarried", "Не женат / не замужем" },
                        { "Employer", "Работает в" },
                        { "Unemployed", "Безработный" },
                        { "Passport", "Паспорт" },
                        { "Age", "Возраст" },
                        { "Sex", "Пол" },
                        { "PersonType", "Тип персоны" },
                        { "Adult", "Взрослый" },
                        { "Child", "Ребенок" },
                        { "ListEmpty", "Список {0} пуст." },
                        { "ListHeader", "Список {0}:" }
                    }
                },
                { Language.En, 
                    new() 
                    {
                        { "Father", "Father" },
                        { "Mother", "Mother" },
                        { "NoParent", "no parent" },
                        { "Studying", "Studying at" },
                        { "School", "School" },
                        { "GoesInKD", "Goes in kindergarten" },
                        { "NotGoesInKD", "Does not go to kindergarten" },
                        { "KinderGarten", "KinderGarten" },
                        { "NotStudying", "Not studying" },
                        { "MarriedTo", "Married to" },
                        { "NotMarried", "Not married" },
                        { "Employer", "Current job" },
                        { "Unemployed", "Unemployed" },
                        { "Passport", "Passport number" },
                        { "Age", "Age" },
                        { "Sex", "Sex" },
                        { "PersonType", "Person type" },
                        { "Adult", "Adult" },
                        { "Child", "Child" },
                        { "ListEmpty", "List {0} is empty." },
                        { "ListHeader", "List {0}:" }
                    }
                }
            };
    }
}
