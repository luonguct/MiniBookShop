

using Microsoft.EntityFrameworkCore;
using MiniShop.Core.Entities;

namespace Minishop.Infrastructure.Data
{
    public class MiniShopDbContext : DbContext
    {
        public MiniShopDbContext(DbContextOptions<MiniShopDbContext> options) : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
    }
}