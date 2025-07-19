using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp8
{
    interface IBook
    {
        void ShowBook();        
    }

    interface IStore
    {
        void ShowAllBookNames();
        void FindBook();
        void ShowGenreBooks();
        void ShowMenu();
        void chooseBchooseBookInCatalogook();
    }

    interface IShoppingCart
    {
        void AddToBasket();
        void RemoveFromBasket();

        void ShowBasket();
        void BuyBook();

    }

}
