namespace Shopping.Web.Models.Basket;

public class BasketCheckoutModel
{
    public string UserName { get; set; } = default!;
    
    public Guid CustomerId { get; set; } = default!;

    public decimal TotalPrice { get; set; } = default!;

    // Shipping and Billing Addresses
    public string FirstName { get; } = default!;
    public string LastName { get; } = default!;
    public string EmailAddress { get; } = default!;
    public string AddressLine { get; } = default!;
    public string Country { get; } = default!;
    public string State { get; } = default!;
    public string ZipCode { get; } = default!;

    // Payment
    public string CardName { get; } = default!;
    public string CardNumber { get; } = default!;
    public string Expiration { get; } = default!;
    public string CVV { get; } = default!;
    public int PaymentMethod { get; } = default!;
}

public record CheckoutBasketRequest(BasketCheckoutModel BasketCheckoutDto);
public record CheckoutBasketResponse(bool IsSuccess);