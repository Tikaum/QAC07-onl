using BooksShop.Models;
using System.Collections.Generic;

namespace BooksShop.Interfaces
{
    public interface IStore
    {
        void ShowAllBooks();
        List<Book> SearchBooks(string title);
        List<Book> FilterByGenre(string genre);
        Book GetBookByExactTitle(string title);
    }
}
