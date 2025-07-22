namespace Task1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //1) Пользователь вводит строку, содержащую несколько слов, разделённых пробелами. Найти и вывести в консоль самое длинное слово.

            Console.WriteLine("Enter your text:");
            string text = Console.ReadLine();

            string[] words = text.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            int maxWordLength = 0;
            int indexMaxWord = 0;

            for (int i = 0; i < words.Length; i++)
            {
                if (words[i].Length > maxWordLength)
                {
                    maxWordLength = words[i].Length;
                    indexMaxWord = i;
                }
            }

            Console.WriteLine($"The longest word is <{words[indexMaxWord]}>");
        }
    }
}
