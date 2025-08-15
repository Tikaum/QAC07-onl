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

    public void Display()
    {
        Console.WriteLine($"{Title} by {Author} — {Genre} — ${Price:F2}");
    }
}