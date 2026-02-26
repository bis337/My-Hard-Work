using ModelPerson;
using IO;

namespace ConsoleAppLab1
{
    /// <summary>
    /// Класс реализующий выполнение программы
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Точка входа в программу
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            Adult iAmLiza = IO.InputOutput.ReadProperties(new Adult());
            InputOutput.WritePerson(iAmLiza);
            InputOutput.WritePerson(iAmLiza.Spouse);

            Child iAmAlena = IO.InputOutput.ReadProperties(new Child());
            InputOutput.WritePerson(iAmAlena);
            InputOutput.WritePerson(iAmAlena.Father);
            InputOutput.WritePerson(iAmAlena.Mother);

            InputOutput.WriteTextColorful("\na. Создайте список PersonList, " +
                "в который добавьте семь человек – разное количество взрослых " +
                "и детей в случайном порядке",
                ConsoleColor.Green);
            Language langauageList1 = Language.Ru;

            (string listName, PersonList personList) list1 =
                InputOutput.GetRandomPersonList("list1", langauageList1, 7);
            Console.ReadKey();

            InputOutput.WriteTextColorful("\nb. Выведите на экран описание всех " +
                "людей списка. Продемонстрируйте, что для различных типов людей " +
                "описания содержат разную информацию",
                ConsoleColor.Green);
            InputOutput.WritePersons(list1);
            Console.ReadKey();

            InputOutput.WriteTextColorful("\nc. Программно определите тип " +
                "четвёртого человека в вашем списке. Для демонстрации " +
                "корректности определения типа выполните какой - нибудь " +
                "из методов, присущий этому классу.",
                ConsoleColor.Green);

            //TODO: polymorphism
            //TODO: magic (to const)
            Console.WriteLine(list1.personList[3].GetType());
            Console.WriteLine(list1.personList[3].GetInfo());

            switch (list1.personList[3])
            {
                case Adult adult:
                {
                    adult.ToWhine();
                    break;
                }
                case Child child:
                {
                    child.ToEnjoy();
                    break;
                }
                default:
                    break;
            }
            Console.ReadKey();
        }
    }
}
