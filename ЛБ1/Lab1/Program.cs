using ModelPerson;
using IO;

namespace ConsoleAppLab1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            InputOutput.ReadPerson();
            InputOutput.WriteTextColorful("\na. Создайте программно два списка " +
                "персон, в каждом из которых будет по три человека",
                ConsoleColor.Green);
            Console.WriteLine("Нажмите любую клавишу, " +
                "для получения результата\n");
            Console.ReadKey();
            Language langauageList1 = Language.Ru;

            (string listName, PersonList personList) list1 = 
                InputOutput.GetRandomPersonList("list1", langauageList1, 3);
            (string listName, PersonList personList) list2 = 
                InputOutput.GetRandomPersonList("list2", Language.En, 3);

            InputOutput.WriteTextColorful("\nb. Выведите содержимое каждого" +
                " списка на экран с соответствующими подписями списков.", 
                ConsoleColor.Green);
            Console.WriteLine("Нажмите любую клавишу, " +
                "для получения результата\n");
            Console.ReadKey();
            InputOutput.WritePersons(list1);
            InputOutput.WritePersons(list2);

            InputOutput.WriteTextColorful("\nc. Добавьте нового человека " +
                "в первый список.",
                ConsoleColor.Green);
            Console.WriteLine("Нажмите любую клавишу, " +
                "для получения результата\n");
            Console.ReadKey();
            list1.personList.AddPerson(InputOutput.GetRandomPerson(langauageList1));
            InputOutput.WritePersons(list1);

            InputOutput.WriteTextColorful("\nd. Скопируйте второго человека из " +
                "первого списка в конец второго списка. Покажите, " +
                "что один и тот же человек находится в обоих списках.",
                ConsoleColor.Green);
            Console.WriteLine("Нажмите любую клавишу, " +
                "для получения результата\n");
            Console.ReadKey();
            list2.personList.AddPerson(list1.personList.GetPersonAt(1));
            InputOutput.WritePersons(list1);
            InputOutput.WritePersons(list2);

            InputOutput.WriteTextColorful("\ne. Удалите второго человека из " +
                "первого списка. Покажите, что удаление человека из " +
                "первого списка не привело к уничтожению этого же " +
                "человека во втором списке.",
                ConsoleColor.Green);
            Console.WriteLine("Нажмите любую клавишу, " +
                "для получения результата\n");
            Console.ReadKey();
            list1.personList.RemovePersonAt(1);
            InputOutput.WritePersons(list1);
            InputOutput.WritePersons(list2);

            InputOutput.WriteTextColorful("\nf. Очистите второй список. " +
                "Каждый новый шаг должен выполняться " +
                "по нажатию любой клавиши клавиатуры.",
                ConsoleColor.Green);
            Console.WriteLine("Нажмите любую клавишу, " +
                "для получения результата\n");
            Console.ReadKey();
            list2.personList.ClearList();
            InputOutput.WritePersons(list2);
        }
    }
}
