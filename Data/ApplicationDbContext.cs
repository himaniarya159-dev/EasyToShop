using EasyToShop.Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EasyToShop.Data;

public class ApplicationDbContext : IdentityDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Product> Products => Set<Product>();
    public DbSet<Coupon> Coupons => Set<Coupon>();
    public DbSet<Order> Orders => Set<Order>();
    public DbSet<OrderItem> OrderItems => Set<OrderItem>();
    public DbSet<ReturnRequest> ReturnRequests => Set<ReturnRequest>();

    protected override void OnModelCreating(ModelBuilder builder)
{
    base.OnModelCreating(builder);

    builder.Entity<Product>().HasData(
        // ================= WOMEN'S CLOTHING =================
        new Product 
        { 
            Id = 1, 
            Name = "Floral Summer Dress", 
            Description = "Lightweight breathable cotton dress with floral print.", 
            Category = "Women", 
            Price = 49.99m, 
            ImageUrl = "https://images.unsplash.com/photo-1572804013309-59a88b7e92f1?w=500", 
            StockQuantity = 45 
        },
        new Product 
        { 
            Id = 2, 
            Name = "Classic Denim Jacket", 
            Description = "Stylish dark-wash denim jacket for all seasons.", 
            Category = "Women", 
            Price = 69.99m, 
            ImageUrl = "https://images.unsplash.com/photo-1544441893-675973e31985?w=500", 
            StockQuantity = 30 
        },
        new Product 
        { 
            Id = 7, 
            Name = "Elegance Trench Coat", 
            Description = "Classic double-breasted beige trench coat.", 
            Category = "Women", 
            Price = 119.99m, 
            ImageUrl = "https://images.unsplash.com/photo-1591047139829-d91aecb6caea?w=500", 
            StockQuantity = 25 
        },
        new Product 
        { 
            Id = 8, 
            Name = "Knit Turtleneck Sweater", 
            Description = "Cozy wool-blend turtleneck sweater in cream.", 
            Category = "Women", 
            Price = 54.99m, 
            ImageUrl = "https://images.unsplash.com/photo-1576995853123-5a10305d93c0?w=500", 
            StockQuantity = 40 
        },
        new Product 
        { 
            Id = 9, 
            Name = "High-Waisted Tailored Trousers", 
            Description = "Sophisticated relaxed-fit trousers for formal or casual wear.", 
            Category = "Women", 
            Price = 59.99m, 
            ImageUrl = "https://images.unsplash.com/photo-1509551388413-e18d0ac5d495?w=500", 
            StockQuantity = 35 
        },

        // ================= MEN'S CLOTHING =================
        new Product 
        { 
            Id = 3, 
            Name = "Slim-Fit Casual Shirt", 
            Description = "100% premium cotton long-sleeve button-down shirt.", 
            Category = "Men", 
            Price = 39.99m, 
            ImageUrl = "https://images.unsplash.com/photo-1602810318383-e386cc2a3ccf?w=500", 
            StockQuantity = 60 
        },
        new Product 
        { 
            Id = 4, 
            Name = "Classic Leather Jacket", 
            Description = "Genuine brown leather biker jacket with zip closure.", 
            Category = "Men", 
            Price = 129.99m, 
            ImageUrl = "https://images.unsplash.com/photo-1520975954732-35dd22299614?w=500", 
            StockQuantity = 20 
        },
        new Product 
        { 
            Id = 10, 
            Name = "Urban Pullover Hoodie", 
            Description = "Comfortable everyday heavy-cotton hoodie in charcoal grey.", 
            Category = "Men", 
            Price = 44.99m, 
            ImageUrl = "https://images.unsplash.com/photo-1556905055-8f358a7a47b2?w=500", 
            StockQuantity = 50 
        },
        new Product 
        { 
            Id = 11, 
            Name = "Modern Fit Blazer", 
            Description = "Sleek navy blue blazer for business and dinner dates.", 
            Category = "Men", 
            Price = 139.99m, 
            ImageUrl = "https://images.unsplash.com/photo-1507679799987-c73779587ccf?w=500", 
            StockQuantity = 15 
        },
        new Product 
        { 
            Id = 12, 
            Name = "Casual Chino Pants", 
            Description = "Stretch cotton slim-fit chinos in beige.", 
            Category = "Men", 
            Price = 49.99m, 
            ImageUrl = "https://images.unsplash.com/photo-1624378439575-d8705ad7ae80?w=500", 
            StockQuantity = 45 
        },

        // ================= KIDS' CLOTHING =================
        new Product 
        { 
            Id = 5, 
            Name = "Kids Graphic Hoodie", 
            Description = "Soft fleece pullover hoodie with fun cartoon prints.", 
            Category = "Kids", 
            Price = 24.99m, 
            ImageUrl = "https://images.unsplash.com/photo-1519238263530-99bdd11df2ea?w=500", 
            StockQuantity = 50 
        },
        new Product 
        { 
            Id = 6, 
            Name = "Kids Denim Overalls", 
            Description = "Durable and comfortable cotton denim overalls for playtime.", 
            Category = "Kids", 
            Price = 29.99m, 
            ImageUrl = "https://images.unsplash.com/photo-1519457431-44ccd64a579b?w=500", 
            StockQuantity = 40 
        },
        new Product 
        { 
            Id = 13, 
            Name = "Kids Winter Puffer Jacket", 
            Description = "Warm insulated jacket to keep little ones cozy in cold weather.", 
            Category = "Kids", 
            Price = 39.99m, 
            ImageUrl = "https://images.unsplash.com/photo-1543854569-6f53414b4348?w=500", 
            StockQuantity = 30 
        },
        new Product 
        { 
            Id = 14, 
            Name = "Patterned Cotton Pyjamas", 
            Description = "Soft breathable 2-piece pyjama set with playful designs.", 
            Category = "Kids", 
            Price = 19.99m, 
            ImageUrl = "https://images.unsplash.com/photo-1514090458221-65bb69cf63e6?w=500", 
            StockQuantity = 60 
        },
        new Product 
        { 
            Id = 15, 
            Name = "Kids Sporty Sneakers", 
            Description = "Lightweight slip-on sneakers with non-slip rubber soles.", 
            Category = "Kids", 
            Price = 34.99m, 
            ImageUrl = "https://images.unsplash.com/photo-1511556532299-8f662fc26c06?w=500", 
            StockQuantity = 35 
        }
    );

    builder.Entity<Coupon>().HasData(
        new Coupon { Id = 1, Code = "SAVE20", DiscountPercentage = 20.00m, IsActive = true },
        new Coupon { Id = 2, Code = "PROMO10", FixedDiscountAmount = 10.00m, IsActive = true }
    );
}
}