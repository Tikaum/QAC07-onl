using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_5
{
    internal class SymbolsCount
    {
        public void Run()
        {
            while (true)
            {

                Console.Clear();
                Console.WriteLine("Подсчёт символов в предложении \n");
                Console.WriteLine("Введите предложение: ");
                string input = Console.ReadLine();
                input = input.ToLower();
                string symbolType;
                int vovelCount = 0;
                int consontantCount = 0;
                int digitCount = 0;
                int spaceCount = 0;


                foreach (char symbol in input)

                {
                    symbolType = SymbolChecker.GetSymbolType(symbol);
                    
                    if (symbolType == "vovel")
                        vovelCount++;
                    else if (symbolType == "consontant")
                        consontantCount++;
                    else if (symbolType == "digit")
                        digitCount++;
                    else if (symbolType == "space")
                        spaceCount++;
                }
                
                Console.WriteLine($"\nКоличество символов по типам:\nГласных: {vovelCount}\nСогласных: {consontantCount}\nЦифр: {digitCount}\nПробелов {spaceCount}");

                Console.WriteLine("\nЖелаете повторить для другого предложения? [Д/Н]");
                ConsoleKeyInfo key = Console.ReadKey();
                switch (key.Key)
                {
                    case ConsoleKey.L:
                        break;

                    case ConsoleKey.Y or ConsoleKey.Escape:
                        Console.Clear();
                        return;
                }
            }
        }
    }
}
