using Discount.Grpc;

namespace Basket.API.Basket.StoreBasket;

public record StoreBasketCommand(ShoppingCart Cart) : ICommand<StoreBasketResult>;
public record StoreBasketResult(string UserName);

public class StoreBasketCommandValidator : AbstractValidator<StoreBasketCommand>
{
    public StoreBasketCommandValidator()
    {
        RuleFor(x => x.Cart).NotNull().WithMessage("Cart cannot be null");
        RuleFor(x => x.Cart.UserName).NotEmpty().WithMessage("Username is required");
    }
}

public class StoreBasketCommandHandler(IBasketRepository repository, DiscountProtoService.DiscountProtoServiceClient discountProto) : ICommandHandler<StoreBasketCommand, StoreBasketResult>
{
    public async Task<StoreBasketResult> Handle(StoreBasketCommand command, CancellationToken cancellationToken)
    {
        // Communicate with Discount.Grpc and calculate the latest prices of the products
        await DeductDiscount(command.Cart, cancellationToken);

        ShoppingCart cart = command.Cart;
        await repository.StoreBasket(cart, cancellationToken);

        return new StoreBasketResult(cart.UserName);
    }

    public async Task DeductDiscount(ShoppingCart cart, CancellationToken cancellationToken)
    {
        foreach (var item in cart.Items)
        {
            var coupon = await discountProto.GetDiscountAsync(
                new GetDiscountRequest { ProductName = item.ProductName },
                cancellationToken: cancellationToken);
            if (coupon != null && coupon.Amount > 0)
            {
                item.Price -= coupon.Amount;
            }
        }
    }
}