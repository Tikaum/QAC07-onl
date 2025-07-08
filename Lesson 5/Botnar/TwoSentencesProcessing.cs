using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_5
{
    internal class TwoSentencesProcessing
    {
        public void Run()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Введите первое предложение:");
                string sentence1 = Console.ReadLine();

                Console.WriteLine("Введите второе предложение:");
                string sentence2 = Console.ReadLine();

                LengthComparator.CompareLength(sentence1, sentence2);

                ContentComparator.CompareContent(sentence1, sentence2);

                WordCounter.CountWords(sentence1, sentence2);

                CommonWordsFinder.FindCommonWords(sentence1, sentence2);


                Console.WriteLine("\nЖелаете повторить для другой пары предложений? [Д/Н]");
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
