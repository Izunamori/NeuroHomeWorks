using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
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

            // продление пропуска на год сразу после создания
            bool status = true;
            DateTime expirationDate = DateTime.Now.AddYears(1);

            // новый пропуск
            var Pass = new DigitalPass(
                id = _IdCounter,
                firstName,
                lastName,                
                expirationDate,
                status
                );

            // добавление в список и обновление базы данных
            ListOfPasses.Add(Pass);
            DbManager.UpdateDb();

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
