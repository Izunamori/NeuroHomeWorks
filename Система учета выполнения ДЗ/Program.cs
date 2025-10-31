namespace Система_учета_выполнения_ДЗ
{
    public class StudentGradeManager
    {
        private List<int?> _grades;

        // Счетчик невыполненных заданий

        public StudentGradeManager()
        {
            _grades = new List<int?>();
        }

        // TODO: Реализовать методы ниже

        /// <summary>
        /// Добавляет оценку за домашнее задание
        /// Если оценка null - задание не сдано
        /// </summary>
        public void AddGrade(int? grade)
        { 
            _grades.Add(grade);
        }

        /// <summary>
        /// Вычисляет среднюю оценку студента
        /// Возвращает null если нет ни одной сданной работы
        /// </summary>
        public double? GetAverageGrade()
        {
            if (this._grades is null) 
                return null;

            else
            {
                double sumOfGrades = 0;
                int skippedGrades = 0;
                
                for (int i = 0; i < _grades.Count; i++)
                {
                    // Если работа не сдана, скипаем элемент
                    if (_grades[i] == null)
                    {
                        skippedGrades++;
                        continue;
                    }
                    // Если сдана, то добавляем оценку в сумму
                    else sumOfGrades += (int)_grades[i];
                }

                // Формула вычисления среднего балла
                double averageGrade = sumOfGrades / (this._grades.Count - skippedGrades);

                return averageGrade;
            }
        }

        /// <summary>
        /// Находит наивысшую оценку студента
        /// Возвращает null если нет ни одной сданной работы
        /// </summary>
        public int? GetBestGrade()
        {
            int? bestGradeCount = 0;

            for (int i = 0; i < _grades.Count; i++)
            {
                // Скипаем элемент, если работа не сдана
                if (_grades[i] == null)
                {
                    continue;
                }

                // Если работа сдана, проверяем есть ли оценка лучше
                else
                {
                    if (_grades[i] > bestGradeCount)
                    {
                        bestGradeCount = (int)_grades[i];
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
        /// Проверяет, сдавал ли студент хоть одно задание
        /// </summary>
        public bool HasCompletedAssignments()
        {
            for (int i = 0; i < _grades.Count; i++)
            {
                // Если при переборе списка находится хоть одна сданная работа, возвращаем true
                if (_grades[i].HasValue)
                    return true;       
            }

            return false;
        }

        /// <summary>
        /// Формирует текстовый отчет об успеваемости
        /// Пример: "Средняя оценка: 4.5, Лучшая оценка: 5, Сдано работ: 3/5"
        /// Если работ нет: "Студент не сдал ни одного задания"
        /// </summary>
        public string GetGradeReport()
        {
            uint worksCount = 0;

            for (int i = 0; i < _grades.Count; i++)
            {
                if (_grades[i] == null)
                    continue;

                else
                    worksCount++;
            }

            return $"Средняя оценка: {GetAverageGrade()}, Лучшая оценка: {GetBestGrade()}, Сдано работ: {worksCount}";
        }
    }

    // Класс для тестирования
    public class Program
    {
        public static void Main()
        {
            var manager = new StudentGradeManager();

            // Тестовые данные
            manager.AddGrade(3);
            manager.AddGrade(null);  // не сдал
            manager.AddGrade(4);
            manager.AddGrade(null);  // не сдал
            manager.AddGrade(5);
            manager.AddGrade(5);

            // Тестирование методов

            Console.WriteLine("Грейд репорт: " + manager.GetGradeReport());

            Console.WriteLine();

            Console.WriteLine($"Средняя оценка: {manager.GetAverageGrade()}");
            Console.WriteLine($"Лучшая оценка: {manager.GetBestGrade()}");
            Console.WriteLine($"Есть сданные работы: {manager.HasCompletedAssignments()}");
        }
    }
}


