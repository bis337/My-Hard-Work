using ModelPerson;

namespace Locale
{
    public class Locale
    {
        public static Dictionary<Language, Dictionary<Sex, string>> _sexLocale =
            new() {
            { Language.Ru, new() {
                { Sex.Female, "женщина" },
                { Sex.Male, "мужчина" },
                { Sex.Unknown, "нет информации о поле" }
            }},
            { Language.En, new() {
                { Sex.Female, "female" },
                { Sex.Male, "male" },
                { Sex.Unknown, "no information about the sex" }
            }}
            };

        public static Dictionary<Language, Dictionary<string, string>> _fieldLocale =
            new() {
            { Language.Ru, new() {
                { "Father", "Отец" },
                { "Mother", "Мать" },
                { "NoParent", "родитель неизвестен" },
                { "Studying", "Учится в" },
                { "NotStudying", "Не учится" },
                { "MarriedTo", "Женат/замужем за" },
                { "NotMarried", "Не женат / не замужем" },
                { "Employer", "Работает в" },
                { "Unemployed", "Безработный" },
                { "Passport", "Паспорт" },
            }},
            { Language.En, new() {
                { "Father", "Father" },
                { "Mother", "Mother" },
                { "NoParent", "no parent" },
                { "Studying", "Studying at" },
                { "NotStudying", "Not studying" },
                { "MarriedTo", "Married to" },
                { "NotMarried", "Not married" },
                { "Employer", "Current job" },
                { "Unemployed", "Unemployed" },
                { "Passport", "Passport number" },
            }}
            };
    }
}
