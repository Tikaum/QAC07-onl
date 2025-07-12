using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_6
{
    public class BankAccount
    {
        private int _balance;
        private string _pin;
        private List<string> _transactionLogs = new List<string>();

        public BankAccount()
        {
            _balance = 0;
            _pin = "0000";
        }

        public BankAccount(string pin)
        {
            _pin = pin;
        }

        public string pin
        {
            get { return _pin; }
            set
            {
                if (value?.Length == 4 && value.All(char.IsDigit))
                    _pin = value;
                else
                    throw new ArgumentException("PIN должен быть 4 цифры");
            }
        }

        public bool Deposit(int amount)
        {
            if (amount <= 0)
                return false;

            _balance += amount;
            _transactionLogs.Add($"[{DateTime.Now}] Пополнение: +{amount}р. Остаток на счёте: {_balance}р.");
            return true;
        }

        public bool Withdraw(int amount)
        {
            if (amount <= 0 || amount > _balance)
                return false;

            _balance -= amount;
            _transactionLogs.Add($"[{DateTime.Now}] Снятие: -{amount}р. Остаток на счёте: {_balance}р.");
            return true;
        }

        public int GetBalance()
        {
            return _balance;
        }

        public List<string> GetHistory()
        {
            return new List<string>(_transactionLogs);
        }
    }
}
