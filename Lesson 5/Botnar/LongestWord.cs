using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_5
{
    internal class LongestWord
    {
        public void Run()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Определение самого длинного слова \n");
                Console.WriteLine("Введите слова, разделённые символами ");
                string input = Console.ReadLine();
                string[] words = input.Split(' ');
                string resultWord = null;
                int resultCount = 0;


                foreach (string word in words)

                {
                    if (word.Length > resultCount)
                    {
                        resultCount = word.Length; resultWord = word;
                    }
                }

                Console.WriteLine($"Самое длинное слово: \"{resultWord}\" содержит символов: {resultCount} ");

                Console.WriteLine("\nЖелаете повторить для другого набора слов? [Д/Н]");
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
