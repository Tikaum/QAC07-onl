using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_6
{
    internal class WelcomeScreen
    {
        public static bool ShouldExit;
        public static void DrawWelcomeScreen()
        {
            while (!ShouldExit)
            {
                Console.Clear();
                Console.WriteLine("ATM\n\n");
                Console.WriteLine("Нажмите 1, что бы ввести карту.\nНажмите ESC для выхода.");
                ConsoleKeyInfo key = Console.ReadKey();
                switch (key.Key)
                {
                    case ConsoleKey.D1 or ConsoleKey.NumPad1:
                        var account = new BankAccount
                        {
                            pin = "1122"
                        };
                        System.Threading.Thread.Sleep(500);
                        new Authorise().Run(account);
                        break;

                    case ConsoleKey.Escape:
                        ShouldExit = true;
                        break;
                }
            }
            Environment.Exit(0);
        }
    }
}
