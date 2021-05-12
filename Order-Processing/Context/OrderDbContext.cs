using Microsoft.EntityFrameworkCore;
using Order_Processing.Entities;

namespace Order_Processing.Context
{
    public class OrderDbContext : DbContext
    {
        public OrderDbContext(DbContextOptions<OrderDbContext> dbContextOptions)
            : base(dbContextOptions) { }

        public DbSet<Order> OrderSet { get; set; }

        public DbSet<OrderDetail> OrderDetailSet { get; set; }

        public DbSet<ProductType> ProductTypeSet { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>().HasKey(x => x.OrderId);
            modelBuilder.Entity<OrderDetail>().HasKey(x => x.OrderDetailId);
            modelBuilder.Entity<ProductType>().HasKey(x => x.ProductTypeId);
            modelBuilder.Entity<OrderDetail>().HasOne(d => d.ProductDetail).WithOne(p => p.OrderDetail).HasForeignKey<OrderDetail>(p => p.ProductId);

            modelBuilder.Entity<ProductType>().HasData(
        new ProductType { ProductTypeId = 1, ProductWidth = 19, ProductTypeName = "PhotoBook" },
        new ProductType { ProductTypeId = 2, ProductWidth = 10, ProductTypeName = "Calendar" },
        new ProductType { ProductTypeId = 3, ProductWidth = 16, ProductTypeName = "Canvas" },
        new ProductType { ProductTypeId = 4, ProductWidth = 4.7, ProductTypeName = "Greeting Cards Set" },
        new ProductType { ProductTypeId = 5, ProductWidth = 94, ProductTypeName = "Mug" }
        );
        }
    }
}
