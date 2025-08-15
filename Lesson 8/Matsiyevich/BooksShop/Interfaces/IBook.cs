namespace BooksShop.Interfaces
{
    public interface IBook
    {
        string Title { get; }
        string Author { get; }
        string Genre { get; }
        decimal Price { get; }
        void ShowInfo();
    }
}
