using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework8
{
    public class ShoppingCart : IShoppingCart
    {        
        public List<(int, string, string, double)> Basket = new List<(int, string, string, double)>(){ };
        public (int, string, string, double) AddBook = (0, "", "", 0);

        public void AddToBasket()
        {            
            Basket.Add(AddBook);
            AddBook = (0, "", "", 0);
            Console.WriteLine("Книга добавлена в корзину.");
            foreach(var books in Basket)
            {
                Console.WriteLine($"{books.Item2}. {books.Item4}");
            }
        }

        public void BuyBook()
        {
            throw new NotImplementedException();
        }

        public void RemoveFromBasket()
        {
            throw new NotImplementedException();
        }

        public void ShowBasket()
        {
            foreach (var books in Basket)
            {
                Console.WriteLine($"{books.Item2}. {books.Item4}");
            }
        }
    }
}
