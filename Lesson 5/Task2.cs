Console.WriteLine("Enter your sentence");
string sentence = Console.ReadLine();
char[] letters = sentence.ToCharArray();

char[] vowels_array = { 'a', 'e', 'i', 'o', 'u', 'y', 'а', 'у', 'о', 'ы', 'э', 'и', 'е', 'ё', 'ю', 'я' };

int vowels = 0;
int consonants = 0;
int digits = 0;
int spaces = 0;


for (int i = 0; i < letters.Length; i++)
{
    if (Char.IsLetter(letters[i]))
    {
        if (vowels_array.Contains(Char.ToLower(letters[i])))
        {
            vowels++;
        }
        else
        {
            consonants++;
        }
    }
    else if (letters[i] == ' ')
    {
        spaces++;
    }
    else if (Char.IsDigit(letters[i]))
    {
        digits = digits++;
    }
}
Console.WriteLine($"The number of vowels is {vowels}");
Console.WriteLine($"The number of consonants is {consonants}");
Console.WriteLine($"The number of spaces is {spaces}");
Console.WriteLine($"The number of digits is {digits}");
