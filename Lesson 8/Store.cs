using System;
using System.Collections.Generic;
using System.Linq;

public class Store : IStore
{
    private List<IBook> books;

    public Store()
    {
        books = new List<IBook>
{
    new Book("The Master and Margarita", "Mikhail Bulgakov", "Classics", 18.50m),
    new Book("The Adventures of Dunno", "Nikolay Nosov", "Children", 12.00m),
    new Book("Music: The Art of Listening", "Dmitry Ukhov", "Music", 22.00m),
    new Book("Twilight", "Stephenie Meyer", "Fantasy", 14.50m)
};
    }

    public void ShowAllBooks()
    {
        Console.WriteLine("\nAvailable Books:");
        foreach (var book in books)
            book.Display();
    }

    public List<IBook> SearchByTitle(string title)
    {
        return books.Where(b => b.Title.Contains(title, StringComparison.OrdinalIgnoreCase)).ToList();
    }

    public List<IBook> FilterByGenre(string genre)
    {
        return books.Where(b => b.Genre.Equals(genre, StringComparison.OrdinalIgnoreCase)).ToList();
    }
}