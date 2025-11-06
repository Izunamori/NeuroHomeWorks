using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Digital_pass_management_system
{
    static class PrintUi
    {
        public static void PrintHeader()
        {
            Console.WriteLine("/------ Система управления цифровыми пропусками ------\\ \n");
        }

        public static byte PrintMainMenuUi()
        {
            byte switcher;

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
                    switcher = byte.Parse(Console.ReadLine());

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

            return switcher;
        }


    }
}
