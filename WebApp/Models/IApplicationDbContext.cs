using System;
using System.Data.Entity;
using System.Threading.Tasks;

namespace WebApp.Models
{
    public interface IApplicationDbContext : IDisposable
    {
        DbSet<Product> Products { get; }

        Task<int> SaveChangesAsync();

        void MarkAsModified(Product item);
    }
}
