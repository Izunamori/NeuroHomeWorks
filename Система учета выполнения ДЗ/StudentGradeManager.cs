using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Система_учета_выполнения_ДЗ
{
    public class StudentGradeManager
    {
        /// <summary>
        /// Выставляет оценки студенту
        /// </summary>
        /// <param name="student"></param>
        public void SetGrades(Student student)
        {
            var rnd = new Random();

            for (int i = 0; i < 10; i++)
            {
                int check = rnd.Next(1, 6);

                // С шансом 1/5 студент не сдает работу, с этим же шансом получает 2
                switch (check)
                {
                    case 1:
                        student.grades.Add(rnd.Next(3, 6));
                        break;
                    case 2:
                        student.grades.Add(rnd.Next(3, 6));
                        break;
                    case 3:
                        student.grades.Add(rnd.Next(3, 6));
                        break;
                    case 4:
                        student.grades.Add(rnd.Next(2, 6));
                        break;
                    case 5:
                        student.grades.Add(null);
                        break;
                }
            }
        }

        /// <summary>
        /// Выводит в консоль статистику студента
        /// Если работ нет: "Студент не сдал ни одного задания"
        /// </summary>
        public void PrintStudentStats(Student student)
        {
            Console.WriteLine("*--- Статистика студента ---*\n");
            Console.WriteLine("Имя: " + student.FirstName);
            Console.WriteLine("Фамилия: " + student.LastName);
            Console.Write("Оценки: ");
            for (int i = 0; i < student.grades.Count; i++)
            {
                if (student.grades[i].HasValue)
                    Console.Write(student.grades[i] + " ");
                else
                    Console.Write("н" + " ");
            }

            Console.WriteLine("\n");

            Console.WriteLine($"Средняя оценка: {GetAverageGrade(student.grades)}\n" +
                              $"Лучшая оценка: {GetBestGrade(student.grades)}\n" +
                              $"Сдано работ: {GetWorksCount(student.grades)}");

            Console.WriteLine("\n*---------------------------*");
        }

        /// <summary>
        /// Вычисляет среднюю оценку студента
        /// Возвращает null если нет ни одной сданной работы
        /// </summary>
        public double? GetAverageGrade(List<int?> grades)
        {
            if (grades is null)
                return null;

            else
            {
                double sumOfGrades = 0;
                int skippedGrades = 0;

                for (int i = 0; i < grades.Count; i++)
                {
                    // Если работа не сдана, скипаем элемент
                    if (grades[i] == null)
                    {
                        skippedGrades++;
                        continue;
                    }
                    // Если сдана, то добавляем оценку в сумму
                    else sumOfGrades += (int)grades[i];
                }

                // Формула вычисления среднего балла
                double averageGrade = sumOfGrades / (grades.Count - skippedGrades);

                return averageGrade;
            }
        }

        /// <summary>
        /// Находит наивысшую оценку студента
        /// Возвращает null если нет ни одной сданной работы
        /// </summary>
        public int? GetBestGrade(List<int?> grades)
        {
            int? bestGradeCount = 0;

            for (int i = 0; i < grades.Count; i++)
            {
                // Скипаем элемент, если работа не сдана
                if (grades[i] == null)
                {
                    continue;
                }

                // Если работа сдана, проверяем есть ли оценка лучше
                else
                {
                    if (grades[i] > bestGradeCount)
                    {
                        bestGradeCount = (int)grades[i];
                    }
                    else
                        continue;
                }
            }

            // Если ни одна работа не сдана, присваиваем переменной null 
            if (bestGradeCount is 0)
                bestGradeCount = null;

            return bestGradeCount;
        }

        /// <summary>
        /// Возвращает кол-во работ, сданных студентом
        /// </summary>
        /// <param name="grades"></param>
        /// <returns></returns>
        public uint GetWorksCount(List<int?> grades)
        {
            uint worksCount = 0;

            for (int i = 0; i < grades.Count; i++)
            {
                if (grades[i] == null)
                    continue;

                else
                    worksCount++;
            }

            return worksCount;
        }
    }
}
