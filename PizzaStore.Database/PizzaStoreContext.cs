using Microsoft.EntityFrameworkCore;
using PizzaStore.Database.Entities;

namespace PizzaStore.Database
{
    public class PizzaStoreContext : DbContext
    {
        public PizzaStoreContext(DbContextOptions dbContextOptions) : base(dbContextOptions) { }

        public DbSet<Product> Products { get; set; }
        public DbSet<Topping> Toppings { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<CartItemTopping> CartItemToppings { get; set; }
        public DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().Property(x=>x.Prices).HasDefaultValue(default(decimal));


            modelBuilder.Entity<CartItem>().HasOne(a => a.Product).WithMany(a=>a.CartItems).HasForeignKey(a=>a.ProductId).IsRequired();

            modelBuilder.Entity<CartItemTopping>().HasOne(a=>a.CartItem).WithMany(a=>a.CartItemToppings).HasForeignKey(a=>a.CartItemId);

            modelBuilder.Entity<CartItem>().HasOne(a => a.Order).WithMany(a => a.CartItems).HasForeignKey(a => a.OrderId).IsRequired(false);

            base.OnModelCreating(modelBuilder); 
        }
    }
}
