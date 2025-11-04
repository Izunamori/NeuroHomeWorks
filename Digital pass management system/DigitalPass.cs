using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Digital_pass_management_system
{    
    class DigitalPass
    {
        private static int _BannedCounter;

        private int _Id;
        private string _FirstName;
        private string _LastName;        
        private bool _ActiveStatus;
        private bool _IsBanned;
        private DateTime _ExpirationDate;        
                
        public static int BannedCounter
        {
            get { return _BannedCounter; }
        }

        // Свойства для сохранения в Json
        public int Id
        {
            get { return _Id; }
            set { _Id = value; }
        }
        public string FirstName
        {
            get { return _FirstName; }
            set { _FirstName = value; }
        }
        public string LastName
        {
            get { return _LastName; }
            set { _LastName = value; }
        }
        public bool BannedStatus
        {
            get { return _IsBanned; }
            set { _IsBanned = value; }
        }
        public bool ActiveStatus
        {
            get { return _ActiveStatus; }
            set { _ActiveStatus = value; }
        }
        public DateTime ExpirationDate
        {
            get { return _ExpirationDate; }
            set { _ExpirationDate = value; }
        }

        public DigitalPass(
            int Id,
            string FirstName,
            string LastName,            
            DateTime ExpirationDate,
            bool Status = true
        )
        {
            _Id = Id;
            _FirstName = FirstName;
            _LastName = LastName;
            _ActiveStatus = Status;
            _ExpirationDate = ExpirationDate;
            _IsBanned = false;
        }

        // Управление статусом годности
        public void SetActive()
        {
            _ActiveStatus = true;
        }

        public void SetExpired()
        {
            _ActiveStatus = false;
        }
        
        // Управление блокировкой
        public void Ban()
        {
            _IsBanned = true;
            _BannedCounter++;
        }

        public void Unban()
        {
            _IsBanned = false;
            _BannedCounter--;
        }

        // Вывод пропуска в консоль
        public void PrintPass()
        {
            Console.WriteLine("\t* ----------- Пропуск ----------- *\n");
            
            Console.WriteLine("\t  Id пропуска: " + _Id +
                            "\n\t          Имя: " + _FirstName +
                            "\n\t     Фамилиля: " + _LastName +
                            "\n\t       Статус: " + _ActiveStatus +
                            "\n\t     Годен до: " + _ExpirationDate +
                            "\n\t   Блокировка: " + _IsBanned + "\n"
            );

            Console.WriteLine("\t* ------------------------------- *");
        }

        // Добавить количество дней до истечения срока годности пропуска
        public void AddDaysToExpirationDate(int Days)
        {
            _ExpirationDate.AddDays( Days );
        }
    }
}
