using Microsoft.EntityFrameworkCore;
using PizzaStore.Database;
using PizzaStore.Database.Entities;
using PizzaStore.Services.Toppings.Contract;

namespace PizzaStore.Services.Toppings
{
    public class ToppingService : IToppingService
    {
        private readonly PizzaStoreContext pizzaStoreContext;

        public ToppingService(PizzaStoreContext pizzaStoreContext ) {
            this.pizzaStoreContext = pizzaStoreContext;
        }

        public async Task<List<Topping>> Get()
        {
            var toppings = await pizzaStoreContext.Toppings.ToListAsync();
            return toppings;
        }
    }
}
