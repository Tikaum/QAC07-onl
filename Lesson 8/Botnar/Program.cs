using BookStore.Auth;
using BookStore.Books;
using BookStore.Cart;
using BookStore.Screens;
using BookStore.User;

namespace BookStore
{
    internal class Program
    {
        static void Main()
        {
            var store = new Store();
            var cart = new ShoppingCart();
            var userManager = new UserManager();

            IUser? user = null;
            while (user == null)
            {
                var loginScreen = new LoginScreen(userManager);
                user = loginScreen.Show();
            }

            bool inShop = true;
            while (inShop)
            {
                var shopScreen = new ShopScreen(store, cart, user);
                inShop = shopScreen.Show();
            }
        }
    }
}