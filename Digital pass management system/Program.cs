namespace Digital_pass_management_system
{
    internal class Program
    {
        static byte? switcher;

        static void PrintHeader()
        {
            Console.WriteLine("/------ Система управления цифровыми пропусками ------\\ \n");
        }
        static void PrintMainMenuUi()
        {
            while (true)
            {
                PrintHeader();

                Console.WriteLine("1. Создать пропуск\n" +
                                  "2. Продлить пропуск\n" +
                                  "3. Изменить статус\n" +
                                  "4. Статистика\n" +
                                  "5. Поиск пропуска\n" +
                                  "6. Выход\n");

                try
                {
                    Console.Write("-> ");
                    switcher = Byte.Parse(Console.ReadLine());

                    if (switcher == 1
                        | switcher == 2
                        | switcher == 3
                        | switcher == 4
                        | switcher == 5
                        | switcher == 6)
                        break;
                }
                catch (FormatException)
                {
                    Console.Clear();

                    PrintHeader();

                    Console.WriteLine("Ошибка, для выбора пункта вводите целые числа от 1 до 6.\n\n" +
                                      "Для продолжения нажмите Enter");
                    Console.ReadLine();
                    
                    Console.Clear();
                }
            }
            Console.Clear();
        }
        static void Main(string[] args)
        {
            while (true)
            {
                PrintMainMenuUi();

                switch (switcher)
                {
                    case 1:
                    {
                        string firstName = "";
                        string lastName = "";                        

                        while (firstName == "")
                        {
                            PrintHeader();

                            Console.Write("Введите имя нового пользователя: ");

                            firstName = Console.ReadLine();

                            Console.Clear();
                        }

                        Console.Clear();

                        while (lastName == "")
                        {
                            PrintHeader();
                            Console.Write("Введите фамилию нового пользователя: ");

                            lastName = Console.ReadLine();

                            Console.Clear();
                        }

                        Console.Clear();

                        PassManager.CreatePass(firstName, lastName);

                        PrintHeader();

                        Console.WriteLine("\n\t\tСоздан новый пропуск.\n");

                        PassManager.ListOfPasses[PassManager.ListOfPasses.Count - 1].PrintPass();

                        Console.Write("\n\nНажмите Enter для возврата в главное меню...");
                        Console.ReadLine();

                        Console.Clear();

                        break;
                    }

                    case 2:
                    {
                        int id = -1;
                        int days = 0;
                        
                        PrintHeader();
                        
                        try
                        {
                            Console.Write("Введите Id пропуска, который хотите продлить: ");
                            id = int.Parse(Console.ReadLine());

                            Console.Clear();

                            PrintHeader();

                            Console.Write("Введите кол-во дней, на которое хотите продлить: ");
                            days = int.Parse(Console.ReadLine());

                            Console.Clear();
                        }
                        catch (FormatException)
                        {
                            Console.Clear();

                            Console.WriteLine("Некорректный ввод, введите целое число.\n\n" +
                                                "Для продолжения нажмите Enter");
                            Console.ReadLine();

                            Console.Clear();
                        }

                        try
                        {
                            PassManager.ListOfPasses[id].AddDaysToExpirationDate(days);
                        }
                        catch (ArgumentOutOfRangeException)
                        {
                            Console.Clear();

                            PrintHeader();

                            Console.WriteLine("Ошибка, такого пропуска не существует.\n");

                            Console.WriteLine("Нажмите Enter для продолжения...");

                            Console.ReadLine();

                            Console.Clear();
                        }

                        break;
                    }

                    case 3:

                        break;

                    case 4:

                        break;

                    case 5:

                        break;

                    case 6:

                        break;
                }
            }
        }
    }
}
