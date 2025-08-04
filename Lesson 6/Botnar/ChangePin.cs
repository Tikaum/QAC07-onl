using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_6
{
    internal class ChangePin
    {
        private static int failedPinChecksCounter = 0;
        public static void SetNewPin(BankAccount account)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("ATM\n\n");
                Console.WriteLine("Смена PIN-кода\n");
                Console.WriteLine($"Осталось попыток: {3 - failedPinChecksCounter}");
                Console.WriteLine("Введите ТЕКУЩИЙ PIN:");
                Console.SetCursorPosition(21, 6);

                string oldPin = PinReader.GetPin();
                if (failedPinChecksCounter < 2)
                {
                    if (account.pin == oldPin)
                    {
                        Console.Clear();
                        Console.WriteLine("ATM\n\n");
                        Console.WriteLine("Введите НОВЫЙ PIN (4 цифры):");
                        Console.SetCursorPosition(29, 3);
                        string newPin1 = PinReader.GetPin();

                        Console.Clear();
                        Console.WriteLine("ATM\n\n");
                        Console.WriteLine("Повторите НОВЫЙ PIN для подтверждения:");
                        Console.SetCursorPosition(39, 3);
                        string newPin2 = PinReader.GetPin();

                        if (newPin1 != newPin2)
                        {
                            Console.SetCursorPosition(39, 3);
                            Console.WriteLine("PIN-коды не совпадают!\nНажмите любую клавишу для продолжения...");
                            Console.ReadKey();
                            continue;
                        }

                        Console.Clear();
                        Console.WriteLine("ATM\n\n");

                        try
                        {
                            account.pin = newPin1;
                            Console.WriteLine("PIN успешно изменен!");
                        }
                        catch (ArgumentException ex)
                        {
                            Console.WriteLine(ex.Message);
                            Console.ReadKey();
                            continue;
                        }

                        Console.WriteLine("\nНажмите любую клавишу для возврата в главное меню...");
                        Console.ReadKey();

                        new Authorise().Run(account);
                        return;
                    }
                    else
                    {
                        failedPinChecksCounter++;
                        Console.SetCursorPosition(21, 6);
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
