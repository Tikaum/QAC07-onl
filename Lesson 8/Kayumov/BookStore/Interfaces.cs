using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework8
{
    interface IBook
    {
        void ShowCardBook();        
    }

    interface IStore
    {
        void ShowAllBookNames();
        void FindBook();
        void ShowGenreBooks();
        void ShowMenu();
        void СhoiceBookInGenre();
    }

    interface IShoppingCart
    {
        void AddToBasket();
        void RemoveFromBasket();
        void ShowBasket();
        void BuyBook();

    }

}
