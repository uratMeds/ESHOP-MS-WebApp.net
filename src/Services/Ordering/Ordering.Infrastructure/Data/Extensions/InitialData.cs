namespace Ordering.Infrastructure.Data.Extensions;

internal class InitialData
{
    public static IEnumerable<Customer> Customers => new List<Customer>
    {
        Customer.Create(CustomerId.Of(new Guid("58c49479-ec65-4de2-86e7-033c546291aa")), "mehmet", "mehmet@gmail.com"),
        Customer.Create(CustomerId.Of(new Guid("189dc8dc-990f-48e0-a37b-e6f2b60b9d7d")), "simo", "simo@gmail.com")
    };

    public static IEnumerable<Product> Products => new List<Product>
    {
        Product.Create(ProductId.Of(new Guid("53c9d479-ecb5-4de2-86e7-0335a465291a")), "IPhone X", 500),
        Product.Create(ProductId.Of(new Guid("189dc1dc-990f-48e0-a37b-e6f2b53b9d7d")), "Samsung 10", 400),
        Product.Create(ProductId.Of(new Guid("58c49479-ec65-4de2-86e7-033c529892aa")), "Huawei Plus", 650),
        Product.Create(ProductId.Of(new Guid("189dc8dc-990f-48e0-a37b-e6f2b3489d7d")), "Xiaomi Mi", 450)
    };

    public static IEnumerable<Order> OrdersWithItems
    {
        get
        {
            var address1 = Address.Of("mehmet", "Ozkaya", "mehmet@gmail.com", "Bachelievler No:4", "Turkey", "Istanbul", "38050");
            var address2 = Address.Of("jhon", "Doe", "jhon@gmail.com", "Broadway No:1", "England", "Nottingham", "08050");

            var payment1 = Payment.Of("mehmet", "55555555555555554444", "12/28", "355", 1);
            var payment2 = Payment.Of("jhon", "88855555555555555444", "06/30", "222", 2);

            var order1 = Order.Create(
                OrderId.Of(Guid.NewGuid()),
                CustomerId.Of(new Guid("58c49479-ec65-4de2-86e7-033c546291aa")),
                OrderName.Of("ORD_1"),
                shippingAddress: address1,
                billingAddress: address1,
                payment1
            );
            order1.Add(ProductId.Of(new Guid("53c9d479-ecb5-4de2-86e7-0335a465291a")), 2, 500);
            order1.Add(ProductId.Of(new Guid("189dc1dc-990f-48e0-a37b-e6f2b53b9d7d")), 1, 400);

            var order2 = Order.Create(
                OrderId.Of(Guid.NewGuid()),
                CustomerId.Of(new Guid("189dc8dc-990f-48e0-a37b-e6f2b60b9d7d")),
                OrderName.Of("ORD_2"),
                shippingAddress: address2,
                billingAddress: address2,
                payment2
            );
            order2.Add(ProductId.Of(new Guid("58c49479-ec65-4de2-86e7-033c529892aa")), 1, 650);
            order2.Add(ProductId.Of(new Guid("189dc8dc-990f-48e0-a37b-e6f2b3489d7d")), 2, 450);

            return new List<Order> { order1, order2 };
        }
    }
}