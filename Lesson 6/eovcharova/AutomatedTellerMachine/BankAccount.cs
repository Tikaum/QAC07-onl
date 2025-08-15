namespace AutomatedTellerMachine;

public class BankAccount
{
    private int balance;
    private static Random rnd = new Random();
    public BankAccount()
    {
        balance = rnd.Next(10000, 100000);
    }
    private List<string> transactionHistory = new List<string>();
    private string[] bankAccountMenu = new[] 
        { 
            "1. Посмотреть баланс.", 
            "2. Положить деньги.", 
            "3. Снять деньги.", 
            "4. История операций.", 
            "5. Выйти." 
        };
    public int Balance
    {
        get => balance;
        private set => balance = value;
        
    }
    public List<string> TransactionHistory { get => transactionHistory; set => transactionHistory = value; }
    public string[] BankAccountMenu { get => bankAccountMenu; set => bankAccountMenu = value; }
    public void ShowMenu(string[] menu)
    {
        int menuIndex = 0;
        while (menuIndex < menu.Length)
        {
            // вывод конкретного элемента
            Console.WriteLine(menu[menuIndex]);
            menuIndex++;
        }
    }
    public void ShowBalance()
    {
        Console.WriteLine($"Ваш текущий баланс: {Balance}");
    } 
    public void PutMoney()
    {
        Console.WriteLine("Ввведите пожалуйста сумму, которую хотите положить");
        int moneyToAdd = Convert.ToInt32(Console.ReadLine());
        Balance += moneyToAdd;
        ShowBalance();
        SaveTransactionPutMoneyHistory();
    }
    public void WithdrawMoney()
    {
        Console.WriteLine("Ввведите пожалуйста сумму, которую хотите снять");
        int moneyToWithdraw = Convert.ToInt32(Console.ReadLine());
        if (moneyToWithdraw <= Balance)
        {
            Balance -= moneyToWithdraw; 
            SaveTransactionWithdrawHistory();
            ShowBalance();
        }
        else
        {
            Console.WriteLine("Недостаточно средст для снятия.");
            ShowBalance();
        }
    }
    public void SaveTransactionWithdrawHistory()
    {
        string operationWithdraw = "Снятие наличных, ";
        DateTime currentDate = DateTime.Now;
        string operationHistoryWithdraw = operationWithdraw + "ваш баланс: " + Balance + ", дата операции: " + currentDate;
        TransactionHistory.Add(operationHistoryWithdraw);
    }
    public void SaveTransactionPutMoneyHistory()
    {
        string operationPutMoney = "Пополнение баланса, ";
        DateTime currentDate = DateTime.Now;
        string operationHistoryPutMoney = operationPutMoney + "ваш баланс: " + Balance + ", дата операции: " + currentDate;
        TransactionHistory.Add(operationHistoryPutMoney);
        
    }
    public void PrintAllOperationsHistory()
    {
        if (TransactionHistory.Count == 0)
        {
            Console.WriteLine("История операций пуста.");
            return;
        }
        foreach (var operation in TransactionHistory)
        {
            Console.WriteLine(operation);
        }
    }
}