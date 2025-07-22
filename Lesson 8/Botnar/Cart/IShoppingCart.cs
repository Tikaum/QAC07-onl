using BookStore.Books;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Cart
{
    public interface IShoppingCart
    {
        void AddToCart(IBook Book);
        void RemoveFromCart(IBook Book);
        List<IBook> GetAllBooks();
        void RemoveAllBooks();
        void BuyAllBooks();

    }
}
