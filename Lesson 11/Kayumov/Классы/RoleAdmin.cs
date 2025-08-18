using Exams.Интерфейсы;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exams.Классы
{
    public class RoleAdmin : IUserRole
    {                
        public bool isPasswordRight;

        public void EnterToSystem()
        {
            Console.WriteLine("Введити ваш пароль (пароль, если что = 111)");
            string Password = Console.ReadLine();

            if (Password == "111")
            {
                isPasswordRight = true;
                Console.Clear();
                Console.WriteLine("Вы успешно вошли в систему");
            }
            else 
            {
                isPasswordRight = false;                
            }
            
        }

        public void ActionToSystem()
        {
            string AdminChoice = "0";

            while (AdminChoice != "7")
            {                
                Console.WriteLine("Выберите действие (нажмите соответствующий номер):\n" +
                            "1. Добавить учебную дисциплину\n" +
                            "2. Показать список учебных дисциплин\n" +
                            "3. Добавить преподавателя\n" +
                            "4. Показать список преподавателей\n" +
                            "5. Добавить студента\n" +
                            "6. Показать список студентов\n" +
                            "7. Выйти в основное меню");

                AdminChoice = Console.ReadLine();

                switch (AdminChoice)
                {
                    case "1":
                        {
                            AddDisciplines();
                            break;
                        }
                    case "2":
                        {
                            ShowDisciplines();
                            break;
                        }
                    case "3":
                        {
                            AddTeachers();
                            break;
                        }
                    case "4":
                        {
                            ShowTeachers();
                            break;
                        }
                    case "5":
                        {
                            AddStudents();
                            break;
                        }
                    case "6":
                        {
                            ShowStudents();
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

        public List<EducationalEntity> _discipline = new List<EducationalEntity>();
        public void AddDisciplines()
        {
            string kindEntity = "Discipline";
           
            Console.WriteLine("Введите ИД новой учебной дисциплины");

            if (!int.TryParse(Console.ReadLine(), out int IDDiscipline))
            {
                Console.WriteLine("Некорректный ввод ID, при необходимости повторите ввод с другим ИД");
                return;
            }
            bool IdExist = _discipline.Any(i => i.Id == IDDiscipline);
            if (IdExist)
            {
                Console.WriteLine("Учебная дисциплина с таким ИД уже существует, при необходимости повторите ввод с другим ИД");                
                Console.WriteLine();
                return;
            }

            Console.WriteLine("Введите название новой учебной дисциплины");
            string NameDiscipline = Console.ReadLine();
            bool NameExist = _discipline.Any(i => i.Name == NameDiscipline);
            if (NameExist)
            {
                Console.WriteLine("Учебная дисциплина с таким названием уже существует, при необходимости повторите ввод с другим названием");                
                Console.WriteLine();
                return;
            }

            var newDiscipline = new EducationalEntity(IDDiscipline, NameDiscipline);

            if(NameDiscipline != "" && NameDiscipline != " ")
            {
                _discipline.Add(newDiscipline);

                Console.WriteLine($"Вы успешно добавили новую учебную дисциплину: ID: {IDDiscipline} Наименование: {NameDiscipline}");
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Неверно введено название учебной дисциплины, при необходимости повторите ввод учебной дисциплины");
            }

            Console.ReadKey();
            Console.Clear();
        }

        public void ShowDisciplines()
        {
            Console.Clear();
            Console.WriteLine("Список учебных дисциплин:");
            foreach (var item in _discipline)
            {
                Console.WriteLine($"{item.Id}. {item.Name}.");
            }
            Console.WriteLine();
        }

        public List<PersonTeacher> _teachers = new List<PersonTeacher>();
        public void AddTeachers()
        {
            string kindEntity = "Teacher";

            Console.WriteLine("Введите ИД нового преподавателя");

            if (!int.TryParse(Console.ReadLine(), out int IDTeacher))
            {
                Console.WriteLine("Некорректный ввод ID.");
                return;
            }

            bool IdExist = _teachers.Any(i => i.Id == IDTeacher);
            if (IdExist)
            {
                Console.WriteLine("Преподаватель с таким ИД уже существует, повторите ввод с другим ИД");
                Console.WriteLine();
                return;
            }

            Console.WriteLine("Введите ФИО нового преподавателя");
            string NameTeacher = Console.ReadLine();
            
            Console.WriteLine("Введите его пароль");
            string PasswordTeacher = Console.ReadLine();

            ShowDisciplines();
            Console.WriteLine("Введите ИД учебной дисциплины (из указанных выше), которую он будет вести:");            

            if (!int.TryParse(Console.ReadLine(), out int IDDisciplineTeacher))
            {
                Console.WriteLine("Некорректный ввод ID учебной дисциплины, при необходимости повторите ввод с другим ИД");
                Console.WriteLine();
                Console.ReadKey();                
                return;
            }                        

            if(NameTeacher != "" && NameTeacher != " ")
            {
                var newTeacher = new PersonTeacher(IDTeacher, NameTeacher, PasswordTeacher, IDDisciplineTeacher);
                _teachers.Add(newTeacher);
                Console.WriteLine("Преподаватель успешно добавлен в список!");
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Не удалось добавить нового преподавателя из-за неверно указанных ФИО. Повторите ввод его данных.");
            }
            Console.ReadKey();
            Console.Clear();
        }

        public void ShowTeachers()
        {
            Console.WriteLine("Список преподавателей:");

            if(_teachers.Count > 0)
            {
                foreach (var t in _teachers)
                {
                    string DisciplineName = "учебная дисциплина данного преподавателя еще не внесена в список.";

                    foreach (var d in _discipline)
                    {
                        if (d.Id == t.DisciplineId)
                        {
                            DisciplineName = d.Name;
                            break;
                        }
                    }

                    Console.WriteLine($"{t.Id}. {t.Name}. Ведет: {DisciplineName}");
                }
            }
            else
            {
                Console.WriteLine("преподаватели пока не внесены в список");
            }
            
            Console.ReadKey();
            Console.Clear();
        }

        public List<PersonStudent> _students = new List<PersonStudent>();
        public void AddStudents()
        {
            string kindEntity = "Student";

            Console.WriteLine("Введите ИД нового студента");

            if (!int.TryParse(Console.ReadLine(), out int IDStudent))
            {
                Console.WriteLine("Некорректный ввод ID.");
                return;
            }
            bool IdExist = _students.Any(i => i.Id == IDStudent);
            if (IdExist)
            {
                Console.WriteLine("Студент с таким ИД уже существует, повторите ввод с другим ИД");
                Console.WriteLine();
                return;
            }

            Console.WriteLine("Введите ФИО нового студента");
            string NameStudent = Console.ReadLine();

            if (NameStudent != "" && NameStudent != " ")
            {
                var newStudent = new PersonStudent(IDStudent, NameStudent);
                _students.Add(newStudent);
                Console.WriteLine("Студент успешно добавлен в список!");
            }
            else
            {
                Console.WriteLine("Не удалось добавить нового студента из-за неверно указанных ФИО. Повторите ввод его данных.");
            }

            Console.ReadKey();
            Console.Clear();
        }

        public void ShowStudents()
        {
            Console.WriteLine("Список студентов:");            

            if (_students.Count > 0)
            {
                foreach (var item in _students)
                {
                    Console.WriteLine($"{item.Id}. {item.Name}");
                }
            }
            else
            {
                Console.WriteLine("студенты пока не внесены в список");
            }
            Console.ReadKey();           
        }


    }
}
