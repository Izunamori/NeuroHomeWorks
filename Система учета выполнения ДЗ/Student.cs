using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Система_учета_выполнения_ДЗ
{
    public class Student
    {
        public Student
            (            
            string FirstName = "Не указано",
            string LastName = "Не указано",
            string Group = "Не указано",
            uint Age = 0            
            )
        {
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.Group = Group;
            this.Age = Age;
        }
                
        public string FirstName;
        public string LastName;
        public string Group;
        public uint Age;

        public List<int?> grades = new List<int?>();
    }
}
