public interface IShoppingCart
{
    void AddToCart(IBook book);
    void ViewCart();
    void Checkout();
}