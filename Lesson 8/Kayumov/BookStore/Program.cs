namespace Homework8
{
    internal class BookShop
    {
       static void Main(string[] args)
            {
                Store store = new Store();
                ShoppingCart shoppingCart = new ShoppingCart();
            
                int action = 0;

                while (action != 6)
                {
                    store.ShowMenu();

                    action = Convert.ToInt32(Console.ReadLine());

                    switch (action)
                    {
                        case 1:
                            store.ShowAllBookNames();
                            Console.WriteLine();
                            break;
                        case 2:
                            store.ShowGenreBooks();
                            Console.WriteLine();
                            break;
                        case 3:
                            store.FindBook();
                            break;

                        case 4:
                            shoppingCart.ShowBasket();
                            break;


                        case 6:
                            Console.WriteLine("Goodbye!");
                            break;
                        default:
                            Console.WriteLine("Select an action and enter the correct аction number");
                            Console.WriteLine();
                            break;
                    }
                }
            }
       
    }
}




