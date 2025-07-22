using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_5
{
    public static class SymbolChecker
    {
        private static char[] vovels =
        {
            'a', 'e', 'i', 'o', 'u', 'y',
            'а', 'е', 'ё', 'и', 'о', 'у', 'ы', 'э', 'ю', 'я'
        };
        private static char[] consontants =
        {
            'b', 'c', 'd', 'f', 'g', 'h', 'j', 'k', 'l', 'm', 'n', 'p', 'q', 'r', 's', 't', 'v', 'w', 'x', 'z',
            'б', 'в', 'г', 'д', 'ж', 'з', 'к', 'л', 'м', 'н', 'п', 'р', 'с', 'т', 'ф', 'х', 'ц', 'ч', 'ш', 'щ'
        };

        public static string GetSymbolType(char symbol)
        {
            if (vovels.Contains(symbol))
                return "vovel";
            else if (consontants.Contains(symbol))
                return "consontant";
            else if (char.IsDigit(symbol))
                return "digit";
            else if (char.IsWhiteSpace(symbol))
                return "space";
            else 
                return "other";
        }
    }
}
