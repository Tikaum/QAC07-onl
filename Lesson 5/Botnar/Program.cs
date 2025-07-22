using Lesson_5;
using System.ComponentModel.Design;
using System.Threading.Tasks;

namespace Lesson_3
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Занятие 5. Домашнее задание.");
                Console.WriteLine("");
                Console.WriteLine("1. Определение самого длинного слова (Задача 1)");
                Console.WriteLine("2. Подсчёт символов в предложении (Задача 2)");
                Console.WriteLine("3. Обработка двух предложений (Задача 3)");
                Console.WriteLine("ESC. Выход из программы");
                Console.WriteLine("");
                Console.Write("Выберите необходимую задачу: ");
                ConsoleKeyInfo key = Console.ReadKey();
                await Task.Delay(500);
                Console.WriteLine("");

                switch (key.Key)
                {
                    case ConsoleKey.D1 or ConsoleKey.NumPad1:
                        new LongestWord().Run();
                        break;

                    case ConsoleKey.D2 or ConsoleKey.NumPad2:
                        new SymbolsCount().Run();
                        break;

                    case ConsoleKey.D3 or ConsoleKey.NumPad3:
                        new TwoSentencesProcessing().Run();
                        break;

                    case ConsoleKey.Escape:
                        Console.Clear();
                        Console.WriteLine("Осуществлён выход из программы.");
                        Environment.Exit(0);
                        break;

                    default:
                        Console.WriteLine("Ошибка: неверный выбор.");
                        await Task.Delay(500);
                        Console.Clear();
                        break;
                }
            }
        }
    }
}
