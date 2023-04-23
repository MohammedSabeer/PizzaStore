using PizzaStore.Database.Entities;

namespace PizzaStore.Services.Orders.Contract
{
    public interface IOrderService
    {
        Task<Order> Get(int id);
        Task<int> Add(double amount);

    }
}
