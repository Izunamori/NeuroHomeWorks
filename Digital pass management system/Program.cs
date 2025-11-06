using System.Text.Json;

namespace Digital_pass_management_system
{
    internal class Program
    {
        static byte? Switcher;

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
                                  "3. Заблокировать\\Разблокировать\n" +
                                  "4. Статистика\n" +
                                  "5. Поиск пропуска\n" +
                                  "6. Выход\n");

                try
                {
                    Console.Write("-> ");
                    Switcher = byte.Parse(Console.ReadLine());

                    if (Switcher == 1
                        | Switcher == 2
                        | Switcher == 3
                        | Switcher == 4
                        | Switcher == 5
                        | Switcher == 6)
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

                switch (Switcher)
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

                            while (lastName == "")
                            {
                                PrintHeader();
                                Console.Write("Введите фамилию нового пользователя: ");

                                lastName = Console.ReadLine();

                                Console.Clear();
                            }

                            PassManager.CreatePass(firstName, lastName);

                            PrintHeader();

                            Console.WriteLine("\n\t\tСоздан новый пропуск.\n");

                            PassManager.ListOfPasses[PassManager.ListOfPasses.Count - 1].PrintPass();

                            Console.Write("\n\nНажмите Enter для возврата в главное меню...\n\n");

                            Console.ReadLine();
                            Console.Clear();                            
                        }
                        break;

                    case 2:
                        {
                            int id = -1;
                            int days = 0;

                            PrintHeader();

                            try
                            {
                                Console.Write("Введите Id пропуска: ");
                                id = int.Parse(Console.ReadLine());

                                if (PassManager.ListOfPasses[id].IsBanned is true)
                                {
                                    Console.Clear();

                                    PrintHeader();

                                    Console.WriteLine("Пропуск заблокирован.\n\n" +
                                                      "Нажмите Enter для продолжения...");

                                    Console.ReadLine();
                                    Console.Clear();

                                    break;
                                }

                                Console.Clear();

                                PrintHeader();

                                Console.Write("Введите кол-во дней, на которое хотите продлить: ");
                                days = int.Parse(Console.ReadLine());

                                Console.Clear();
                            }
                            catch (FormatException)
                            {
                                Console.Clear();

                                PrintHeader();

                                Console.WriteLine("Некорректный ввод, введите целое число.\n\n" +
                                                "Для продолжения нажмите Enter");

                                Console.ReadLine();
                                Console.Clear();

                                break;
                            }
                            catch (ArgumentOutOfRangeException)
                            {
                                Console.Clear();

                                PrintHeader();

                                Console.WriteLine("Ошибка, такого пропуска не существует.\n");

                                Console.WriteLine("Нажмите Enter для продолжения...");

                                Console.ReadLine();
                                Console.Clear();

                                break;
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

                                break;
                            }                            
                        }
                        break;

                    case 3:
                        {
                            int id = -1;
                            int switcherInCase3 = 0;

                            PrintHeader();

                            try
                            {
                                Console.Write("Введите Id пропуска: ");
                                id = int.Parse(Console.ReadLine());

                                Console.Clear();
                            }
                            catch (FormatException)
                            {
                                Console.Clear();

                                PrintHeader();

                                Console.WriteLine("Некорректный ввод, введите целое число.\n\n" +
                                                    "Для продолжения нажмите Enter");

                                Console.ReadLine();
                                Console.Clear();

                                break;
                            }                            

                            try
                            {
                                PrintHeader();

                                PassManager.ListOfPasses[id].PrintPass();

                                Console.WriteLine();
                            }
                            catch (ArgumentOutOfRangeException)
                            {
                                Console.WriteLine("Ошибка, такого пропуска не существует.\n");

                                Console.WriteLine("Нажмите Enter для продолжения...");

                                Console.ReadLine();
                                Console.Clear();

                                break;
                            }

                            try
                            {
                                Console.Write("1. Заблокировать\n" +
                                              "2. Разблокировать\n\n" +
                                              "-> ");
                                switcherInCase3 = int.Parse(Console.ReadLine());

                                Console.Clear();
                            }
                            catch (FormatException)
                            {
                                Console.Clear();

                                PrintHeader();

                                Console.WriteLine("Некорректный ввод, введите целое число.\n\n" +
                                                  "Для продолжения нажмите Enter\n\n");
                                Console.ReadLine();

                                Console.Clear();

                                break;
                            }

                            switch (switcherInCase3)
                            {
                                case 1:
                                    {
                                        PassManager.ListOfPasses[id].Ban();
                                        break;
                                    }

                                case 2:
                                    {
                                        PassManager.ListOfPasses[id].Unban();
                                        break;
                                    }
                            }

                            PrintHeader();

                            Console.WriteLine("Статус успешно изменён.\n\n" +
                                              "Нажмите Enter для продолжения...");

                            Console.ReadLine();
                            Console.Clear();                                                       
                        }
                        break;

                    case 4:
                        {
                            Console.Clear();

                            PrintHeader();

                            Console.WriteLine("Статистика:\n");

                            Console.WriteLine($"Всего пропусков: {PassManager.ListOfPasses.Count}" +
                                $"\nВсего пропусков заблокировано: {DigitalPass.BannedCounter}\n");

                            Console.WriteLine("Нажмите Enter, чтобы вернуться...");

                            Console.ReadLine();
                            Console.Clear();
                        }
                        break;

                    case 5:
                        {
                            int id = -1;

                            try
                            {
                                PrintHeader();

                                Console.Write("Введите Id пропуска: ");
                                id = int.Parse(Console.ReadLine());

                                Console.Clear();
                            }
                            catch (FormatException)
                            {
                                Console.Clear();

                                PrintHeader();

                                Console.WriteLine("Некорректный ввод, введите целое число.\n\n" +
                                                    "Для продолжения нажмите Enter");

                                Console.ReadLine();
                                Console.Clear();

                                break;
                            }
                            
                            try
                            {
                                for (int i = 0; i < PassManager.ListOfPasses.Count; i++)
                                {
                                    if (i == id)
                                    {
                                        Console.Clear();

                                        PrintHeader();

                                        Console.WriteLine("Найден пропуск:\n");

                                        PassManager.ListOfPasses[i].PrintPass();

                                        Console.WriteLine("\nНажмите Enter, чтобы вернуться...");

                                        Console.ReadLine();
                                        Console.Clear();
                                    }
                                }
                            }
                            catch (ArgumentOutOfRangeException)
                            {
                                Console.WriteLine("Ошибка, такого пропуска не существует.\n");

                                Console.WriteLine("Нажмите Enter для продолжения...");

                                Console.ReadLine();
                                Console.Clear();

                                break;
                            }
                        }
                        break;

                    case 6:
                        return;
                }
            }
        }
    }
}
