using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_6
{
    internal class WelcomeScreen
    {
        public static bool ShouldExit { get; private set; }
        public static void DrawWelcomeScreen()
        {
            Console.Clear();
            Console.WriteLine("ATM\n\n");
            Console.WriteLine("Нажмите 1, что бы ввести карту.");
            ConsoleKeyInfo key = Console.ReadKey();
            switch (key.Key)
            {
                case ConsoleKey.D1 or ConsoleKey.NumPad1:
                    System.Threading.Thread.Sleep(500);
                    new Authorise().Run();
                    break;

                case ConsoleKey.Escape:
                    ShouldExit = true;
                    break;

                default:
                    Console.Clear();
                    break;
            }
        }
    }
}
