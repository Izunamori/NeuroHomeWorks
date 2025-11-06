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
        public static int TotalPasses { get; private set; }
        public static List<DigitalPass> ListOfPasses { get; private set; }

        static PassManager() { ListOfPasses = new List<DigitalPass>(); }

        public static void CreatePass(string firstName, string lastName)
        {
            var Pass = new DigitalPass(firstName, lastName);

            ListOfPasses.Add(Pass);

            TotalPasses++;
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
