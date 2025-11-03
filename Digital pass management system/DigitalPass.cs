using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Digital_pass_management_system
{
    enum PassStatus
    {
        Активный = 1,
        Просрочен = 0,
    }

    enum BanStatus
    {
        Да = 1,
        Нет = 0
    }
    class DigitalPass
    {
        private static int _BannedCounter;

        private int _Id;
        private string _FirstName;
        private string _LastName;        
        private PassStatus _Status;
        private DateTime _ExpirationDate;
        private BanStatus _IsBanned;

        // Свойства для валидации
        public static int BannedCounter
        {
            get { return _BannedCounter; }
        }
        public BanStatus BannedStatus
        {
            get { return _IsBanned; }
        }
        public PassStatus Status
        {
            get { return _Status; }
        }
        public DateTime ExpirationDate
        {
            get { return _ExpirationDate; }
        }

        public DigitalPass(
            int Id,
            string FirstName,
            string LastName,
            PassStatus Status,
            DateTime ExpirationDate
        )
        {
            this._Id = Id;
            this._FirstName = FirstName;
            this._LastName = LastName;
            this._Status = Status;
            this._ExpirationDate = ExpirationDate;
            _IsBanned = BanStatus.Нет;
        }

        // Управление статусом годности
        public void SetActive()
        {
            _Status = PassStatus.Активный;
        }

        public void SetExpired()
        {
            _Status = PassStatus.Просрочен;
        }
        
        // Управление блокировкой
        public void Ban()
        {
            _IsBanned = BanStatus.Да;
            _BannedCounter++;
        }

        public void Unban()
        {
            _IsBanned = BanStatus.Нет;
            _BannedCounter--;
        }

        // Вывод пропуска в консоль
        public void PrintPass()
        {
            Console.WriteLine("\t* ----------- Пропуск ----------- *\n");
            
            Console.WriteLine("\t  Id пропуска: " + _Id +
                            "\n\t          Имя: " + _FirstName +
                            "\n\t     Фамилиля: " + _LastName +
                            "\n\t       Статус: " + _Status +
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
