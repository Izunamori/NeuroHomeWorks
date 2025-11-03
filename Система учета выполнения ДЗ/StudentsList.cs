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
            Random rnd = new Random();

            students[0] = new Student("Евгений", "Карасёв", "ТОиРД 402", 19);
            students[1] = new Student("Данил", "Лучников", "ТОиРД 402", 19);
            students[2] = new Student("Егор", "Ежов", "ТОиРД 402", 19);
            students[3] = new Student("Данил", "Яценко", "ТОиРД 402", 19);
            students[4] = new Student("Иван", "Гречко", "ТОиРД 402", 20);
            students[5] = new Student("Влад", "Авдеев", "ТОиРД 402", 19);
            students[6] = new Student("Артём", "Ярморкин", "ТОиРД 402", 20);
            students[7] = new Student("Влад", "Орлов", "ТОиРД 402", 18);
            students[8] = new Student("Никита", "Матвеев", "ТОиРД 402", 19);
            students[9] = new Student("Максим", "Силин", "ТОиРД 402", 20);

            return students;
        }
    }
}
