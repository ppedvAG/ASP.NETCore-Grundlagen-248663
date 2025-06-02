namespace HelloDependencyInjection.Payment;

public class PaymentService : IPaymentService
{
    public void MakePayment()
    {
        Console.WriteLine($"Zahlung durchgeführt. {GetHashCode()}");
    }
}
