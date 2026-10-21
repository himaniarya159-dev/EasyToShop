namespace EasyToShop.Data.Entities;

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public int StockQuantity { get; set; }
    public string ImageUrl { get; set; } = "/images/default-product.png";

    // Added Category property to resolve CS0117 build error
    public string Category { get; set; } = "General";
}

public class Coupon
{
    public int Id { get; set; }
    public string Code { get; set; } = string.Empty;
    public decimal DiscountPercentage { get; set; }
    public decimal FixedDiscountAmount { get; set; }
    public bool IsActive { get; set; } = true;
    public DateTime? ExpiryDate { get; set; }
}

public class Order
{
    public int Id { get; set; }
    public string? UserId { get; set; }
    public string FullName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string ShippingAddress { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
    public string PostalCode { get; set; } = string.Empty;
    public string PaymentMethod { get; set; } = "Credit Card"; // Added property
    public decimal TotalAmount { get; set; }
    public DateTime OrderDate { get; set; } = DateTime.UtcNow;
    public string Status { get; set; } = "Processing";

    public List<OrderItem> OrderItems { get; set; } = new();
}

public class OrderItem
{
    public int Id { get; set; }
    public int OrderId { get; set; }
    public Order Order { get; set; } = null!;
    public int ProductId { get; set; }
    public Product Product { get; set; } = null!;
    public decimal UnitPrice { get; set; }
    public int Quantity { get; set; }
}

public class ReturnRequest
{
    public int Id { get; set; }
    public int OrderId { get; set; }
    public Order Order { get; set; } = null!;
    public string Reason { get; set; } = string.Empty;
    public string Status { get; set; } = "Requested";
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}