namespace HelloDependencyInjection.Shopping
{
    public interface IShoppingCart
    {
        void Checkout();

        void AddProduct(string description);
    }
}