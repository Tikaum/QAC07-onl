using BookStore.Books;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.User
{
    public class User : IUser
    {
        public string Name { get; }
        private string Pin { get; }
        private List<IBook> _purchaseHistory = new List<IBook>();

        public User(string name, string pin)
        {
            Name = name;
            Pin = pin;
        }

        public bool IsPinValid(string pin) => Pin == pin;

        public void AddToPurchaseHistory(IBook book)
        {
            _purchaseHistory.Add(book);
        }

        public List<IBook> GetPurchaseHistory() => new List<IBook>(_purchaseHistory);

        public void ShowPurchaseHistory()
        {
            Console.WriteLine("\nИстория покупок:");
            Console.WriteLine("=================");

            if (_purchaseHistory.Count == 0)
            {
                Console.WriteLine("Пока ничего не куплено.");
                return;
            }

            foreach (var book in _purchaseHistory)
            {
                Console.WriteLine($"- {book.Title} ({book.Author}, {book.Genre})");
            }

            Console.WriteLine("\nНажмите любую клавишу для продолжения...");
            Console.ReadKey();
        }
    }
}