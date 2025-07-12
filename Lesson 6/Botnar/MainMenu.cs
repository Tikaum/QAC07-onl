using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_6
{
    internal class MainMenu
    {
        public static void DrawMenu(BankAccount account)
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


                var key = Console.ReadKey();
                switch (key.Key)
                {
                    case ConsoleKey.D1 or ConsoleKey.NumPad1:
                        Balance.Draw(account);
                        break;
                    case ConsoleKey.D2 or ConsoleKey.NumPad2:
                        Withdraw.Draw(account);
                        break;
                    case ConsoleKey.D3 or ConsoleKey.NumPad3:
                        Deposit.Draw(account);
                        break;
                    case ConsoleKey.D4 or ConsoleKey.NumPad4:
                        TransactionsHistory.Draw(account);
                        break;
                    case ConsoleKey.D5 or ConsoleKey.NumPad5:
                        ChangePin.SetNewPin(account);
                        break;
                    case ConsoleKey.D0 or ConsoleKey.NumPad0:
                        WelcomeScreen.DrawWelcomeScreen();
                        break;
                }
            }
        }
    }
}
