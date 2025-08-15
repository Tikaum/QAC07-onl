using BookStore.Books;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.User
{
    public interface IUser
    {
        string Name { get; }
        bool IsPinValid(string pin);
        void AddToPurchaseHistory(IBook book);
        List<IBook> GetPurchaseHistory();
        void ShowPurchaseHistory();
    }
}
