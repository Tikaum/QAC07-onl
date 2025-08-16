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
            Console.WriteLine("Введити ваш пароль");
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
            int IDDiscipline = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Введите название новой учебной дисциплины");
            string NameDiscipline = Console.ReadLine();

            var newDiscipline = new EducationalEntity(IDDiscipline, NameDiscipline);

            _discipline.Add(newDiscipline);

            Console.WriteLine($"Вы успешно добавили новую учебную дисциплину: ID: {IDDiscipline} Наименование: {NameDiscipline}");
            Console.WriteLine();
        }

        public void ShowDisciplines()
        { 
            foreach (var item in _discipline)
            {
                Console.WriteLine($"{item.Id}. {item.Name}.");
            }
	    }

        public List<PersonTeacher> _teachers = new List<PersonTeacher>();
        public void AddTeachers()
        {
            string kindEntity = "Teacher";

            Console.WriteLine("Введите ИД нового преподавателя");
            int IDTeacher = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Введите имя нового преподавателя");
            string NameTeacher = Console.ReadLine();

            Console.WriteLine("Введите его пароль");
            string PasswordTeacher = Console.ReadLine();

            Console.WriteLine("Введите ИД учебной дисциплины, которую он ведет");
            ShowDisciplines();
            int IDDisciplineTeacher = Convert.ToInt32(Console.ReadLine());

            var newTeacher = new PersonTeacher(IDTeacher, NameTeacher, PasswordTeacher, IDDisciplineTeacher);

            _teachers.Add(newTeacher);
            Console.Clear();
        }

        public void ShowTeachers()
        {
            foreach (var t in _teachers)
            {
                string DisciplineName = "Ничего не ведет";

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
            Console.ReadKey();
            Console.Clear();
        }

        public List<PersonStudent> _students = new List<PersonStudent>();
        public void AddStudents()
        {
            string kindEntity = "Student";

            Console.WriteLine("Введите ИД нового студента");
            int IDStudent = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Введите имя нового студента");
            string NameStudent = Console.ReadLine();            

            var newStudent = new PersonStudent(IDStudent, NameStudent);

            _students.Add(newStudent);
        }

        public void ShowStudents()
        {
            foreach (var item in _students)
            {
                Console.WriteLine($"{item.Id}. {item.Name}.");
            }
        }


    }
}
