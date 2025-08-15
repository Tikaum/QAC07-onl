using BooksShop.Models;

namespace BooksShop
{
    internal class Program
    {

        static List<User> users = new List<User>
        {
            new User("Алиса", 1111),
            new User("Боб", 2222)
        };
        static void Main(string[] args)
        {
            Console.WriteLine("Добро пожаловать в книжный магазин!");
            User currentUser = AuthorizeUser();

            var store = new Store();
            var cart = new ShoppingCart();

            while (true)
            {
                Console.WriteLine("\nГлавное меню:");
                Console.WriteLine("1. Показать все книги");
                Console.WriteLine("2. Поиск книги по названию");
                Console.WriteLine("3. Фильтрация книг по жанру");
                Console.WriteLine("4. Добавить книгу в корзину");
                Console.WriteLine("5. Просмотреть корзину");
                Console.WriteLine("6. Совершить покупку");
                Console.WriteLine("7. История покупок");
                Console.WriteLine("8. Выход");
                Console.Write("Выберите пункт меню: ");

                string input = Console.ReadLine();
                Console.WriteLine();

                switch (input)
                {
                    case "1":
                        store.ShowAllBooks();
                        break;
                    case "2":
                        Console.Write("Введите название книги для поиска: ");
                        var search = Console.ReadLine();
                        var foundBooks = store.SearchBooks(search);
                        if (!foundBooks.Any())
                            Console.WriteLine("Книги не найдены.");
                        else
                            foundBooks.ForEach(b => b.ShowInfo());
                        break;
                    case "3":
                        Console.Write("Введите жанр (например, Fantasy, Non-fiction): ");
                        var genre = Console.ReadLine();
                        var genreBooks = store.FilterByGenre(genre);
                        if (!genreBooks.Any())
                            Console.WriteLine("Нет книг с таким жанром.");
                        else
                            genreBooks.ForEach(b => b.ShowInfo());
                        break;
                    case "4":
                        Console.Write("Введите точное название книги для добавления в корзину: ");
                        var title = Console.ReadLine();
                        var bookToAdd = store.GetBookByExactTitle(title);
                        if (bookToAdd == null)
                            Console.WriteLine("Книга не найдена.");
                        else
                            cart.AddToCart(bookToAdd);
                        break;
                    case "5":
                        cart.ViewCart();
                        break;
                    case "6":
                        cart.Checkout(currentUser);
                        break;
                    case "7":
                        currentUser.ShowPurchaseHistory();
                        break;
                    case "8":
                        Console.WriteLine("До свидания!");
                        return;
                    default:
                        Console.WriteLine("Неверный пункт меню.");
                        break;
                }
            }
        }
        static User AuthorizeUser()
        {
            while (true)
            {
                Console.Write("Введите имя пользователя: ");
                string name = Console.ReadLine();
                Console.Write("Введите PIN-код: ");
                if (int.TryParse(Console.ReadLine(), out int pin))
                {
                    User user = null;

                    foreach (var u in users)
                    {
                        if (string.Equals(u.Name, name, StringComparison.OrdinalIgnoreCase) && u.PinCode == pin)
                        {
                            user = u;
                            break;
                        }
                    }
                    if (user != null)
                    {
                        Console.WriteLine($"Здравствуйте, {user.Name}!");
                        return user;
                    }
                }
                Console.WriteLine("Неверное имя или PIN-код. Попробуйте снова.\n");
            }
        }
    }
}
