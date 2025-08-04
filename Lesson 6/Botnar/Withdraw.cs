using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_6
{
    internal class Withdraw
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
                Console.WriteLine("Выдача наличных\n");
                Console.WriteLine("Введите сумму: ");
                int amount = int.Parse(Console.ReadLine());

                if (amount <= account.GetBalance())
                {
                    account.Withdraw(amount);
                    Console.WriteLine($"Выдано {amount}р.\n");
                    Console.WriteLine("Нажмите любую клавишу для возврата в главное меню...");
                    Console.ReadKey();
                    break;
                }
                else
                {
                    Console.WriteLine("Недостаточно средств\n");
                    Console.WriteLine("Нажмите любую клавишу для возврата в главное меню...");
                    Console.ReadKey();
                    break;
                }
            }
        }
    }
}
