using Homework8;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Interfaces
{
    internal interface IStore
    {        
        public void InitialBookList();        
        public Book FindBookById(int id);
        public List<Book> SearchBooksByName(string searchQuery);
        public List<Book> SearchBooksByGenre(int searchQuery);
    }
}
