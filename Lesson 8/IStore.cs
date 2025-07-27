using System.Collections.Generic;

public interface IStore
{
    void ShowAllBooks();
    List<IBook> SearchByTitle(string title);
    List<IBook> FilterByGenre(string genre);
}