using System.Data.Entity;
using System.Threading.Tasks;
using WebApp.Models;

namespace WebApp.Tests
{
    public class TestWebAppContext : IApplicationDbContext
    {
        public TestWebAppContext()
        {
            Products = new TestProductDbSet();
        }

        public DbSet<Product> Products { get; set; }

        public Task<int> SaveChangesAsync()
        {
            return Task.FromResult(0);
        }

        public void MarkAsModified(Product item) { }

        public void Dispose() { }
    }
}
