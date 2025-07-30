using BooksShop.Interfaces;

namespace BooksShop.Models
{
    public class ShoppingCart : IShoppingCart
    {
        private List<Book> cart = new List<Book>();

        public void AddToCart(Book book)
        {
            if (book != null)
            {
                cart.Add(book);
                Console.WriteLine($"Книга \"{book.Title}\" добавлена в корзину");
            }
        }

        public void ViewCart()
        {
            if (!cart.Any())
            {
                Console.WriteLine("Корзина пуста");
                return;
            }

            Console.WriteLine("Содержимое корзины:");
            foreach (var book in cart)
                book.ShowInfo();
        }

        public void Checkout(User user)
        {
            if (!cart.Any())
            {
                Console.WriteLine("Корзина пуста. Нет товаров для покупки");
                return;
            }

            user.PurchasedBooks.AddRange(cart);
            cart.Clear();
            Console.WriteLine("Покупка завершена");
        }
    }
}
