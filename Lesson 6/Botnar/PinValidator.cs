using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_6
{
    internal class PinValidator
    {
        private readonly BankAccount _account;
        private readonly string _pinToValidate;
        public PinValidator(BankAccount account, string pinToValidate)
        {
            _account = account;
            _pinToValidate = pinToValidate;
        }

        public bool IsValid()
        {
            return _pinToValidate == _account.pin;
        }
    }
}
