using Microsoft.EntityFrameworkCore;
using PizzaStore.Database;
using PizzaStore.Database.Entities;
using PizzaStore.Services.Orders.Contract;

namespace PizzaStore.Services.Orders
{
    public class OrderService : IOrderService
    {
        private readonly PizzaStoreContext pizzaStoreContext;

        public OrderService(PizzaStoreContext pizzaStoreContext)
        {
            this.pizzaStoreContext = pizzaStoreContext;
        }

        public async Task<int> Add(double amount)
        {

            var order = new Order() { Amount = amount, OrderId = Guid.NewGuid()};
            pizzaStoreContext.Add(order);
            await pizzaStoreContext.SaveChangesAsync();

            var cartItems = await pizzaStoreContext.CartItems.Where(a=>a.OrderId == null).ToListAsync();

            if (cartItems != null && cartItems.Count > 0)
            {
                cartItems.ForEach(x =>x.OrderId = order.Id);
                pizzaStoreContext.UpdateRange(cartItems);
                await pizzaStoreContext.SaveChangesAsync();

                return order.Id;
            }

            return 0;
        }

        public async Task<Order> Get(int id)
        {
            var order = await pizzaStoreContext.Orders.Where(a => a.Id == id).FirstOrDefaultAsync();

            return order;
        }
    }
}
