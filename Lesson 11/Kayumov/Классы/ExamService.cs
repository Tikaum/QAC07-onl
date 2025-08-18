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

            if (_roleAdmin._students.Any(i => i.Id == IDStudent))
            {                
                var AllExamsWithStudent = _roleTeacher._examsWithStudents?.Where(a => a.StudentID == IDStudent).ToList() ?? new List<EducationalEntity>();                

                var AllExamsWithStudentAndMarkScors = AllExamsWithStudent.Where(a => a.Score == 2 || a.Score == 3 || a.Score == 4 || a.Score == 5).ToList();
                var SuccessExamsWithStudent = AllExamsWithStudent.Where(a => a.Score == 4 || a.Score == 5).ToList();
                
                double CountOfAllExams = AllExamsWithStudentAndMarkScors.Count();
                double CountOfSuccessExams = SuccessExamsWithStudent.Count();

                if(AllExamsWithStudentAndMarkScors.Count() > 0)
                {
                    double Rating = (CountOfSuccessExams / CountOfAllExams) * 100;
                    Console.WriteLine($"Рейтинг (% успешно сданных экзаменов к их общему количеству) студента {_roleTeacher._examsWithStudents.First(a => a.StudentID == IDStudent).StudentName} равен: {Rating}");
                }
                else
                {
                    Console.WriteLine("Студенту с таким ИД пока не поставили ни одной оценки.");
                }
                
            }

            else
            {
                Console.WriteLine("Студента с таким ИД не существует. При необходимости повторите ввод.");
                Console.WriteLine();
            }
            Console.ReadKey();
            Console.Clear();
        }

        public void StatisticOfDiscipline()
        {
            Console.WriteLine("Выберите учебную дисциплину, статистику по которой вы желаете посмотреть");
            _roleAdmin.ShowDisciplines();
            Console.Write("Введите её ИД: ");

            if (!int.TryParse(Console.ReadLine(), out int IDSelectedDiscipline))
            {
                Console.WriteLine("Некорректный ввод ID учебной дисциплины");
                return;
            }            

            if (_roleAdmin._discipline.Any(i => i.Id == IDSelectedDiscipline))
            {
                string NameDiscipline = _roleAdmin._discipline.FirstOrDefault(n => n.Id == IDSelectedDiscipline).Name;
                
                var AllExamsWithScorsOfDiscipline = _roleTeacher._examsWithStudents?.Where(a => a.Name == NameDiscipline && (a.Score != 0 || a.Score > 1 || a.Score < 6)).ToList() ?? new List<EducationalEntity>();

                double SumOfScors = 0;
                int CountOfScors = 0;

                foreach (var s in AllExamsWithScorsOfDiscipline)
                {
                    SumOfScors = SumOfScors + s.Score;
                    CountOfScors++;
                }

                if(AllExamsWithScorsOfDiscipline.Count > 0)
                {
                    double AverageScoreOfDiscipline = SumOfScors / CountOfScors;
                    Console.WriteLine($"Средний балл по учебной дисциплине равен: {AverageScoreOfDiscipline}");
                }
                else
                {
                    Console.WriteLine("По учебной дисциплине пока нет ни одной оценки");
                }
            }
            Console.ReadKey();
            Console.Clear();
        }

        public List<PersonStudent> StudentsCandidateForExpulsion = new List<PersonStudent>();

        public void ShowCandidateForExpulsion()
        {
            Console.WriteLine("Выберите учебную дисциплину по которой будет проводиться поиск кандидатов на отчисление\n" +
                "(из списка представленного ниже):");
            _roleAdmin.ShowDisciplines();
            Console.Write("и введите ее ID: ");

            if (!int.TryParse(Console.ReadLine(), out int IDSelectedDiscipline))
            {
                Console.WriteLine("Некорректный ввод ID учебной дисциплины. При необходимости повторите ввод.");
                Console.ReadKey();
                Console.Clear();
                return;
            }

            if (_roleAdmin._discipline.Any(i => i.Id == IDSelectedDiscipline))
            {
                string NameDiscipline = _roleAdmin._discipline.FirstOrDefault(n => n.Id == IDSelectedDiscipline).Name;

                var ExamsWithScore2InDiscipline = _roleTeacher._examsWithStudents?.Where(a => a.Score == 2 && a.Name == NameDiscipline).ToList() ?? new List<EducationalEntity>();

                if (ExamsWithScore2InDiscipline.Count() > 0)
                {
                    foreach(var checkEveryStudent in _roleAdmin._students)
                    {                                              
                        var ListOfAttempToStudent = ExamsWithScore2InDiscipline.Where(s => s.StudentName == checkEveryStudent.Name).ToList();
                        if (ListOfAttempToStudent.Count == 2)
                        {
                            var IdAndNameStudent = new PersonStudent(checkEveryStudent.Id, checkEveryStudent.Name);

                            StudentsCandidateForExpulsion.Add(IdAndNameStudent);
                        }
                    }

                    if (StudentsCandidateForExpulsion.Count > 0)
                    {
                        Console.WriteLine("По данной учебной дисциплине есть следующие кандидаты на отчисление");

                        foreach (var candidats in StudentsCandidateForExpulsion)
                        {
                            Console.WriteLine(candidats.Name);
                        }
                        StudentsCandidateForExpulsion.Clear();
                    }
                    else
                    {
                        Console.WriteLine("По данной учебной дисциплине нет кандидатов на отчисление (in cycle)");
                    }
                }
                else
                {
                    Console.WriteLine("По данной учебной дисциплине нет кандидатов на отчисление");
                }
            }            
            else
            {
                Console.WriteLine("Студенту с таким ИД пока не поставили ни одной оценки.");
            }
            Console.ReadKey();
            Console.Clear();
        }

    }
}
