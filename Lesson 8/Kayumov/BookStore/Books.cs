using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Reflection.Metadata.BlobBuilder;

namespace Homework8
{
    public class Books : IBook
    {
        public void ShowCardBook()          
        {
            Store instansStore = new Store();
            var allBooks = instansStore.allBooks;

            ShoppingCart instansShoppingCart = new ShoppingCart();
            List<(int, string, string, double)> Basket = new List<(int, string, string, double)>() { };
            

            Console.WriteLine("Введите номер книги");
            int choice = Convert.ToInt32(Console.ReadLine());

            var CardBook = allBooks.Where(book => book.Item1 == choice).ToList();
            
            if (CardBook.Count > 0)
            {                
                foreach (var books in CardBook)
                {
                    Console.WriteLine($"Название {books.Item2}. Жанр {books.Item3}. Цена {books.Item4}");
                }                

                Console.WriteLine("Добавить эту книгу в корзину?(y/n)");
                string AddOrNot = Console.ReadLine();
                
                if (AddOrNot == "y")
                {                    
                    instansShoppingCart.AddBook = CardBook[0];                    
                    instansShoppingCart.AddToBasket();
                }

                CardBook.Clear();
            }
            else 
            {
                Console.WriteLine("Такой книги нет в списке"); 
            }
        }
    }
}
