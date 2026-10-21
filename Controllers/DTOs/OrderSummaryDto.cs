namespace EasyToShop.DTOs;

public class OrderSummaryDto
{
    public int OrderId { get; set; }
    public string FullName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string ShippingAddress { get; set; } = string.Empty;
    public string PaymentMethod { get; set; } = string.Empty;
    public decimal TotalAmount { get; set; }
    public DateTime OrderDate { get; set; }
    public string Status { get; set; } = string.Empty;
}