using HelloDependencyInjection.Payment;
using HelloDependencyInjection.Shopping;
using Microsoft.Extensions.DependencyInjection;

namespace HelloDependencyInjection
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Hiermit waere das DIP umgesetzt
            var payment = new PaymentService();
            var cart = new ShoppingCart(payment, new StoreSettings());
            cart.Checkout();

            Console.WriteLine("\nMit Dependency Injection Package");
            // Install-Package Microsoft.Extensions.DependencyInjection

            ServiceProvider provider = RegisterTypesOnInitialAppStartup();

            // Der sog. Dependency Tree wird durch das Package automatisch aufgeloest
            var cartFromProvider = provider.GetRequiredService<IShoppingCart>();
            cartFromProvider.Checkout();

            using (IServiceScope scope = provider.CreateScope())
            {
                var cartFromScope = scope.ServiceProvider.GetRequiredService<IShoppingCart>();
                cartFromScope.Checkout();

                // Wird dieselbe Payment Instanz haben
                var anotherCartFromScope = scope.ServiceProvider.GetRequiredService<IShoppingCart>();
                anotherCartFromScope.Checkout();

                // using Block ruft am Ende automatisch Dispose auf
                // Typischer Weise bei DB-Verbindungen, HttpClient, Dateizugriff, etc.
                // scope.Dispose();
            }

            // using ist sog. Syntactic Sugar
            // Der Compiler uebersetzt das in das folgende Pattern
            var scopeAlt = provider.CreateScope();
            try
            {
                var cartFromScopeAlt = scopeAlt.ServiceProvider.GetRequiredService<IShoppingCart>();
            }
            finally
            {
                scopeAlt.Dispose();
            }
        }

        /// <summary>
        /// Wir machen die Typen der ServiceCollection bekannt. Sie fungiert als "Dependency Factory".
        /// Factories kuemmern sich um die Erzeugung von Objekten. Zusaetzlich kuemmert sich das
        /// Package um die korrekte Aufloesung der Abhaengigkeit, dem sog. Dependency Tree.
        /// </summary>
        /// <returns></returns>
        private static ServiceProvider RegisterTypesOnInitialAppStartup()
        {
            var collection = new ServiceCollection();

            // Jedes mal wird das Objekt neu erzeugt, d.h. new()
            collection.AddTransient<IShoppingCart, ShoppingCart>();

            // Jedes Objekt wird innerhalb eines Scopes nur einmal erzeugt
            collection.AddScoped<IPaymentService, PaymentService>();

            // Ein Objekt wird nur ein einziges Mal erzeugt
            collection.AddSingleton<StoreSettings>();

            var provider = collection.BuildServiceProvider();
            return provider;
        }
    }
}
