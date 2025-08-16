using Exams.Интерфейсы;

namespace Exams.Классы
{
    public class RoleTeacher : IUserRole
    {              
        public RoleAdmin _adminRole;        
        public RoleTeacher(RoleAdmin adminRole)
        {
            _adminRole = adminRole;
        }
        public bool isTeacherPasswordRight { get; set; }

        public void EnterToSystem()
        {
            Console.WriteLine("Введити ваш ID: ");
            int TeacherID = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Введити ваш пароль");
            string TeacherPassword = Console.ReadLine();

            var teacher = _adminRole._teachers.FirstOrDefault(t => t.Id == TeacherID);
            isTeacherPasswordRight = teacher != null && teacher.Password == TeacherPassword;
        }                

        public void ActionToSystem()
        {
            string TeacherChoice = "0";

            while (TeacherChoice != "4")
            {
                Console.WriteLine("Выберите действие (нажмите соответствующий номер):\n" +
                            "1. Назначить дату экзамена по предмету\n" +
                            "2. Добавить студентов в экзаменационный список\n" +
                            "3. Проверить экзаменационные списки и проставить оценки по экзаменом\n" +
                            "4. Выйти в основное меню");

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
                            ShowAndGiveMarksForExam();
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
            Console.WriteLine("Выберите учебную дисциплину, по которой будет проводиться экзамен,\n" + "и введите ее ID");

            _adminRole.ShowDisciplines();           

            if (!int.TryParse(Console.ReadLine(), out int IDSelectedDiscipline))
            {
                Console.WriteLine("Некорректный ввод ID.");
                return;
            }

            string NameDiscipline = _adminRole._discipline.FirstOrDefault(n => n.Id == IDSelectedDiscipline).Name;

            Console.WriteLine("Введите дату экзамена, в формате гггг.мм.дд");

            DateOnly DateExam = DateOnly.Parse(Console.ReadLine());

            growingIdExam();

            var newExamDate = new EducationalEntity(IdExam, NameDiscipline, DateExam);

            _exams.Add(newExamDate);

            Console.WriteLine($"Вы успешно добавили экзамен по {NameDiscipline}, на дату: {DateExam}");
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
            Console.WriteLine("Выберите, из представленных ниже, учебную дисциплину и дату экзамена по ней:");

            foreach (var e in _exams)
            {
                Console.WriteLine($"{e.Id}. {e.Name}. {e.ExamDate}");
            }

            Console.WriteLine("Введите ID экзамена: ");

            if (!int.TryParse(Console.ReadLine(), out int IDSelectedExam))
            {
                Console.WriteLine("Некорректный ввод ID.");
                return;
            }

            string NameDiscipline = _exams.FirstOrDefault(n => n.Id == IDSelectedExam).Name;

            DateOnly DateExam = _exams.FirstOrDefault(n => n.Id == IDSelectedExam).ExamDate;

            Console.WriteLine($"Вы собираетесь добавить студентов в список экзаменуемых по предмету {NameDiscipline}, на дату: {DateExam}");
            Console.WriteLine("Список студентов, доступных для добавления:");
            _adminRole.ShowStudents();            

            Console.WriteLine($"Вводите последовательно по одному ИД студента, которого нужно добавить в список,\n" +
                "и число 1 или 2, для обозначения номера попытки сдачи экзамена (после ввода каждого значения нажмите Enter).");

            bool doAddingStudent = true;

            while (doAddingStudent)
            {
                Console.Write("ИД = ");

                if (!int.TryParse(Console.ReadLine(), out int IDAddingStudent))
                {
                    Console.WriteLine("Некорректный ввод ID.");
                    return;
                }

                string NameAddingStudent = _adminRole._students.FirstOrDefault(n => n.Id == IDAddingStudent).Name;

                Console.Write("Попытка № = ");

                if (!int.TryParse(Console.ReadLine(), out int Attemp))
                {
                    Console.WriteLine("Некорректный ввод.");
                    return;
                }

                growingIdStudentInExam();

                var newStudentInExam = new EducationalEntity(IdStudentInExam, NameDiscipline, DateExam, IDAddingStudent, NameAddingStudent, Attemp, 0);

                Console.WriteLine("Вы успешно добавили студента в список экзаменуемых.");

                _examsWithStudents.Add(newStudentInExam);

                Console.WriteLine("Закончить внесение студентов в список? (нажмите y или Y для выхода, либо Enter для продолжения)");
                string isContinue = Console.ReadLine();

                if (isContinue == "y" || isContinue == "Y" || isContinue == "у" || isContinue == "У" )
                {
                    doAddingStudent = false;
                    continue;
                }
            }

            var ReportOfAddingStudent = _examsWithStudents.Where(i => i.Name == NameDiscipline && i.ExamDate == DateExam).ToList();

            Console.WriteLine($"В экзамене по {NameDiscipline}, назначенном на {DateExam}, будут участововать следующие студенты:");
            foreach (var s in ReportOfAddingStudent)
            {
                Console.WriteLine($"Студент: {s.StudentName}. Попытка: {s.Attempt}");
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
                            "1. Посмотреть списки экзаменов, со студентами\n" +
                            "2. Проставить оценки по экзамену\n" +
                            "3. Выйти в меню преподователя");

                Choice = Console.ReadLine();

                switch (Choice)
                {
                    case "1":
                        {
                            ShowExamAndDateWithStudents();
                            break;
                        }
                    case "2":
                        {
                            GiveMarksForExam();
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

        public void ShowExamAndDateWithStudents()
        {
            foreach (var e in _exams)
            {
                Console.WriteLine($"{e.Id}. Экзамен по {e.Name}. Назначен на дату: {e.ExamDate}");

                var studentsForExam = _examsWithStudents.Where(i => i.Name == e.Name && i.ExamDate == e.ExamDate).ToList();

                if(studentsForExam.Count() > 0)
                {
                    Console.WriteLine("В экзамене участвуют студенты:");
                    foreach(var student in studentsForExam)
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

        public void GiveMarksForExam()
        {                           
            DateOnly CurrentDate = DateOnly.FromDateTime(DateTime.Now);

            var EndedExams = new List<EducationalEntity>();

            foreach (var e in _exams)
            {
                EndedExams = _exams.Where(i => i.ExamDate <= CurrentDate).ToList();
            }

            if (EndedExams.Count() > 0)
            {
                Console.WriteLine("На данный момент проведены следующие экзамены:");
                foreach (var endedExams in EndedExams)
                {
                    Console.WriteLine($"{endedExams.Id}, {endedExams.Name}, {endedExams.ExamDate}");
                }

                Console.WriteLine("Введите ИД экзамена, по которому будут проставляться оценки:");
                int IdSelectExamToGiveMarks = Convert.ToInt32(Console.ReadLine());

                var NameOfSelectExamToGiveMarks = _exams.First(e => e.Id == IdSelectExamToGiveMarks).Name;

                var StudentsInSelectExamToGiveMarks = _examsWithStudents.Where(i => i.Name == NameOfSelectExamToGiveMarks).ToList();

                foreach (var s in StudentsInSelectExamToGiveMarks)
                {
                    Console.WriteLine($"Имя студента {s.StudentName}. Попытка: {s.Attempt}. Оценка: {s.Score}");
                }

            }
            else
            {
                Console.WriteLine("Пока не проведено ни одного экзамена");
                Console.ReadKey();                
            }


            



        }


    }
}

