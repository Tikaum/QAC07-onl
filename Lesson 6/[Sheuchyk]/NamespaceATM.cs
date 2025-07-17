using System;
using System.Collections.Generic;

namespace ATM
{
    class BankAccount
    {
        private decimal balance;
        private List<string> transactionHistory;
        public BankAccount()
        {
            balance = 0;
            transactionHistory = new List<string>();
        }
        public void ShowMenu()
        {
            Console.WriteLine("Welcome to the ATM!");
            Console.WriteLine("Please choose an option:");
            Console.WriteLine("1. View Balance");
            Console.WriteLine("2. Deposit Money");
            Console.WriteLine("3. Withdraw Money");
            Console.WriteLine("4. Transaction History");
            Console.WriteLine("5. Exit");
        }
        public void ShowBalance()
        {
            Console.WriteLine($"Current balance: {balance}  BEL RUB");
        }
        public void Deposit(decimal amount)
        {
            if (amount <= 0)
            {
                Console.WriteLine("Amount must be greater than 0.");
                return;
            }

            balance += amount;
            string record = $"{DateTime.Now}: Deposit +{amount} RUB";
            transactionHistory.Add(record);
            Console.WriteLine("Deposit successful.");
        }
        public void Withdraw(decimal amount)
        {
            if (amount <= 0)
            {
                Console.WriteLine("Amount must be greater than 0.");
                return;
            }

            if (amount > balance)
            {
                Console.WriteLine("Insufficient funds.");
                return;
            }

            balance -= amount;
            string record = $"{DateTime.Now}: Withdrawal -{amount} RUB";
            transactionHistory.Add(record);
            Console.WriteLine("Withdrawal successful.");
        }
        public void PrintHistory()
        {
            Console.WriteLine("\nTransaction History:");
            if (transactionHistory.Count == 0)
            {
                Console.WriteLine("No transactions found.");
                return;
            }
            foreach (string entry in transactionHistory)
            {
                Console.WriteLine(entry);
            }
        }
    }
    class Program
    {
        static void Main()
        {
            BankAccount account = new BankAccount();
            bool running = true;

            while (running)
            {
                account.ShowMenu();
                Console.Write("\nEnter your choice: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        account.ShowBalance();
                        break;

                    case "2":
                        Console.Write("Enter amount to deposit: ");
                        if (decimal.TryParse(Console.ReadLine(), out decimal depositAmount))
                        {
                            account.Deposit(depositAmount);
                        }
                        else
                        {
                            Console.WriteLine("Invalid input.");
                        }
                        break;

                    case "3":
                        Console.Write("Enter amount to withdraw: ");
                        if (decimal.TryParse(Console.ReadLine(), out decimal withdrawAmount))
                        {
                            account.Withdraw(withdrawAmount);
                        }
                        else
                        {
                            Console.WriteLine("Invalid input.");
                        }
                        break;

                    case "4":
                        account.PrintHistory();
                        break;

                    case "5":
                        Console.WriteLine("Thank you for using the ATM. Have a good day!");
                        running = false;
                        break;

                    default:
                        Console.WriteLine("Invalid selection. Please try again.");
                        break;
                }
            }
        }
    }
}
