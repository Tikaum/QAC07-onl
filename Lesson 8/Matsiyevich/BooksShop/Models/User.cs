namespace BooksShop.Models
{
    public class User
    {
        public string Name { get; }
        public int PinCode { get; }
        public List<Book> PurchasedBooks { get; }

        public User(string name, int pin)
        {
            Name = name;
            PinCode = pin;
            PurchasedBooks = new List<Book>();
        }

        public void ShowPurchaseHistory()
        {
            if (!PurchasedBooks.Any())
            {
                Console.WriteLine("Вы ещё ничего не купили");
                return;
            }

            Console.WriteLine("История покупок:");
            foreach (var book in PurchasedBooks)
                book.ShowInfo();
        }
    }
}
