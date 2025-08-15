using BooksShop.Interfaces;

namespace BooksShop
{
    public class Book : IBook
    {
        public string Title { get; }
        public string Author { get; }
        public string Genre { get; }
        public decimal Price { get; }

        public Book(string title, string author, string genre, decimal price)
        {
            Title = title;
            Author = author;
            Genre = genre;
            Price = price;
        }

        public void ShowInfo()
        {
            Console.WriteLine($"{Title} — {Author} | Жанр: {Genre} | Цена: {Price} руб.");
        }
    }
}
