using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_6
{
    public class PinValidator
    {
        private string _pinToValidate;
        private string _correctPin;
        public PinValidator(string pinToValidate)
        {
            _correctPin = "1234";
            _pinToValidate = pinToValidate;
        }

        public bool IsValid()
        {
                return _pinToValidate == _correctPin;
        }
    }
}
