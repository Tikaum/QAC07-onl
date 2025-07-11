using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_6
{
    internal class MainMenu
    {
        public static void DrawMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("ATM\n\n");
                Console.WriteLine("1. Проверить баланс");
                Console.WriteLine("2. Снять наличные");
                Console.WriteLine("3. Внести наличные");
                Console.WriteLine("4. История транзакций");
                Console.WriteLine("5. Сменить PIN");
                Console.WriteLine("0. Вернуть карту");


                var key = Console.ReadKey(true);
                switch (key.Key)
                {
                    case ConsoleKey.D1 or ConsoleKey.NumPad1:
                        // Вызов метода проверки баланса
                        break;
                    case ConsoleKey.D2 or ConsoleKey.NumPad2:
                        // Вызов метода снятия денег
                        break;
                    case ConsoleKey.D3 or ConsoleKey.NumPad3:
                        // Вызов метода внесения денег
                        break;
                    case ConsoleKey.D4 or ConsoleKey.NumPad4:
                        // Вызов метода истории транзакций
                        break;
                    case ConsoleKey.D5 or ConsoleKey.NumPad5:
                        // Вызов метода смены пина
                        break;
                    case ConsoleKey.D0:
                        WelcomeScreen.DrawWelcomeScreen();
                        break;
                }
            }
        }
    }
}
