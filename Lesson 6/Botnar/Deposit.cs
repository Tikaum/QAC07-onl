using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_6
{
    internal class Deposit
    {
        public static bool ShouldExit;
        public static void Draw(BankAccount account)
        {
            while (!ShouldExit)
            {
                ConsoleKeyInfo key;
                Console.Clear();
                Console.Clear();
                Console.WriteLine("ATM\n\n");
                Console.WriteLine("Внесение наличных\n");
                Console.WriteLine("Введите сумму: ");
                int amount = int.Parse(Console.ReadLine());

                if (amount > 0)
                {
                    account.Deposit(amount);
                    Console.WriteLine($"Внесено {amount}р.");
                    Console.WriteLine("Нажмите любую клавишу для возврата в главное меню...");
                    Console.ReadKey();
                    MainMenu.DrawMenu(account);
                }
                else
                {
                    Console.WriteLine("Количество сведств должно быть больше нуля");
                    Console.WriteLine("Нажмите любую клавишу для возврата в главное меню...");
                    Console.ReadKey();
                    break;
                }
            }
        }
    }
}
