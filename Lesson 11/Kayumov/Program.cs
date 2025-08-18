using Exams.Классы;

namespace Exams
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var admin = new RoleAdmin();
            var examService = new ExamService(null, admin); 
            var teacher = new RoleTeacher(admin, examService);
            examService._roleTeacher = teacher;
            var student = new RoleStudent(admin, examService, teacher);

            Console.BackgroundColor = ConsoleColor.Blue;
            Console.Clear();

            while (true)
            {
                Console.WriteLine("Здравствуйте. Укажите вашу роль в системе (нажмите соответствующий номер):\n" +
                   "1. Студент\n" +
                   "2. Преподаватель\n" +
                   "3. Администратор\n");

                var roleEntered = Console.ReadLine();

                switch (roleEntered)
                {
                    case "1":
                        {
                            student.EnterToSystem();
                            if (student.isStudentMayEnter)
                            {
                                student.ActionToSystem();
                            }
                            else
                            {
                                Console.WriteLine("Введен несуществующий ИД. Повторите вход в систему");
                            }
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        }

                    case "2":
                        {
                            bool needRepeatCase2 = false;
                            bool isPasswordRight = false;

                            teacher.EnterToSystem();
                            
                            if (teacher.isTeacherPasswordRight)
                            {
                                teacher.ActionToSystem();
                            }

                            else if (!teacher.isTeacherPasswordRight)
                            {
                                Console.WriteLine("Введен неверный пароль.");
                                
                                Console.WriteLine("1. Повторить вход\n" +
                                "2. Вернуться в основное меню");

                                string action = Console.ReadLine();

                                if (action == "1")
                                {
                                    needRepeatCase2 = true;
                                }
                                if (needRepeatCase2)
                                {
                                    goto case "2";
                                }
                            }

                            else
                            {                                
                                Console.WriteLine("1. Повторить ввод\n" +
                                "2. Вернуться в основное меню");

                                string action = Console.ReadLine();

                                if (action == "1")
                                {
                                    needRepeatCase2 = true;
                                }
                                if (needRepeatCase2)
                                {
                                    goto case "2";
                                }
                            }                            

                            Console.Clear();
                            break;
                        }

                    case "3":
                        {
                            bool needRepeatCase3 = false;
                            bool isPasswordAdminRight = false;
                            
                            admin.EnterToSystem();
                            isPasswordAdminRight = admin.isPasswordRight;

                            if (isPasswordAdminRight)
                            {
                                admin.ActionToSystem();
                            }
                            else
                            {
                                Console.WriteLine("Введен неверный пароль.\n" +
                                "1. Повторить ввод\n" +
                                "2. Вернуться в основное меню");
                               
                                string action = Console.ReadLine();

                                if (action == "1")
                                {
                                    needRepeatCase3 = true;
                                }       
                            }

                            if (needRepeatCase3)
                            {
                                goto case "3";
                            }
                            
                            Console.Clear();
                            break;
                        }
                    default : 
                        {
                            Console.WriteLine("Пожалуйста проверьте вводимые данные и повторите ввод");
                            break;
                        }                    

                }
                
            }
            
            
            
            



            



            

        }
    }
}
