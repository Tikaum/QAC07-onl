using BooksShop.Interfaces;


namespace BooksShop.Models
{
    public class Store : IStore
    {
        private List<Book> books;

        public Store()
        {
            books = new List<Book>
            {
                new Book("Властелин колец", "Дж. Р. Р. Толкин", "Fantasy", 9.99m),
                new Book("1984", "Джордж Оруэлл", "Dystopian", 8.49m),
                new Book("Чистый код", "Роберт Мартин", "Non-fiction", 25.00m),
                new Book("Гарри Поттер", "Дж. К. Роулинг", "Fantasy", 12.99m),
                new Book("Sapiens", "Юваль Ной Харари", "Non-fiction", 18.00m)
            };
        }

        public void ShowAllBooks()
        {
            Console.WriteLine("Список доступных книг:");
            foreach (var book in books)
                book.ShowInfo();
        }

        public List<Book> SearchBooks(string title)
        {
            List<Book> result = new List<Book>();

            foreach (Book book in books)
            {
                if (book.Title.IndexOf(title, StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    result.Add(book);
                }
            }

            return result;
        }

        public List<Book> FilterByGenre(string genre)
        {
            List<Book> result = new List<Book>();

            foreach (Book book in books)
            {
                if (string.Equals(book.Genre, genre, StringComparison.OrdinalIgnoreCase))
                {
                    result.Add(book);
                }
            }

            return result;
        }

        public Book GetBookByExactTitle(string title)
        {

            foreach (var book in books)
            {
                if (string.Equals(book.Title, title, StringComparison.OrdinalIgnoreCase))
                {
                    return book;
                }
            }
            return null;
        }
    }
}
