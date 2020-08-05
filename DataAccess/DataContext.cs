using AppGr8.WebApiECommerce.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace AppGr8.WebApiECommerce.DataAccess
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        public DbSet<ProductEntity> Products { get; set; } = null!;
        public DbSet<OrderEntity> Orders { get; set; } = null!;
        public DbSet<UserEntity> Users { get; set; } = null!;

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<UserEntity>()
        //        .HasMany(o => o.Orders)
        //        .WithOne(u => u.User)
        //        .HasForeignKey(k => k.User_Id);

        //    modelBuilder.Entity<OrderEntity>()
        //        .HasMany(p => p.Products)
        //        .WithOne(o => o.Order);

        //    modelBuilder.Entity<ProductEntity>()
        //        .HasOne(o => o.Order)
        //        .WithMany(p => p.Products);
        //}
    }
}
