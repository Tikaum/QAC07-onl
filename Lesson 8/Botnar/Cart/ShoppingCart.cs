using BookStore.Books;
using BookStore.Cart;
using BookStore.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Cart
{
    public class ShoppingCart : IShoppingCart
    {
        private readonly List<IBook> _items = new List<IBook>();

        public void AddToCart(IBook book)
        {
            _items.Add(book);
        }

        public void RemoveFromCart(IBook book)
        {
            _items.Remove(book);
        }

        public List<IBook> GetAllBooks()
        {
            return _items.ToList();
        }

        public void RemoveAllBooks()
        {
            _items.Clear();
        }

        public void BuyAllBooks()
        {
            _items.Clear();
        }
    }
}