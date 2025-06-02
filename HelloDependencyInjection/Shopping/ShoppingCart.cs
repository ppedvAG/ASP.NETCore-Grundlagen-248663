using HelloDependencyInjection.Payment;

namespace HelloDependencyInjection.Shopping;

public class ShoppingCart : IShoppingCart
{

    // Wir sollten hier nicht gegen die konkrete Implementierung gehen
    private PaymentService _paymentService_badExample = new PaymentService();


    private readonly IPaymentService _paymentService;
    private readonly StoreSettings _settings;

    // DIP (Dependency Inversion Principle)
    // Die Abhängigkeit soll von aussen kommen
    public ShoppingCart(IPaymentService paymentService, StoreSettings settings)
    {
        _paymentService = paymentService;
        _settings = settings;
    }

    public void Checkout()
    {
        Console.WriteLine("Checkout");

        Console.WriteLine($"Settings {_settings.Foo}");
        _paymentService.MakePayment();

    }

    public void AddProduct(string description)
    {
        Console.WriteLine($"Produkt hinzugefügt: {description}");
    }
}
