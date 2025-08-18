using Exams.Интерфейсы;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exams.Классы
{
    public class RoleStudent : IUserRole
    {
        public RoleAdmin _roleAdmin;
        public RoleTeacher _roleTeacher;
        public ExamService _examService;
        public RoleStudent(RoleAdmin roleAdmin, ExamService examService, RoleTeacher roleTeacher)
        {
            _roleAdmin = roleAdmin;
            _examService = examService;
            _roleTeacher = roleTeacher;
        }
        public bool isStudentMayEnter { get; set; }
        public PersonStudent EnteredStudent;
        int EnteredStudentID = 0;
        public List<EducationalEntity> MyExams;
        public List<EducationalEntity> MyExamsWithScore;
        public void EnterToSystem()
        {
            Console.WriteLine("Введити ваш ID: ");

            if (!int.TryParse(Console.ReadLine(), out EnteredStudentID))
            {
                Console.WriteLine("Некорректный ввод ID. Повторите ввод.");
                return;
            }         
            EnteredStudent = _roleAdmin._students.FirstOrDefault(t => t.Id == EnteredStudentID);
            isStudentMayEnter = EnteredStudent != null;
            MyExams = _roleTeacher._examsWithStudents.Where(me => me.StudentID == EnteredStudent.Id).ToList();
            MyExamsWithScore = MyExams.Where(me => me.Score == 2 || me.Score == 3 || me.Score == 4 || me.Score == 5).ToList();
        }

        public void ActionToSystem()
        {
            Console.WriteLine($"Добро пожаловать, {EnteredStudent.Name}");

            string StudentChoice = "0";

            while (StudentChoice != "5")
            {
                Console.WriteLine("Выберите действие (и нажмите соответствующий номер):\n" +
                            "1. Посмотреть список всех назначенных мне экзаменов\n" +
                            "2. Посмотреть оценки по сданным экзаменам\n" +
                            "3. Посмотреть свой рейтинг (% экзаменов, сданных на 4 или 5, относительно их общего количества)\n" +
                            "4. Посмотреть средний бал по сданным экзаменам\n" +
                            "5. Выйти в основное меню");

                StudentChoice = Console.ReadLine();

                switch (StudentChoice)
                {
                    case "1":
                        {
                            ShowMyExams();
                            break;
                        }
                    case "2":
                        {
                            ShowMyScors();
                            break;
                        }
                    case "3":
                        {
                            ShowMyRating();
                            break;
                        }
                    case "4":
                        {
                            ShowMyAverageScore();
                            break;
                        }
                    case "5":
                        {
                            
                            break;
                        }                    
                    default:
                        {
                            Console.WriteLine("Введено неверное значение");
                            break;
                        }

                }

            }
        }

        public void ShowMyExams()
        {
            if(MyExams.Count > 0)
            {
                foreach (var me in MyExams)
                {
                    Console.WriteLine($"Экзамен по {me.Name}, назначен на {me.ExamDate}, будет сдаваться в {me.Attempt} раз");
                }
            }
            else
            {
                Console.WriteLine("Ваc пока не добавили ни в один экзамен.");
            }
            Console.ReadKey();
            Console.Clear();
        }

        public void ShowMyScors()
        {
            if(MyExamsWithScore.Count > 0)
            {
                foreach (var mews in MyExamsWithScore)
                {
                    Console.WriteLine($"Экзамен по {mews.Name}, пройденный {mews.ExamDate}, сдан на оценку: {mews.Score}");
                }
            }
            else
            {
                Console.WriteLine("Вам пока не поставили ни одной оценки за экзамен.");
            }
            Console.ReadKey();
            Console.Clear();
        }

        public void ShowMyRating()
        {           
            var SuccessExamsWithStudent = MyExamsWithScore.Where(a => a.Score == 4 || a.Score == 5).ToList();

            double CountOfAllExams = MyExamsWithScore.Count();
            double CountOfSuccessExams = SuccessExamsWithStudent.Count();

            if (MyExamsWithScore.Count() > 0)
            {
                double Rating = (CountOfSuccessExams / CountOfAllExams) * 100;
                Console.WriteLine($"Рейтинг (% экзаменов сданных на 4 и 5, к их общему количеству) равен: {Rating}");
            }
            else
            {
                Console.WriteLine("Вам пока не поставили ни одной оценки за экзамен.");
            }
            Console.ReadKey();
            Console.Clear();
        }

        public void ShowMyAverageScore()
        {
            double SumOfScors = 0;
            int CountOfScors = 0;

            foreach (var s in MyExamsWithScore)
            {
                SumOfScors = SumOfScors + s.Score;
                CountOfScors++;
            }

            if(CountOfScors > 0)
            {
                double AverageScore = SumOfScors / CountOfScors;
                Console.WriteLine($"Ваш средний балл равен: {AverageScore}");
            }
            else
            {
                Console.WriteLine("Вам пока не поставили ни одной оценки за экзамен.");
            }
            Console.ReadKey();
            Console.Clear();
        }
    }
}
