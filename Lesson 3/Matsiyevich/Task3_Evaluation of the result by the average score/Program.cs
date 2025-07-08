namespace Task3_Evaluation_of_the_result_by_the_average_score
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int sum = 0;
            int subjects = 5;

            for (int i = 1; i <= subjects; i++)
            {
                Console.Write($"Введите оценку за предмет {i}: ");
                int grade = int.Parse(Console.ReadLine());

                while (grade < 0 || grade > 100)
                {
                    Console.Write("Оценка должна быть от 0 до 100. Повторите ввод: ");
                    grade = int.Parse(Console.ReadLine());
                }

                sum += grade;
            }

            double average = sum / (double)subjects;

            Console.WriteLine("Средний балл ученика: " + average);

            if (average >= 90)
            {
                Console.WriteLine("Отлично");
            }
            else if (average >= 75)
            {
                Console.WriteLine("Хорошо");
            }
            else if (average >= 60)
            {
                Console.WriteLine("Удовлетворительно");
            }
            else
            {
                Console.WriteLine("Неудовлетворительно");
            }
        }
    }
}
