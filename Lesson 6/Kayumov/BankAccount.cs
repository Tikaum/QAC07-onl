using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lesson6
{
    public class BankAccount
    {
        public double balance = 0;
        public double enteredByUser = 0;

        public void ShowMenu()
        {
            string[] menuItem = {"Welcome to ATM!",
                "Select an action and enter the аction number",
                "1. View balance",
                "2. Deposit money",
                "3. Withdraw money",
                "4. Transaction history",
                "5. Exit" ,
                ""};

            for (int i = 0; i < menuItem.Length; i++)
            {
                string action = menuItem[i];
                Console.WriteLine(action);
                Thread.Sleep(100);
            }
        }

        public void Deposit()
        {
            Console.Write("Please indicate the amount to be deposited: ");
            enteredByUser = double.Parse(Console.ReadLine());
            Console.WriteLine("Successfully!");
            Console.WriteLine();
            balance = balance + enteredByUser;
            string recordToDeposit = $"{enteredByUser} dollar(s), account replenishment, {DateTime.Now}";
            transactionHistory.Add(recordToDeposit);
            enteredByUser = 0;
        }
        public void Withdraw()
        {
            Console.Write("Specify the amount to be withdrawn: ");
            enteredByUser = double.Parse(Console.ReadLine());
            if (enteredByUser > balance)
            {
                Console.WriteLine("You want to withdraw more than you have in your account.\nPlease repeat the withdrawal and enter an amount equal to or less.");
                Console.WriteLine();
                enteredByUser = 0;
            }
            else
            {
                string recordToDeposit = $"{enteredByUser} dollar(s), withdrawal from account, {DateTime.Now}";
                transactionHistory.Add(recordToDeposit);
                Console.WriteLine("Successfully!");
                Console.WriteLine();
                balance = balance - enteredByUser;
                enteredByUser = 0;
            }
        }
        public void ShowBalance()
        {
            Console.WriteLine($"Your balance is {balance,0:F2} dollars");
            Console.WriteLine();
        }

        public List<string> transactionHistory = new List<string>() { "Your transactions are recorded here:" };
        public void PrintHistory()
        {
            foreach (var record in transactionHistory)
            {
                Console.WriteLine(record);
            }
            Console.WriteLine();
        }
    }
}
