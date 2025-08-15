using Homework8;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Interfaces
{
    internal interface IShoppingCart
    {
        public void AddToBasket(int BookIDFromAddToBasket);

        public double Payment();

    }
}
