using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Digital_pass_management_system
{
    static class DbManager
    {
        static JsonSerializerOptions Options = new JsonSerializerOptions { WriteIndented = true };

        public static void GetDb()
        {
            PassManager.ListOfPasses = JsonSerializer.Deserialize<List<DigitalPass>>(File.ReadAllText("passes.json"));
        }

        public static void UpdateDb()
        {
            string jsonString = JsonSerializer.Serialize(PassManager.ListOfPasses, Options) + Environment.NewLine;

            File.WriteAllText("passes.json", jsonString);
        }        
    }
}
