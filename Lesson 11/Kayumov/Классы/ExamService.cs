using Exams.Интерфейсы;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exams.Классы
{
    public class ExamService : IExamService
    {
        public RoleTeacher _roleTeacher;
        public RoleAdmin _roleAdmin;

        public ExamService(RoleTeacher roleTeacher, RoleAdmin roleAdmin)
        {
            _roleTeacher = roleTeacher;
            _roleAdmin = roleAdmin;
        }


        public void RatingOfStudent()
        {
            Console.WriteLine($"Выберите студента, рейтинг которого вы желаете посмотреть");            
            _roleAdmin.ShowStudents();
            Console.Write("Введите его ИД: ");
                        
            if (!int.TryParse(Console.ReadLine(), out int IDStudent))
            {
                Console.WriteLine("Некорректный ввод ID студента");
                return;
            }
            bool IDStudentExist = _roleAdmin._students.Any(i => i.Id == IDStudent);

            if (IDStudentExist)
            {
                string NameAddingStudent = _roleAdmin._students.FirstOrDefault(n => n.Id == IDStudent).Name;

                var AllExamsWithStudent = _roleTeacher._examsWithStudents?.Where(a => a.StudentName == NameAddingStudent).ToList() ?? new List<EducationalEntity>();
                double CountOfAllExams = AllExamsWithStudent.Count();

                var SuccessExamsWithStudent = AllExamsWithStudent.Where(a => a.Score == 4 || a.Score == 5).ToList();
                double CountOfSuccessExams = SuccessExamsWithStudent.Count();

                Console.WriteLine($"Все найденные экзамены: (общее число {CountOfAllExams})");
                foreach (var e in AllExamsWithStudent)
                {
                    Console.WriteLine($"{e.Id}, предмет {e.Name}, {e.ExamDate}, {e.StudentID}, {e.StudentName}, {e.Attempt}, оценка {e.Score}");
                }

                
                Console.WriteLine($"Все успешные экзамены: (число {CountOfSuccessExams})");
                foreach (var e in SuccessExamsWithStudent)
                {
                    Console.WriteLine($"{e.Id}, предмет {e.Name}, {e.ExamDate}, {e.StudentID}, {e.StudentName}, {e.Attempt}, оценка {e.Score}");
                }

                double Rating = (CountOfSuccessExams / CountOfAllExams) * 100;

                Console.WriteLine($"Рейтинг студента (% успешно сданных экзаменов к их общему количеству равен): {Rating}");
            }

            else
            {
                Console.WriteLine("Студента с таким ИД не существует. При необходимости повторите ввод.");
                Console.WriteLine();
            }

           
        }

    }
}
