namespace Ordering.Application.Orders.Queries.GetOrdersByCustomer.cs;

public record GetOrdersByCustomerQuery(Guid CustomerId) : IQuery<GetOrdersByCustomerResult>;

public record GetOrdersByCustomerResult(IEnumerable<OrderDto> Orders);