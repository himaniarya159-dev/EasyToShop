namespace EasyToShop.DTOs;

public class CreateOrderDto
{
    public string FullName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string ShippingAddress { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
    public string PostalCode { get; set; } = string.Empty;
    public string PaymentMethod { get; set; } = "Credit Card";
}