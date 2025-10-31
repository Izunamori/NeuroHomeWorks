using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Система_учета_выполнения_ДЗ
{
    public class StudentsList
    {
        private Student[] students = new Student[10];

        public Student[] GetStudentList()
        {
            students[0] = new Student();
            students[0].FirstName = "Евгений";
            students[0].LastName = "Карасёв";

            students[1] = new Student();
            students[1].FirstName = "Данил";
            students[1].LastName = "Лучников";

            students[2] = new Student();
            students[2].FirstName = "Егор";
            students[2].LastName = "Ежов";

            students[3] = new Student();
            students[3].FirstName = "Данил";
            students[3].LastName = "Яценко";

            students[4] = new Student();
            students[4].FirstName = "Иван";
            students[4].LastName = "Гречко";

            students[5] = new Student();
            students[5].FirstName = "Влад";
            students[5].LastName = "Авдеев";

            students[6] = new Student();
            students[6].FirstName = "Артём";
            students[6].LastName = "Ярморкин";

            students[7] = new Student();
            students[7].FirstName = "Влад";
            students[7].LastName = "Орлов";

            students[8] = new Student();
            students[8].FirstName = "Никита";
            students[8].LastName = "Матвеев";

            students[9] = new Student();
            students[9].FirstName = "Максим";
            students[9].LastName = "Силин";

            return students;
        }
    }
}
