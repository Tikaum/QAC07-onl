using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_6
{
    internal class PinReader
    {
        public static string GetPin()
        {
            StringBuilder pin = new StringBuilder();
            ConsoleKeyInfo key;

            do
            {
                key = Console.ReadKey(intercept: true);

                if (key.Key != ConsoleKey.Enter)
                {
                    if (key.Key == ConsoleKey.Backspace && pin.Length > 0)
                    {
                        pin.Remove(pin.Length - 1, 1);
                        Console.Write("\b \b");
                    }
                    else if (!char.IsControl(key.KeyChar) && pin.Length < 4)
                    {
                        pin.Append(key.KeyChar);
                        Console.Write("*");
                    }
                }
            }
            while (key.Key != ConsoleKey.Enter || pin.Length != 4);

            return pin.ToString();
        }
    }
}
