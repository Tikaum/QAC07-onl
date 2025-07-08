namespace Task1_deposite_calc
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Можно вводить любые значения, но чтобы программа соответствовала ДЗ, пожалуйста введите 10 для процентов и 3 для лет пользования депозита");
            Console.WriteLine("Enter precents: ");

            string percentEntered = Console.ReadLine();
            double percents = Convert.ToInt32(percentEntered);
            double percentsByDeposit = percents / 100;

            Console.WriteLine($"Your annual interest on deposit: {percents}%");

            Console.WriteLine("Enter deposit: ");

            string depositEntered = Console.ReadLine();
            double deposit = Convert.ToInt32(depositEntered);

            Console.WriteLine($"Your deposit: {deposit}");
            
            
            Console.WriteLine("Enter years: ");

            int years;

            while (!int.TryParse(Console.ReadLine(), out years) || years <= 0)
            {
                Console.Write("Enter positive Integer: ");
            }

            for (int i = 1; i <= years; i++)
            {
                deposit += percentsByDeposit * deposit;
                Console.WriteLine($"{i}. Your profit will be {deposit}");
            }
            Console.WriteLine($"After {years} years your deposit will increase to {deposit}");
        }    
    }
}
