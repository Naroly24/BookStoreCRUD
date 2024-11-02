using Microsoft.EntityFrameworkCore;
using BookStoreCRUD.Domain.Models;

namespace BookStoreCRUD.Domain.Data
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options) { }

        public DbSet<Book> Books { get; set; }
    }
}
