class BankAccount
{
    private decimal balance;
    private List<string> transactionHistory;

    public BankAccount()
    {
        balance = 0;
        transactionHistory = new List<string>();
    }

    public void Deposit(decimal amount)
    {
        if (amount <= 0)
        {
            Console.WriteLine("Сумма должна быть положительной.");
            return;
        }
        balance += amount;
        string record = $"{DateTime.Now}: Пополнение +{amount} руб. Баланс: {balance} руб.";
        transactionHistory.Add(record);
        Console.WriteLine("Деньги успешно внесены.");
    }

    public void Withdraw(decimal amount)
    {
        if (amount <= 0)
        {
            Console.WriteLine("Сумма должна быть положительной.");
            return;
        }
        if (amount > balance)
        {
            Console.WriteLine("Недостаточно средств!");
            string record = $"{DateTime.Now}: Неудачная попытка снятия {amount} руб. Баланс: {balance} руб.";
            transactionHistory.Add(record);
        }
        else
        {
            balance -= amount;
            string record = $"{DateTime.Now}: Снятие -{amount} руб. Баланс: {balance} руб.";
            transactionHistory.Add(record);
            Console.WriteLine("Деньги успешно сняты.");
        }
    }

    public void ShowBalance()
    {
        Console.WriteLine($"Ваш текущий баланс: {balance} руб.");
    }

    public void PrintHistory()
    {
        if (transactionHistory.Count == 0)
        {
            Console.WriteLine("История операций пуста.");
            return;
        }
        Console.WriteLine("История операций:");
        foreach (var record in transactionHistory)
        {
            Console.WriteLine(record);
        }
    }

    public void ShowMenu()
    {
        Console.WriteLine("Добро пожаловать в Банкомат!");
        Console.WriteLine("Выберите действие:");
        Console.WriteLine("1. Посмотреть баланс");
        Console.WriteLine("2. Положить деньги");
        Console.WriteLine("3. Снять деньги");
        Console.WriteLine("4. История операций");
        Console.WriteLine("5. Выйти");
    }
}

class Program
{
    static void Main(string[] args)
    {
        BankAccount account = new BankAccount();
        bool running = true;

        while (running)
        {
            account.ShowMenu();
            string input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    account.ShowBalance();
                    break;
                case "2":
                    Console.Write("Введите сумму: ");
                    if (decimal.TryParse(Console.ReadLine(), out decimal depositAmount))
                        account.Deposit(depositAmount);
                    else
                        Console.WriteLine("Попробуйте ещё раз");
                    break;
                case "3":
                    Console.Write("Введите сумму: ");
                    if (decimal.TryParse(Console.ReadLine(), out decimal withdrawAmount))
                        account.Withdraw(withdrawAmount);
                    else
                        Console.WriteLine("Попробуйте ещё раз");
                    break;
                case "4":
                    account.PrintHistory();
                    break;
                case "5":
                    running = false;
                    break;
                default:
                    Console.WriteLine("Попробуйте снова");
                    break;
            }
        }
    }
}
