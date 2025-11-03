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
        Приостановлен = 0,
        Просрочен = -1
    }

    enum BanStatus
    {
        Да = 1,
        Нет = 0
    }
    class DigitalPass
    {
        private int Id;
        private string FirstName;
        private string LastName;        
        private PassStatus Status;
        private DateTime ExpirationDate;
        private BanStatus IsBanned;

        // Свойства для валидации
        public PassStatus PubStatus
        {
            get { return Status; }
        }
        public DateTime PubExpirationDate
        {
            get { return ExpirationDate; }
        }

        public DigitalPass(
            int Id,
            string FirstName,
            string LastName,
            PassStatus Status,
            DateTime ExpirationDate
        )
        {
            this.Id = Id;
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.Status = Status;
            this.ExpirationDate = ExpirationDate;
            IsBanned = BanStatus.Нет;
        }

        // Управление статусом
        public void SetActive()
        {
            Status = PassStatus.Активный;
        }

        public void SetFrozen()
        {
            Status = PassStatus.Приостановлен;
        }

        public void SetExpired()
        {
            Status = PassStatus.Просрочен;
        }
        
        // Управление блокировкой
        public void Ban()
        {
            IsBanned = BanStatus.Да;
        }

        public void Unban()
        {
            IsBanned = BanStatus.Нет;
        }

        // Вывод пропуска в консоль
        public void PrintPass()
        {
            Console.WriteLine("\t* ----------- Пропуск ----------- *\n");
            

            Console.WriteLine("\t  Id пропуска: " + Id +
                            "\n\t          Имя: " + FirstName +
                            "\n\t     Фамилиля: " + LastName +
                            "\n\t       Статус: " + Status +
                            "\n\t     Годен до: " + ExpirationDate +
                            "\n\t   Блокировка: " + IsBanned + "\n"
            );

            Console.WriteLine("\t* ------------------------------- *");
        }

        // Добавить количество дней до истечения срока годности пропуска
        public void AddDaysToExpirationDate(int Days)
        {
            ExpirationDate.AddDays( Days );
        }
    }
}
