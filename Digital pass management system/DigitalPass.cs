using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Digital_pass_management_system
{    
    class DigitalPass
    {
        private static int _BannedCounter;
        public static int BannedCounter
        {
            get { return _BannedCounter; }
        }


        public int Id { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public bool ActiveStatus { get; private set; }
        public bool IsBanned { get; private set; }
        public DateTime ExpirationDate { get; private set; }


        // конструктор для создания пропуска
        public DigitalPass(
            int id,
            string firstName,
            string lastName,
            DateTime expirationDate
        )
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            IsBanned = false;
            ActiveStatus = true;
            ExpirationDate = expirationDate;
            
        }

        // управление статусом годности
        public void SetActive() => ActiveStatus = true;
        public void SetExpired() => ActiveStatus = false;


        // управление блокировкой
        public void Ban()
        {
            IsBanned = true;
            _BannedCounter++;
        }
        public void Unban()
        {
            IsBanned = false;
            _BannedCounter--;
        }


        /// <summary>
        /// вывод пропуска в консоль
        /// </summary>
        public void PrintPass()
        {
            Console.WriteLine("\t* ----------- Пропуск ----------- *\n");
            
            Console.WriteLine("\t  id пропуска: " + Id +
                            "\n\t          Имя: " + FirstName +
                            "\n\t     Фамилиля: " + LastName +
                            "\n\t      Активен: " + ActiveStatus +
                            "\n\t     Годен до: " + ExpirationDate +
                            "\n\t   Блокировка: " + IsBanned + "\n"
            );

            Console.WriteLine("\t* ------------------------------- *");
        }


        /// <summary>
        /// добавляет дни к сроку действия пропуска
        /// </summary>
        /// <param name="Days"></param>
        public void AddDaysToExpirationDate(int Days)
        {
            ExpirationDate.AddDays( Days );
        }
    }
}
