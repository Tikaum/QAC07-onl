using BookStore.Books;
using BookStore.Cart;
using BookStore.Screens;
using BookStore.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

public class ShopScreen
{
    private readonly IStore _store;
    private readonly IShoppingCart _cart;
    private readonly IUser _user;

    public ShopScreen(IStore store, IShoppingCart cart, IUser user)
    {
        _store = store;
        _cart = cart;
        _user = user;
    }

    public bool Show()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Книжный магазин");
            Console.WriteLine();
            Console.WriteLine("1. Просмотреть все книги");
            Console.WriteLine("2. Поиск по названию");
            Console.WriteLine("3. Фильтр по жанру");
            Console.WriteLine("4. Перейти в корзину");
            Console.WriteLine("5. История покупок");
            Console.WriteLine("6. Выйти");
            Console.Write("Выберите действие: ");

            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    ShowAllBooks();
                    break;
                case "2":
                    SearchByTitle();
                    break;
                case "3":
                    FilterByGenre();
                    break;
                case "4":
                    var cartScreen = new ShoppingCartScreen(_cart, _user);
                    cartScreen.Show();
                    return true;
                case "5":
                    var historyScreen = new PurchaseHistoryScreen(_user);
                    historyScreen.Show();
                    return true;
                case "6":
                    return false;
                default:
                    Console.WriteLine("Неверный ввод!");
                    Console.ReadKey();
                    break;
            }
        }
    }

    private void ShowAllBooks()
    {
        Console.Clear();
        var books = _store.GetAllBooks();
        DisplayBooks(books, true);
    }

    private void SearchByTitle()
    {
        Console.Clear();
        Console.Write("Введите название: ");
        string title = Console.ReadLine();
        var books = _store.FindBooksByTitle(title);
        DisplayBooks(books, true);
    }

    private void FilterByGenre()
    {
        Console.Clear();
        Console.Write("Введите жанр: ");
        string genre = Console.ReadLine();
        var books = _store.FindBooksByGenre(genre);
        DisplayBooks(books, true);
    }

    private void DisplayBooks(List<IBook> books, bool showAddOption = false)
    {
        if (books.Count == 0)
        {
            Console.WriteLine("Книги не найдены.");
        }
        else
        {
            for (int i = 0; i < books.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {books[i].Title} - {books[i].Author} ({books[i].Genre})");
            }

            if (showAddOption)
            {
                Console.WriteLine("\n0. Вернуться назад");
                Console.Write("Выберите книгу для добавления в корзину (или 0 для возврата): ");

                if (int.TryParse(Console.ReadLine(), out int choice) && choice > 0 && choice <= books.Count)
                {
                    _cart.AddToCart(books[choice - 1]);
                    Console.WriteLine($"Книга '{books[choice - 1].Title}' добавлена в корзину!");
                    Console.ReadKey();
                }
            }
        }

        if (!showAddOption)
        {
            Console.WriteLine("\nНажмите любую клавишу для продолжения...");
            Console.ReadKey();
        }
    }
}