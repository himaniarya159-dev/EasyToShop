namespace EasyToShop.Models;

public class CartViewModel
{
    public List<CartItemViewModel> Items { get; set; } = new();
    public string? AppliedCouponCode { get; set; }
    public decimal DiscountAmount { get; set; }

    public decimal ShippingFee { get; set; } = 0m;

    public decimal Subtotal => Items.Sum(i => i.TotalPrice);

    public decimal Total => Math.Max(0, Subtotal - DiscountAmount + ShippingFee);

    public decimal GrandTotal => Total;
}

public class CartItemViewModel
{
    public int ProductId { get; set; }
    public string ProductName { get; set; } = string.Empty;
    public decimal UnitPrice { get; set; }
    public int Quantity { get; set; }
    
    public decimal TotalPrice => UnitPrice * Quantity;

    // Alias to support @item.Total in Views/Cart/Index.cshtml
    public decimal Total => TotalPrice;
}