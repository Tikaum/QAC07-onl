Console.WriteLine("Enter your sentence");
string sentence = Console.ReadLine();
string[] words = sentence.Split();

int length = 0;

string max = "";

for (int i = 0; i < words.Length; i++)
{
    if (words[i].Length > length)
    {
        length = words[i].Length;
        max = words[i];
    }
}
Console.WriteLine($"The longest word is {max}");