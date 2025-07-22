using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Books
{
    public interface IBook
    {
        string Title { get; }
        string Author { get; }
        string Genre { get; }
    }
}

