namespace Система_учета_выполнения_ДЗ
{
    public class Program
    {
        public static void Main()
        {
            // Создаем массив со студентами
            var students = new StudentsList();
            Student[] studentsList = students.GetStudentList();

            // Создаем объект класса, который выполняет основную функцию программы
            var manager = new StudentGradeManager();

            // Выставляем оценки студентам
            for (int i = 0; i < studentsList.Length; i++)
            {
                manager.SetGrades(studentsList[i]);
            }

            // Выводим статистику каждого студента
            for (int i = 0; i < studentsList.Length; i++)
            {
                manager.PrintStudentStats(studentsList[i]);

                Console.WriteLine("\n");
            }
        }
    }
}


