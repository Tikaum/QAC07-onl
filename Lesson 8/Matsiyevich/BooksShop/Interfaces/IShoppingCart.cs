using BooksShop.Models;

namespace BooksShop.Interfaces
{
    public interface IShoppingCart
    {
        void AddToCart(Book book);
        void ViewCart();
        void Checkout(User user);
    }
}
