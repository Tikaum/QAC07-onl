using BookStore.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Screens
{
    public class PurchaseHistoryScreen
    {
        private readonly IUser _user;

        public PurchaseHistoryScreen(IUser user)
        {
            _user = user;
        }

        public void Show()
        {
            Console.Clear();
            _user.ShowPurchaseHistory();
        }
    }
}