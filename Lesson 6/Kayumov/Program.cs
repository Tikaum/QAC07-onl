using System;
using System.Threading;
using static System.Collections.Specialized.BitVector32;

namespace lesson6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BankAccount user1 = new BankAccount();
            
            int action = 0;

            while (action != 5)
            { 
                user1.ShowMenu();
                
                action = Convert.ToInt32(Console.ReadLine());

                switch (action)
                {
                    case 1:
                        user1.ShowBalance();
                        continue;

                    case 2:
                        user1.Deposit();
                        break;

                    case 3:
                        user1.Withdraw();
                        break;

                    case 4:
                        user1.PrintHistory();
                        break;

                    case 5:
                        Console.WriteLine("Goodbye!");
                        break;

                    default:
                        Console.WriteLine("Select an action and enter the correct аction number");
                        Console.WriteLine();
                        break;
                }
            }
        }
    }       
}
