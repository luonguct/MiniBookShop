using Microsoft.EntityFrameworkCore;
using MiniShop.Api.Data.Entities;

namespace MiniShop.Api.Data.DbContext
{
    public class MiniShopDbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public MiniShopDbContext(DbContextOptions<MiniShopDbContext> options) : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
    }
}