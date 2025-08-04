using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_6
{
    public static class Balance
    {
        public static void Draw(BankAccount account)
        {
            Console.Clear();
            Console.Clear();
            Console.WriteLine("ATM\n\n");
            Console.WriteLine($"Текущий баланс лицевого счёта: {account.GetBalance()}р.\n\n");
            Console.WriteLine("Нажмите любую клавишу для возврата в главное меню...");
            Console.ReadKey();
        }
    }
}
