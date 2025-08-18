using Exams.Интерфейсы;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Exams.Классы
{
    public class RoleTeacher : IUserRole
    {              
        public RoleAdmin _roleAdmin;
        public ExamService _examService;
        public RoleTeacher(RoleAdmin roleAdmin, ExamService examService)
        {
            _roleAdmin = roleAdmin;
            _examService = examService;
        }
        public bool isTeacherPasswordRight { get; set; }
       
        public void EnterToSystem()
        {
            Console.WriteLine("Введити ваш ID: ");            

            if (!int.TryParse(Console.ReadLine(), out int TeacherID))
            {
                Console.WriteLine("Некорректный ввод ID. При необходимости повторите ввод.");                
                return;
            }

            Console.WriteLine("Введити ваш пароль");
            string TeacherPassword = Console.ReadLine();

            var teacher = _roleAdmin._teachers.FirstOrDefault(t => t.Id == TeacherID);
            isTeacherPasswordRight = teacher != null && teacher.Password == TeacherPassword;
        }                

        public void ActionToSystem()
        {
            string TeacherChoice = "0";

            while (TeacherChoice != "6")
            {
                Console.WriteLine("Выберите действие (нажмите соответствующий номер):\n" +
                            "1. Назначить дату экзамена по предмету\n" +
                            "2. Добавить студентов в экзаменационный список\n" +
                            "3. Просмотреть экзаменационные списки\n" +
                            "4. Просмотреть или проставить оценки по экзаменам\n" +
                            "5. Просмотреть статистику по студентам\n" +
                            "6. Выйти в основное меню");

                TeacherChoice = Console.ReadLine();

                switch (TeacherChoice)
                {
                    case "1":
                        {
                            SetDataExam();
                            break;
                        }
                    case "2":
                        {
                            AddStudentsToExam();
                            break;
                        }
                    case "3":
                        {
                            ShowExamAndDateWithStudents();
                            break;
                        }
                    case "4":
                        {
                            ShowAndGiveMarksForExam();
                            break;
                        }
                    case "5":
                        {
                            Statistics();
                            break;
                        }



                    case "6":
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


        public List<EducationalEntity> _exams = new List<EducationalEntity>();

        public int nextIdExam = 1;
        public int IdExam { get; set; }

        public void growingIdExam()
        {
            IdExam = nextIdExam++;
        }
        public void SetDataExam()
        {
            Console.Clear();
            Console.WriteLine("Выберите учебную дисциплину по которой будет проводиться экзамен \n" +
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
            
            Console.WriteLine();

            if (_roleAdmin._discipline.Any(i => i.Id == IDSelectedDiscipline))
            {
                string NameDiscipline = _roleAdmin._discipline.FirstOrDefault(n => n.Id == IDSelectedDiscipline).Name;
                
                DateOnly DateExam = DateOnly.FromDateTime(DateTime.Now);
                bool IsDateExamValid = false;

                while (!IsDateExamValid)
                {
                    Console.Write("Введите дату экзамена, в формате гггг.мм.дд: ");

                    try
                    {
                        DateExam = DateOnly.Parse(Console.ReadLine());
                        IsDateExamValid = true;                        
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Дата введена в неверном формате. Попробуйте ещё раз.");
                    }
                }

                growingIdExam();

                var newExamDate = new EducationalEntity(IdExam, NameDiscipline, DateExam);

                _exams.Add(newExamDate);

                Console.WriteLine($"Вы успешно добавили экзамен по {NameDiscipline}, на дату: {DateExam}");
            }
            else
            {
                Console.WriteLine("Учебной дисциплины с таким ИД не существует. При необходимости повторите ввод.");
            }
            
            Console.ReadKey();
            Console.Clear();
        }

        public List<EducationalEntity> _examsWithStudents = new List<EducationalEntity>();

        public int nextIdStudentInExam = 1;
        public int IdStudentInExam { get; set; }

        public void growingIdStudentInExam()
        {
            IdStudentInExam = nextIdStudentInExam++;
        }
        public void AddStudentsToExam()
        {
            bool ExistExam = _exams.Count > 0;

            if (ExistExam)
            {
                Console.WriteLine("Выберите, из представленных ниже, экзамен по учебной дисциплине:");

                foreach (var e in _exams)
                {
                    Console.WriteLine($"{e.Id}. По {e.Name}. Будет проводиться {e.ExamDate}");
                }

                Console.Write("и введите ID экзамена: ");

                int IDSelectedExam = 0;
                if (!int.TryParse(Console.ReadLine(), out IDSelectedExam))
                {
                    Console.WriteLine("Некорректный ввод ID экзамена. При необходимости повторите ввод.");
                    Console.WriteLine();
                    return;
                }
                Console.WriteLine();

                bool IdExamExist = _exams.Any(i => i.Id == IDSelectedExam);

                if (IdExamExist)
                {
                    string NameDiscipline = _exams.FirstOrDefault(n => n.Id == IDSelectedExam).Name;

                    DateOnly DateExam = _exams.FirstOrDefault(n => n.Id == IDSelectedExam).ExamDate;

                    Console.WriteLine($"Вы собираетесь добавить студентов в список экзаменуемых по предмету {NameDiscipline}, на дату: {DateExam}");
                    Console.WriteLine();
                    _roleAdmin.ShowStudents();

                    Console.WriteLine($"Вводите последовательно по одному ИД студента, которого нужно добавить в список,\n" +
                        "и число 1 или 2, для обозначения номера попытки сдачи экзамена (после ввода каждого значения нажмите Enter).");

                    bool doAddingStudent = true;

                    while (doAddingStudent)
                    {
                        Console.Write("ИД студента: ");
                        
                        if (!int.TryParse(Console.ReadLine(), out int IDAddingStudent))
                        {
                            Console.WriteLine("Некорректный ввод ID студента");
                            return;
                        }                      

                        if (_roleAdmin._students.Any(i => i.Id == IDAddingStudent))
                        {
                            string NameAddingStudent = _roleAdmin._students.FirstOrDefault(n => n.Id == IDAddingStudent).Name;

                            // ToDo - добавить отбой, если студент уже добавлен в экзамен

                            Console.Write("Попытка сдачи экзамена №: ");

                            if (!int.TryParse(Console.ReadLine(), out int Attemp))
                            {
                                Console.WriteLine("Некорректный ввод номера попытки");
                                Console.ReadKey();
                                continue;
                            }

                            var AttempsOfStudent = _examsWithStudents.Where(a => a.Name == NameDiscipline && a.StudentName == NameAddingStudent).ToList();
                            int CurrentNumberOfAttemps = AttempsOfStudent.Count;

                            if (Attemp < 1 || Attemp > 2)
                            {
                                Console.WriteLine("Количество попыток сдачи экзамена студентом, указано неверно (допустимые значения: 1 или 2).\n" + 
                                    "Повторите ввод.");
                                Console.ReadKey();
                                continue;
                            }

                            if (CurrentNumberOfAttemps >= 2)
                            {
                                Console.WriteLine("Количество попыток сдачи экзамена студентом, превысило допустимый лимит пересдач (не более одной)!");
                                Console.ReadKey();
                                return;
                            }

                            growingIdStudentInExam();

                            var newStudentInExam = new EducationalEntity(IdStudentInExam, NameDiscipline, DateExam, IDAddingStudent, NameAddingStudent, Attemp, 0);

                            _examsWithStudents.Add(newStudentInExam);
                            Console.WriteLine("Вы успешно добавили студента в список экзаменуемых.");
                        }

                        else
                        {
                            Console.WriteLine("Студента с таким ИД не существует. При необходимости повторите ввод.");
                            Console.WriteLine();
                        }

                        Console.WriteLine("Закончить внесение студентов в список? (нажмите y или Y для выхода, либо Enter для продолжения)");
                        string ToExit = Console.ReadLine();

                        if (ToExit == "y" || ToExit == "Y" || ToExit == "у" || ToExit == "У")
                        {
                            doAddingStudent = false;
                            continue;
                        }
                    }

                    var ReportOfAddingStudent = _examsWithStudents.Where(i => i.Name == NameDiscipline && i.ExamDate == DateExam).ToList();

                    Console.WriteLine($"В экзамене по {NameDiscipline}, назначенном на {DateExam}, будут участововать следующие студенты:");
                    foreach (var s in ReportOfAddingStudent)
                    {
                        Console.WriteLine($"{s.StudentName}. Попытка: {s.Attempt}");
                    }
                }

                else
                {
                    Console.WriteLine("Экзамена с таким ИД не существует. При необходимости повторите ввод.");
                }
            }

            else
            {
                Console.WriteLine("Пока не назначено ни одного экзамена");
            }                
            
            Console.ReadKey();
            Console.Clear();
        }

        public void ShowExamAndDateWithStudents()
        {
            bool ExistExam = _exams.Count > 0;

            if (ExistExam)
            {
                foreach (var e in _exams)
                {
                    Console.WriteLine($"{e.Id}. Экзамен по {e.Name}. Назначен на дату: {e.ExamDate}");

                    var studentsForExam = _examsWithStudents.Where(i => i.Name == e.Name && i.ExamDate == e.ExamDate).ToList();

                    if (studentsForExam.Count() > 0)
                    {
                        Console.WriteLine("В экзамене участвуют следующие студенты:");
                        foreach (var student in studentsForExam)
                        {
                            Console.WriteLine(student.StudentName);
                        }
                    }
                    else
                    {
                        Console.WriteLine("На экзамен никто не записан");
                    }

                }
            }

            else
            {
                Console.WriteLine("Пока не назначено ни одного экзамена");
            }
            Console.ReadKey();
            Console.Clear();
        }


        public void ShowAndGiveMarksForExam()
        {
            string Choice = "0";

            while (Choice != "3")
            {
                Console.WriteLine("Выберите действие (нажмите соответствующий номер):\n" +                            
                            "1. Проставить оценки по экзамену\n" +
                            "2. Просмотреть оценки по экзамену\n" +
                            "3. Выйти в меню преподавателя");

                Choice = Console.ReadLine();

                switch (Choice)
                {                    
                    case "1":
                        {
                            GiveMarksForExam();
                            break;
                        }

                    case "2":
                        {
                            ShowExamWithScore();
                            break;
                        }

                    case "3":
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

        List<EducationalEntity> EndedExams = new List<EducationalEntity>();

        public void WhichEndedExams()
        {
            DateOnly CurrentDate = DateOnly.FromDateTime(DateTime.Now);            
            
            foreach (var e in _exams)
            {
                EndedExams = _exams.Where(i => i.ExamDate <= CurrentDate).ToList();
            }            
        }               

        public void GiveMarksForExam()
        {
            WhichEndedExams();

            if (EndedExams.Count() > 0)
            {
                Console.WriteLine("На данный момент проведены следующие экзамены:");
                foreach (var endedExams in EndedExams)
                {
                    Console.WriteLine($"{endedExams.Id}. По {endedExams.Name}, дата проведения {endedExams.ExamDate}");
                }
               
                Console.WriteLine("Введите ИД экзамена, по которому будут проставляться оценки:");                               
                if (!int.TryParse(Console.ReadLine(), out int IdSelectExamToGiveScors))
                {
                    Console.WriteLine("Некорректный ввод ID экзамена");
                    return;
                }
                bool IDExamExistInEndedExams = EndedExams.Any(i => i.Id == IdSelectExamToGiveScors);                

                if (IDExamExistInEndedExams)
                {
                    var NameOfSelectExamToGiveScors = _exams.First(e => e.Id == IdSelectExamToGiveScors).Name;
                    var DateOfSelectExamToGiveScors = _exams.First(e => e.Id == IdSelectExamToGiveScors).ExamDate;

                    var StudentsInSelectedExamToGiveScors = _examsWithStudents.Where(i => i.Name == NameOfSelectExamToGiveScors && i.ExamDate == DateOfSelectExamToGiveScors).ToList();

                    bool IsExistStudentInSelectExamToGiveScors = StudentsInSelectedExamToGiveScors.Count > 0;

                    if (IsExistStudentInSelectExamToGiveScors)
                    {
                        Console.WriteLine("Проставьте оценки для каждого студента:");

                        foreach (var s in StudentsInSelectedExamToGiveScors)
                        {
                            Console.Write($"Студент {s.StudentName}, получил оценку: ");

                            if (!int.TryParse(Console.ReadLine(), out int score))
                            {
                                Console.WriteLine("Оценка должна быть целочисленным значением. Повторите ввод");
                                continue;
                            }
                            if (score > 1 && score < 6)
                            {
                                var studentToUpdate = _examsWithStudents.First(i => i.Name == NameOfSelectExamToGiveScors && i.ExamDate == DateOfSelectExamToGiveScors && i.StudentName == s.StudentName);

                                if (studentToUpdate != null)
                                {
                                    studentToUpdate.Score = score;
                                }
                            }
                            else
                            {
                                Console.WriteLine("Недопустимое значение оценки (допустимые значения: 2, 3, 4, 5).\n" +
                                    "Повторите ввод оценки для данного студента в другой раз.");
                                continue;
                            }
                        }

                        Console.WriteLine($"За экзамен по {NameOfSelectExamToGiveScors} от {DateOfSelectExamToGiveScors} успешно проставлены оценки.");

                        //foreach (var s in StudentsInSelectedExamToGiveScors)
                        //{
                        //    if (s.Score != 0 && s.Score > 1 && s.Score < 6)
                        //    {
                        //        Console.WriteLine($"Студент {s.StudentName}, получил оценку: {s.Score}");
                        //    }

                        //    else
                        //    {
                        //        Console.WriteLine($"Студент {s.StudentName} пока не получил оценку, либо она было проставлена неверно");
                        //    }
                        //}
                        Console.ReadKey();
                    }

                    else
                    {
                        Console.WriteLine("На экзамен с данным ИД не был записан ни один студент.");
                        Console.ReadKey();
                    }
                }
                                    
                else
                {
                    Console.WriteLine("Экзамен с данным ИД не существует или не был проведен");
                    Console.ReadKey();
                }               
            }
            else
            {
                Console.WriteLine("Пока не проведено ни одного экзамена");
                Console.ReadKey();
            }
            Console.Clear();
        }

        public void ShowExamWithScore()
        {
            WhichEndedExams();

            if (EndedExams.Count() > 0)
            {
                Console.WriteLine("На данный момент проведены следующие экзамены:");
                foreach (var endedExams in EndedExams)
                {
                    Console.WriteLine($"{endedExams.Id}. По {endedExams.Name}, дата проведения: {endedExams.ExamDate}");
                }

                Console.WriteLine("Введите ИД экзамена, по которому будут просматриваться оценки:");                
                if (!int.TryParse(Console.ReadLine(), out int IdSelectExamToBrowseScors))
                {
                    Console.WriteLine("Некорректный ввод ID экзамена");
                    return;
                }
                bool IDExamExistInBrowseExams = EndedExams.Any(i => i.Id == IdSelectExamToBrowseScors);

                if (IDExamExistInBrowseExams)
                {
                    var NameOfSelectExamToBrowseScors = _exams.First(e => e.Id == IdSelectExamToBrowseScors).Name;
                    var DateOfSelectExamToBrowseScors = _exams.First(e => e.Id == IdSelectExamToBrowseScors).ExamDate;

                    var StudentsInSelectedExamToBrowseScors = _examsWithStudents.Where(i => i.Name == NameOfSelectExamToBrowseScors && i.ExamDate == DateOfSelectExamToBrowseScors).ToList();                    

                    if (StudentsInSelectedExamToBrowseScors.Count > 0)
                    {
                        Console.WriteLine($"По экзамену {NameOfSelectExamToBrowseScors}, от {DateOfSelectExamToBrowseScors} проставлены следующие оценки:");

                        foreach (var s in StudentsInSelectedExamToBrowseScors)
                        {
                            if (s.Score != 0 && s.Score > 1 && s.Score < 6)
                            {
                                Console.WriteLine($"Студент {s.StudentName}, получил оценку: {s.Score}");
                            }

                            else
                            {
                                Console.WriteLine($"Студент {s.StudentName}, пока не получил оценку");
                            }
                        }
                        Console.ReadKey();
                    }
                    else
                    {
                        Console.WriteLine("На экзамен с данным ИД не был записан ни один студент.");
                        Console.ReadKey();
                    }
                    
                }

                else
                {
                    Console.WriteLine("Экзамен с данным ИД не существует или не был проведен");
                    Console.ReadKey();
                }                           
            }
            else
            {
                Console.WriteLine("Пока не проведено ни одного экзамена");
                Console.ReadKey();
            }
            Console.ReadKey();
            Console.Clear();
        }

        public void Statistics()
        {
            string Choice = "0";

            while (Choice != "4")
            {
                Console.WriteLine("Выберите действие (нажмите соответствующий номер):\n" +
                            "1. Посмотреть рейтинг по студенту\n" +
                            "2. Просмотреть статистику по предмету\n" +
                            "3. Просмотреть кандидатов на отчисление по предмету\n" +
                            "4. Выйти в меню преподавателя");

                Choice = Console.ReadLine();

                switch (Choice)
                {
                    case "1":
                        {
                            _examService.RatingOfStudent();
                            break;
                        }
                    case "2":
                        {
                            _examService.StatisticOfDiscipline();                            
                            break;
                        }
                    case "3":
                        {
                            _examService.ShowCandidateForExpulsion();
                            break;
                        }
                    case "4":
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
    }    
}

