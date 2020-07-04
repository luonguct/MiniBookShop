using Microsoft.EntityFrameworkCore;
using MiniShop.Data.Entities;

namespace MiniShop.Data.DbContext
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