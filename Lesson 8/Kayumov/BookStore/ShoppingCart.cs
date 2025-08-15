using BookStore.Interfaces;
using Homework8;

namespace BookStore
{
    public class ShoppingCart : IShoppingCart
    {

        public List<Book> _booksInBasket;

        public Store _store;        

        public ShoppingCart (Store store)
        {
            _booksInBasket = new List<Book>();
            _store = store;
        }

        public double TotalSum { get; internal set; }

        public void AddToBasket(int BookIDFromAddToBasket)
        {
             Book book = _store.FindBookById(BookIDFromAddToBasket);
            _booksInBasket.Add(book);
        }

        public double Payment()
        {            
            foreach (Book book in _booksInBasket)
            {
                TotalSum = TotalSum + book.Price;
            }
            return TotalSum;
           
        }

    }
}
