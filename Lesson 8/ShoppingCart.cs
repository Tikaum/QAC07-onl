using System;
using System.Collections.Generic;
using System.Linq;

public class ShoppingCart : IShoppingCart
{
    private List<IBook> cart = new();

    public void AddToCart(IBook book)
    {
        cart.Add(book);
        Console.WriteLine($"\"{book.Title}\" added to your cart.");
    }

    public void ViewCart()
    {
        Console.WriteLine("\nYour Shopping Cart:");
        if (cart.Count == 0)
        {
            Console.WriteLine("Cart is empty.");
            return;
        }

        foreach (var book in cart)
            book.Display();
    }

    public void Checkout()
    {
        if (cart.Count == 0)
        {
            Console.WriteLine("Cart is empty. Nothing to purchase.");
            return;
        }

        decimal total = cart.Sum(b => b.Price);
        cart.Clear();
        Console.WriteLine($"Purchase successful! Total: ${total:F2}");
    }
}