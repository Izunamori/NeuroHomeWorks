using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Digital_pass_management_system
{
    static class PassManager
    {
        private static int IdCounter;
        public static int TotalPasses
        {
            get { return IdCounter; }
        }

        public static List<DigitalPass> ListOfPasses = new List<DigitalPass>();

        public static DigitalPass CreatePass(string firstName, string lastName)
        {
            int id;

            // Пропуск будет актуален в течение года после создания
            PassStatus status = PassStatus.Активный;
            DateTime expirationDate = DateTime.Now.AddYears(1);

            // Создаем пропуск
            var Pass = new DigitalPass(
                id = IdCounter,
                firstName,
                lastName,
                status,
                expirationDate
                );

            // Добавляем пропуск в список пропусков
            ListOfPasses.Add(Pass);

            IdCounter++;

            return Pass;
        }

        public static void DeactivateAllExpired()
        {
            for ( int i = 0; i < ListOfPasses.Count; i++ )
            {
                if (ListOfPasses[i].PubExpirationDate <= DateTime.Now)
                {
                    ListOfPasses[i].SetExpired();
                }
                else
                    continue;
            } 
        }
    }
}
