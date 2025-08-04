using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_6
{
    internal class TransactionsHistory
    {
        public static bool ShouldExit;
        public static void Draw(BankAccount account)
        {
            ConsoleKeyInfo key;
            Console.Clear();
            Console.Clear();
            Console.WriteLine("ATM\n\n");
            Console.WriteLine("История транзакций:\n");

            List<string> history = new List<string>(account.GetHistory());
            foreach (string log in history)
            {
                Console.WriteLine(log);
            }

            Console.WriteLine();
            Console.WriteLine("Нажмите любую клавишу для возврата в главное меню...");
            Console.ReadKey();
        }
    }
}
