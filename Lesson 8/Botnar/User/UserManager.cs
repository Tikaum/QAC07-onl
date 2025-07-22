using BookStore.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Auth
{
    public class UserManager
    {
        private readonly List<IUser> _users = new List<IUser>();

        public UserManager()
        {
            _users.Add(new BookStore.User.User("Саша", "1234"));
            _users.Add(new BookStore.User.User("Таня", "5678"));
        }

        public IUser? Authenticate(string name, string pin)
        {
            return _users.FirstOrDefault(u => u.Name == name && u.IsPinValid(pin));
        }
    }
}
