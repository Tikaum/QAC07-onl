using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        IStore store = new Store();
        IShoppingCart cart = new ShoppingCart();

        while (true)
        {
            Console.WriteLine("\nBook Store Menu:");
            Console.WriteLine("1. Show all books");
            Console.WriteLine("2. Search book by title");
            Console.WriteLine("3. Filter by genre");
            Console.WriteLine("4. View cart");
            Console.WriteLine("5. Checkout");
            Console.WriteLine("6. Exit");

            Console.Write("\nChoose an option (1–6): ");
            string? input = Console.ReadLine();
            Console.WriteLine();

            switch (input)
            {
                case "1":
                    store.ShowAllBooks();
                    break;

                case "2":
                    Console.Write("Enter title to search: ");
                    string? title = Console.ReadLine();
                    var results = store.SearchByTitle(title ?? "");
                    ShowAndAdd(results, cart);
                    break;

                case "3":
                    Console.Write("Enter genre to filter: ");
                    string? genre = Console.ReadLine();
                    var filtered = store.FilterByGenre(genre ?? "");
                    ShowAndAdd(filtered, cart);
                    break;

                case "4":
                    cart.ViewCart();
                    break;

                case "5":
                    cart.Checkout();
                    break;

                case "6":
                    Console.WriteLine("Exiting Book Store...");
                    return;

                default:
                    Console.WriteLine("❗ Invalid choice. Try again.");
                    break;
            }
        }
    }

    static void ShowAndAdd(List<IBook> books, IShoppingCart cart)
    {
        if (books.Count == 0)
        {
            Console.WriteLine("No books found.");
            return;
        }

        for (int i = 0; i < books.Count; i++)
        {
            Console.Write($"{i + 1}. ");
            books[i].Display();
        }

        Console.Write("Enter number to add to cart or press Enter to cancel: ");
        string? input = Console.ReadLine();
        if (int.TryParse(input, out int choice) && choice >= 1 && choice <= books.Count)
        {
            cart.AddToCart(books[choice - 1]);
        }
    }
}