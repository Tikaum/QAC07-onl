namespace AutomatedTellerMachine;

class Program
{
    static void Main(string[] args)
    {
        BankAccount userBankAccount = new BankAccount();
        userBankAccount.ShowMenu(userBankAccount.BankAccountMenu);
        ChooseActionStep(userBankAccount);
    }
    static void ChooseActionStep(BankAccount userBankAccount)
    {
        int actionNumber;
        do
        {
            Console.WriteLine("Выберите номер операции для продолжения: ");
            int userInput = Convert.ToInt32(Console.ReadLine());
            actionNumber = userInput;

            if (actionNumber != 5)
            {
                switch (actionNumber)
                {
                    case 1:
                        userBankAccount.ShowBalance();
                        break;
                    case 2:
                        userBankAccount.PutMoney();
                        break;
                    case 3:
                        userBankAccount.WithdrawMoney();
                        break;
                    case 4:
                        userBankAccount.PrintAllOperationsHistory();
                        break;
                    default:
                        Console.WriteLine("Неизвестная операция: {0}", actionNumber);
                        break;
                }
            }
        } while (actionNumber != 5);
        Console.Write("Вы успешно вышли из приложения.");
    }
}