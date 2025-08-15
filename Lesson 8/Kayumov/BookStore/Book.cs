using BookStore.Interfaces;

namespace Homework8
{
    public class Book : IBook
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Genre { get; set; }
        public double Price { get; set; }

        public Book(int id, string name, string genre, double price)
        {
            Id = id;
            Name = name;
            Genre = genre;
            Price = price;
        }

        public void GetInfoAboutBook()
        {
            Console.WriteLine($"Книга №{Id}. Жанр:{Genre}, название: {Name}, цена: {Price} руб.");
        }
    }
}
