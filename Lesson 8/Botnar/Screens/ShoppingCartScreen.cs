using BookStore.Cart;
using BookStore.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Screens
{
    public class ShoppingCartScreen
    {
        private readonly IShoppingCart _cart;
        private readonly IUser _user;

        public ShoppingCartScreen(IShoppingCart cart, IUser user)
        {
            _cart = cart;
            _user = user;
        }

        public void Show()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Ваша корзина");
                Console.WriteLine();

                var books = _cart.GetAllBooks();
                if (books.Count == 0)
                {
                    Console.WriteLine("Корзина пуста.");
                }
                else
                {
                    foreach (var book in books)
                    {
                        Console.WriteLine($"- {book.Title} ({book.Author})");
                    }
                }

                Console.WriteLine("\n1. Оформить покупку");
                Console.WriteLine("2. Удалить книгу");
                Console.WriteLine("3. Очистить корзину");
                Console.WriteLine("4. Вернуться в магазин");
                Console.Write("Выберите действие: ");

                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        Buy();
                        return;
                    case "2":
                        RemoveBook();
                        break;
                    case "3":
                        _cart.RemoveAllBooks();
                        Console.WriteLine("Корзина очищена");
                        Console.ReadKey();
                        break;
                    case "4":
                        return;
                    default:
                        Console.WriteLine("Неверный ввод");
                        Console.ReadKey();
                        break;
                }
            }
        }

        private void Buy()
        {
            var books = _cart.GetAllBooks();
            foreach (var book in books)
            {
                _user.AddToPurchaseHistory(book);
            }
            _cart.BuyAllBooks();
            Console.WriteLine("Покупка совершена успешно");
            Console.ReadKey();
        }

        private void RemoveBook()
        {
            var books = _cart.GetAllBooks();
            if (books.Count == 0) return;

            Console.WriteLine("Введите номер книги для удаления:");
            for (int i = 0; i < books.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {books[i].Title}");
            }

            if (int.TryParse(Console.ReadLine(), out int index) && index > 0 && index <= books.Count)
            {
                _cart.RemoveFromCart(books[index - 1]);
                Console.WriteLine("Книга удалена из корзины");
            }
            else
            {
                Console.WriteLine("Неверный номер");
            }
            Console.ReadKey();
        }
    }
}
