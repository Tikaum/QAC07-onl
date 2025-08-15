using BookStore;
using BookStore.Interfaces;
using System.Diagnostics;
using System.Net;
using System.Xml.Linq;

namespace Homework8
{
    internal class BookShop
    {
        static void Main(string[] args)
        {
            int action = 0;

            Store store = new Store();
            ShoppingCart shoppingCart = new ShoppingCart(store);

            while (action != 8)
            {
                Menu menu = new Menu();
                
                menu.ShowMenu();


                action = Convert.ToInt32(Console.ReadLine());


                switch (action)
                {
                    //Выводим список книг
                    case 1:
                        {
                            Console.Clear();
                            foreach (Book book in store._books)
                            {
                                book.GetInfoAboutBook();
                            }
                            Console.WriteLine();
                            Console.WriteLine("Добавить какую-либо книгу в корзину?(y/n)");

                            string BuyOrNot = Console.ReadLine();

                            if (BuyOrNot != "y")
                            {                                
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Введите номер книги для добавления ее в корзину");
                                int NumberAddBook = Convert.ToInt32(Console.ReadLine());

                                Book FoundBook = store.FindBookById(NumberAddBook);

                                if (FoundBook != null)
                                {
                                    shoppingCart.AddToBasket(NumberAddBook);
                                    Console.WriteLine("Книга добавлена.\nСейчас в корзине находятся следующие книги: ");
                                    foreach (Book book in shoppingCart._booksInBasket)
                                    {
                                        book.GetInfoAboutBook();
                                    }
                                    
                                }
                                else
                                {
                                    Console.WriteLine("Книга не добавлена, так как отсутствует");
                                }
                                Console.WriteLine();
                            }
                            
                            break;
                        }
                    //ищем книги по жанру
                    case 2:
                        { 
                            Console.Clear();
                            Console.WriteLine("Введите номер одного из указанных ниже жанров:");
                            menu.ShowGenre();
                            int IDGenre = Convert.ToInt32(Console.ReadLine());
                            List<Book> results = store.SearchBooksByGenre(IDGenre);
                            Console.WriteLine("Найдены книги:");
                            foreach (Book book in results)
                            {
                                book.GetInfoAboutBook();
                            }

                            Console.WriteLine("Добавить какую-либо книгу в корзину?(y/n)");

                            string BuyOrNot = Console.ReadLine();

                            if (BuyOrNot != "y")
                            {
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Введите номер книги для добавления ее в корзину");
                                int NumberAddBook = Convert.ToInt32(Console.ReadLine());

                                Book FoundBook = store.FindBookById(NumberAddBook);

                                if (FoundBook != null)
                                {
                                    shoppingCart.AddToBasket(NumberAddBook);
                                    Console.WriteLine("Книга добавлена.\nСейчас в корзине находятся следующие книги: ");
                                    foreach (Book book in shoppingCart._booksInBasket)
                                    {
                                        book.GetInfoAboutBook();
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Книга не добавлена, так как отсутствует");
                                }
                                Console.WriteLine(); 
                                break;
                            }
                        }
                    //Искать книгу по названию
                    case 3:
                        {
                            Console.Clear();
                            Console.WriteLine("Введите полное или частичное название книги:");
                            string NameFindBook = Console.ReadLine();
                            List<Book> results = store.SearchBooksByName(NameFindBook);
                            if (results.Count != 0)
                            {
                                Console.WriteLine("Найдены книги:");
                                foreach (Book book in results)
                                {
                                    book.GetInfoAboutBook();
                                }
                                
                                Console.WriteLine("Добавить какую-либо книгу в корзину?(y/n)");

                                string BuyOrNot = Console.ReadLine();

                                if (BuyOrNot != "y")
                                {
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("Введите номер книги для добавления ее в корзину");
                                    int NumberAddBook = Convert.ToInt32(Console.ReadLine());

                                    Book FoundBook = store.FindBookById(NumberAddBook);

                                    if (FoundBook != null)
                                    {
                                        shoppingCart.AddToBasket(NumberAddBook);
                                        Console.WriteLine("Книга добавлена.\nСейчас в корзине находятся следующие книги: ");
                                        foreach (Book book in shoppingCart._booksInBasket)
                                        {
                                            book.GetInfoAboutBook();
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("Книга не добавлена, так как отсутствует");
                                    }
                                    Console.WriteLine();
                                    break;
                                }
                            }
                            else Console.WriteLine("Таких книг у нас нет:");
                            
                            Console.WriteLine();

                            break;
                        }

                    //Показать книгу по ID
                    case 4:
                        {
                            Console.Clear();
                            Console.WriteLine("Введите ID книги:");
                            int IDBook = Convert.ToInt32(Console.ReadLine());
                            Book results = store.FindBookById(IDBook);
                            if (results != null)
                            {
                                Console.WriteLine("Найдена книга:");
                                results.GetInfoAboutBook();
                                Console.WriteLine("Добавить данную книгу в корзину?(y/n)");

                                string BuyOrNot = Console.ReadLine();

                                if (BuyOrNot != "y")
                                {
                                    break;
                                }
                                else
                                {                                    
                                    int NumberAddBook = IDBook;

                                    Book FoundBook = store.FindBookById(NumberAddBook);                                                                        
                                    shoppingCart.AddToBasket(NumberAddBook);
                                    Console.WriteLine("Книга добавлена.\nСейчас в корзине находятся следующие книги: ");
                                    foreach (Book book in shoppingCart._booksInBasket)
                                    {
                                        book.GetInfoAboutBook();
                                    }                                                                     
                                    
                                }
                            }
                            else
                            {
                                Console.WriteLine("Книга с таким ID не найдена");
                            }
                            Console.WriteLine();
                            break;
                        }

                    //Показать содержимое корзины
                    case 5:
                        {
                            Console.Clear();
                            if (shoppingCart._booksInBasket.Count != 0)
                            {
                                Console.WriteLine("В корзине находятся следующие книги: ");
                                foreach (Book book in shoppingCart._booksInBasket)
                                {
                                    book.GetInfoAboutBook();
                                }                                
                            }
                            else Console.WriteLine("В корзине нет книг");
                            break;
                        }
                    //Купить содержимое корзины
                    case 6:
                        {
                            Console.Clear();
                            if (shoppingCart._booksInBasket.Count != 0)
                            {
                                Console.WriteLine("Желаете купить книги находящиеся в корзине? (y/n)");
                                string PayOrNot = Console.ReadLine();
                                                                
                                if (PayOrNot == "y")
                                {
                                    double pay = shoppingCart.Payment();
                                    Console.WriteLine($"Покупка совершнена! С вашего счета списано {pay}");                                    
                                    shoppingCart.TotalSum = 0;
                                    shoppingCart._booksInBasket.Clear();
                                }
                                else break;
                            }
                            else Console.WriteLine("В корзине нет книг");
                            Console.WriteLine();
                            break;
                        }

                    //Очистить содержимое корзины
                    case 7:
                        {
                            Console.Clear();
                            Console.WriteLine("Желаете очистить содержимое корзин? (y/n)");
                            string YesOrNot = Console.ReadLine();
                            if (YesOrNot == "y")
                            {
                                shoppingCart._booksInBasket.Clear();
                                Console.WriteLine("Корзина пуста");
                            }
                            break;
                        }
                    // Прощаемся
                    case 8:
                        {
                            Console.Clear();
                            Console.WriteLine("До свиданья!");
                            break;
                        }                        

                    default:
                        {
                            Console.WriteLine("Выберите номер доступного действия и повторите ввод:");
                            Console.WriteLine();
                            break;
                        }
                }
            }
        }
       
    }
}




