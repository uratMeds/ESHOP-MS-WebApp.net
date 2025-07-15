namespace Shopping.Web.Services;

public interface IOrderingService
{
    [Get("/ordering-service/orders?pageIndex={pageIndex}&pageSize={pageSize}")]
    Task<GetOrdersReponse> GetOrders(int? pageIndex = 1, int? pageSize = 10);


    [Get("/ordering-service/orders/{orderName")]
    Task<GetOrdersByNameReponse> GetOrdersByName(string idorderName);


    [Get("/ordering-service/orders/customer/{customerId}")]
    Task<GetOrdersByCustomersReponse> GetOrdersByCustomer(Guid customerId);
}