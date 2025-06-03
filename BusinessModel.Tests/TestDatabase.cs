using BusinessModel.Data;
using Microsoft.EntityFrameworkCore;

namespace BusinessLogic.Tests
{
    public class TestDatabase
    {
        private const string ConnectionString = @"Server=(localdb)\AspNetCoreKurs;Database=UnitTests;Trusted_Connection=True;ConnectRetryCount=0";
        private static readonly object _lock = new();
        private static bool _databaseInitialized;


        private DemoMvcDbContext _context;

        public DemoMvcDbContext Context => _context ??= CreateContext();

        public TestDatabase()
        {
            lock (_lock)
            {
                if (!_databaseInitialized)
                {
                    using var context = CreateContext();
                    context.Database.EnsureDeleted();
                    context.Database.Migrate();
                    _databaseInitialized = true;
                }
            }
        }

        private static DemoMvcDbContext CreateContext()
        {
            var builder = new DbContextOptionsBuilder<DemoMvcDbContext>().UseSqlServer(ConnectionString);
            var context = new DemoMvcDbContext(builder.Options);
            return context;
        }
    }
}