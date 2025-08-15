using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Books
{
    public interface IStore
    {
        List<IBook> GetAllBooks();
        List<IBook> FindBooksByTitle(string title);
        List<IBook> FindBooksByGenre(string genre);
        List<IBook> FindBooksByAuthor(string author);
    }
}
