using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_6
{
    internal class Authorise
    {
        private int failedPinChecksCounter = 0;
        public void Run(BankAccount account)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("ATM\n\n");
                Console.WriteLine("Введите PIN: \n\n");
                Console.WriteLine($"ВНИМАНИЕ! После трёх неудачных попыток ввода карта будет заблокирована!\nОсталось попыток: {3 - failedPinChecksCounter}");
                Console.SetCursorPosition(13, 3);

                string userPin = PinReader.GetPin();
                var validator = new PinValidator(account, userPin);
                if (failedPinChecksCounter < 2)
                {
                    if (validator.IsValid())
                    {
                        MainMenu.DrawMenu(account);
                    }
                    else
                    {
                        failedPinChecksCounter++;
                        Console.SetCursorPosition(13, 3);
                        Console.WriteLine("НЕВЕРНЫЙ PIN");
                        System.Threading.Thread.Sleep(2000);
                    }
                }
                else
                {
                    Console.SetCursorPosition(0, 3);
                    Console.WriteLine("Исчерпано количество попыток ввода PIN. Карта заблокирована.\n");
                    System.Threading.Thread.Sleep(2000);
                    Environment.Exit(0);
                }
            }
        }
    }
}
