using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace YuusufPieShop.Models
{
    public class YuusufPieShopDbContext : IdentityDbContext
    {
        public YuusufPieShopDbContext(DbContextOptions<YuusufPieShopDbContext>
            options) : base(options)
        {
        }
          public DbSet<Pie> Pies { get; set; }
          public DbSet<Category> Categories { get; set; }
          public DbSet<ShoppingCartItem> ShoppingCartItems { get; set;}
          public DbSet<Order> Orders { get; set; }
          public DbSet<OrderDetail> OrderDetails { get; set; }


    }
}
