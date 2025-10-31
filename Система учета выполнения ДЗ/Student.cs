using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Система_учета_выполнения_ДЗ
{
    public class Student
    {
        public string FirstName;
        public string LastName;
        public int age;

        public void PrintStudent()
        {
            Console.WriteLine(FirstName);
            Console.WriteLine(LastName);
            Console.WriteLine(age);
        }
    }
}
