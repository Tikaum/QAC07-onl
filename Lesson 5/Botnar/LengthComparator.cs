using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_5
{
    public static class LengthComparator
    {
        public static void CompareLength(string s1, string s2)
        {
            int len1 = s1.Length;
            int len2 = s2.Length;

            Console.WriteLine($"\n1. Сравнение длины:");
            Console.WriteLine($"Первое предложение: {len1} символов");
            Console.WriteLine($"Второе предложение: {len2} символов");

            if (len1 > len2)
                Console.WriteLine("Первое предложение длиннее.");
            else if (len2 > len1)
                Console.WriteLine("Второе предложение длиннее.");
            else
                Console.WriteLine("Предложения одинаковой длины.");
        }
    }
}
