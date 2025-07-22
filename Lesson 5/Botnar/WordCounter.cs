using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_5
{
    internal class WordCounter
    {
        public static void CountWords(string s1, string s2)
        {
            int wordCount1 = CountWordsInSentence(s1);
            int wordCount2 = CountWordsInSentence(s2);

            Console.WriteLine("\n3. Количество слов:");
            Console.WriteLine($"В первом предложении: {wordCount1} слов");
            Console.WriteLine($"Во втором предложении: {wordCount2} слов");
        }

        private static int CountWordsInSentence(string sentence)
        {
            string cleaned = RemovePunctuation(sentence).Trim();

            if (string.IsNullOrEmpty(cleaned))
                return 0;

            string[] words = cleaned.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            return words.Length;
        }

        private static string RemovePunctuation(string input)
        {
            char[] buffer = new char[input.Length];
            int index = 0;

            foreach (char c in input)
            {
                if (!char.IsPunctuation(c))
                {
                    buffer[index] = c;
                    index++;
                }
            }

            return new string(buffer, 0, index).ToLower();
        }
    }
}
