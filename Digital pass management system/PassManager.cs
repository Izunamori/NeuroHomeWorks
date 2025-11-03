using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Digital_pass_management_system
{
    static class PassManager
    {        
        private static int _IdCounter;
        public static int TotalPasses
        {
            get { return _IdCounter; }
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
                id = _IdCounter,
                firstName,
                lastName,
                status,
                expirationDate
                );

            // Добавляем пропуск в список пропусков
            ListOfPasses.Add(Pass);

            _IdCounter++;

            return Pass;
        }

        public static void DeactivateAllExpired()
        {
            for ( int i = 0; i < ListOfPasses.Count; i++ )
            {
                if (ListOfPasses[i].ExpirationDate <= DateTime.Now)
                {
                    ListOfPasses[i].SetExpired();
                }
                else
                    continue;
            } 
        }
    }
}
