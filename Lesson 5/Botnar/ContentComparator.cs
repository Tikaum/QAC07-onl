using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_5
{
    public static class ContentComparator
    {
        public static void CompareContent(string s1, string s2)
        {
            {
            bool areEqual = string.Equals(s1, s2, StringComparison.OrdinalIgnoreCase);

            Console.WriteLine("\n2. Сравнение содержания:");
            Console.WriteLine(areEqual ? "Предложения одинаковы по содержанию.\n"
                                        : "Предложения различаются по содержанию.\n");
            }
        }
    }
}
