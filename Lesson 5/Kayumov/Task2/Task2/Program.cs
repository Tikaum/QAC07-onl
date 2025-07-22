namespace Task2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Пользователь вводит строку на английском или русском (или в комбинации) языке.
            //Выведите в консоль количество: гласных, согласных, цифр, пробелов.

            Console.WriteLine("Enter your text:");
            string text = Console.ReadLine();

            int[] count = {0, 0, 0, 0};

            string vowels = "aeiouAEIOUаоуыэеёиюяАОУЫЭЕЁИЮЯ"; //это гласные
            
            foreach (char c in text)
            {
                if (char.IsLetter(c) && vowels.Contains(c))
                {
                    count[0]++;
                }

                if (char.IsLetter(c) && !vowels.Contains(c))
                {
                    count[1]++;
                }

                if (char.IsDigit(c))
                {
                    count[2]++;
                }

                if (c is ' ')
                {
                    count[3]++;
                }
            }

            Console.WriteLine($"Quantity of: vowels = {count[0]}, consonants = {count[1]}, numbers = {count[2]}, spaces = {count[3]}");
        }
    }
}
