using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_5
{
    internal class CommonWordsFinder
    {
        public static void FindCommonWords(string s1, string s2)
        {
                string[] words1 = GetWords(s1);
                string[] words2 = GetWords(s2);

                int commonCount = 0;

                foreach (string word1 in words1)
                {
                    foreach (string word2 in words2)
                    {
                        if (string.Equals(word1, word2, StringComparison.OrdinalIgnoreCase))
                        {
                            commonCount++;
                            break;
                        }
                    }
                }

                Console.WriteLine("\n4. Общие слова:");
                Console.WriteLine($"Количество одинаковых слов: {commonCount}");
        }
        static string[] GetWords(string sentence)
        {
            string cleaned = RemovePunctuation(sentence).Trim();
            if (string.IsNullOrEmpty(cleaned))
                return new string[0];

            return cleaned.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        }

        static string RemovePunctuation(string input)
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
