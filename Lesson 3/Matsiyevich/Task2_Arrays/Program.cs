namespace Arrays
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = { 3, 7, 4, 2, 8, 1, 5, 6, 9, 10 };
            int sum = 0;
            int positiveNums = 0;
            for (int i = 0; i <= numbers.Length; i++)
            {
                if (i % 2 == 0)
                {
                    sum += i;
                }
                else
                {
                    positiveNums++;
                }
            }
            Console.WriteLine($"Сумма чётных чисел: {sum}");
            Console.WriteLine($"Количество нечётных чисел: {positiveNums}");
        }
    }
}
