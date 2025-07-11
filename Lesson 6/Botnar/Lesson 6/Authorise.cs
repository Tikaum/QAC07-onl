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
        public void Run()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("ATM\n\n");
                Console.WriteLine("Введите четырёхзначный PIN: \n\n");
                Console.WriteLine($"ВНИМАНИЕ! После трёх неудачных попыток ввода карта будет заблокирована!\nОсталось попыток: {3 - failedPinChecksCounter}");
                Console.SetCursorPosition(28, 3);

                string userPin = PinReader.GetPin();
                var validator = new PinValidator(userPin);
                if (failedPinChecksCounter < 2)
                {
                    if (validator.IsValid())
                    {
                        MainMenu.DrawMenu();
                    }
                    else
                    {
                        failedPinChecksCounter++;
                        Console.SetCursorPosition(33, 3);
                        Console.WriteLine("НЕВЕРНЫЙ PIN");
                        System.Threading.Thread.Sleep(2000);
                    }
                }
                else
                {
                    Console.WriteLine("Исчерпано количество попыток ввода PIN. Карта заблокирована.");
                    System.Threading.Thread.Sleep(2000);
                    Environment.Exit(0);
                }
            }
        }
    }
}
