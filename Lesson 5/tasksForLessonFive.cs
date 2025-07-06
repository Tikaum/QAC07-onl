using System;

namespace tasksForLessonFive
{
    class Program
    {
        static void Main()
        {
            // Task 1: Find the longest word 

            /*Console.WriteLine("Enter a sentence with several words:");
            string input = Console.ReadLine();
            string[] words = input.Split(' ');
            string longestWord = "";
            int maxLength = 0;

            for (int i = 0; i < words.Length; i++)
            {
                if (words[i].Length > maxLength)
                {
                    maxLength = words[i].Length;
                    longestWord = words[i];
                }
            }
            Console.WriteLine("The longest word is: " + longestWord);
            Console.WriteLine();
            */
            // Task 2: Count vowels, consonants, digits, spaces

            Console.WriteLine("Enter a string:");
string text = Console.ReadLine();

int vowels = 0;
int consonants = 0;
int digits = 0;
int spaces = 0;
for (int i = 0; i < text.Length; i++)
{
    char c = char.ToLower(text[i]);

    if (c == 'a' || c == 'e' || c == 'i' || c == 'o' || c == 'u')
    {
        vowels++;
    }
    else if (c >= 'a' && c <= 'z')
    {
        consonants++;
    }
    else if (c >= '0' && c <= '9')
    {
        digits++;
    }
    else if (c == ' ')
    {
        spaces++;
    }
}
Console.WriteLine("Vowels: " + vowels);
Console.WriteLine("Consonants: " + consonants);
Console.WriteLine("Digits: " + digits);
Console.WriteLine("Spaces: " + spaces);
}
}
}
