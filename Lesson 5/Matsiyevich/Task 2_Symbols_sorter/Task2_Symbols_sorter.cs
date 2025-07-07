using System.ComponentModel.Design;

namespace Task_2_Symbols_sorter
{
    internal class Task2_Symbols_sorter
    {
        static void Main(string[] args)
        {
            string werbs = Console.ReadLine();
            Console.WriteLine(werbs);

            var vowels = "aeiouAEIOUаеёиоуыэюяАЕЁИОУЫЭЮЯ";
            var consonants = "bcdfghjklmnpqrstvwxyzбвгджзйклмнпрстфхцчшщBCDFGHJKLMNPQRSTVWXYZБВГДЖЗЙКЛМНПРСТФХЦЧШЩ";

            int digit = 0;
            int space = 0;
            int vowel = 0;
            int consonant = 0;


            foreach (char simbol in werbs)
            {
                if (char.IsDigit(simbol))
                {
                    digit++;
                }
                else if (char.IsWhiteSpace(simbol))
                {
                    space++;
                }
                else if (vowels.Contains(simbol))
                { 
                    vowel++; 
                }
                else if (consonants.Contains(simbol))
                {
                    consonant++;
                }
            }
            Console.WriteLine($"Digits: {digit}");
            Console.WriteLine($"Spaces: {space}");
            Console.WriteLine($"Vowels: {vowel}");
            Console.WriteLine($"Consonants: {consonant}");           
            
        }
    }
}
