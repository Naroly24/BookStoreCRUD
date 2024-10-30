using Microsoft.EntityFrameworkCore;
using BookStoreCRUD.Models;

namespace BookStoreCRUD.Data
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Inventory> Inventories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>(tb =>
            {
                tb.HasKey(col => col.Id);

                tb.Property(col => col.Id)
                  .UseIdentityColumn()
                  .ValueGeneratedOnAdd();

                tb.Property(col => col.Price)
                  .HasPrecision(18, 2); 
            });

            modelBuilder.Entity<Order>(tb =>
            {
                tb.HasKey(col => col.Id);
                tb.HasOne(col => col.Customer)
                  .WithMany()
                  .HasForeignKey(col => col.CustomerId);

                tb.Property(col => col.TotalAmount)
                  .HasPrecision(18, 2);
            });

            modelBuilder.Entity<OrderItem>(tb =>
            {
                tb.HasKey(col => col.Id);
                tb.HasOne(col => col.Order)
                  .WithMany(o => o.OrderItems)
                  .HasForeignKey(col => col.OrderId);
                tb.HasOne(col => col.Book)
                  .WithMany()
                  .HasForeignKey(col => col.BookId);

                tb.Property(col => col.UnitPrice)
                  .HasPrecision(18, 2);
            });

            modelBuilder.Entity<Inventory>(tb =>
            {
                tb.HasKey(col => col.Id);
                tb.HasOne(col => col.Book)
                  .WithMany()
                  .HasForeignKey(col => col.BookId);
            });
        }

    }
}
