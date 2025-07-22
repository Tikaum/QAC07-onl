using BookStore.Auth;
using BookStore.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Screens
{
    public class LoginScreen
    {
        private readonly UserManager _userManager;

        public LoginScreen(UserManager userManager)
        {
            _userManager = userManager;
        }

        public IUser? Show()
        {
            Console.Clear();
            Console.WriteLine("Книжный магазин");
            Console.WriteLine();
            Console.WriteLine("Вход в систему");

            Console.Write("Введите имя: ");
            string name = Console.ReadLine()?.Trim() ?? string.Empty;

            Console.Write("Введите PIN (4 цифры): ");
            string pin = PinReader.GetPin();

            var user = _userManager.Authenticate(name, pin);
            if (user == null)
            {
                Console.WriteLine("Ошибка: Неверное имя или PIN.");
                Console.ReadKey();
            }

            return user;
        }
    }
}