using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
namespace WebMoHinh.Models
{
    public class ProductDbContext : IdentityDbContext<ApplicationUser>
    {

        public ProductDbContext(DbContextOptions<ProductDbContext> options) : base(options)
        { }
            public DbSet<Product> Products { get; set; }
            public DbSet<Category> Categories { get; set; }
            public DbSet<ProductImage> ProductImages { get; set; }
		    public DbSet<Order> Orders { get; set; }
		    public DbSet<OrderDetail> OrderDetails { get; set; }
	}
}
