namespace ConsoleApp8
{
    internal class BookShop
    {
       static void Main(string[] args)
            {
                Store store = new Store();
            
                int action = 0;

                while (action != 6)
                {
                    store.ShowMenu();

                    action = Convert.ToInt32(Console.ReadLine());

                    switch (action)
                    {
                        case 1:
                            store.ShowAllBooks();
                            break;
                        case 2:
                            store.ShowGenreBooks();
                            break;
                        case 3:
                            store.FindBook();
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




