using Microsoft.EntityFrameworkCore;
using PizzaStore.Database;
using PizzaStore.Database.Entities;
using PizzaStore.Services.Cart.Contract;

namespace PizzaStore.Services.Cart
{
    public class CartItemService : ICartItemService
    {
        private readonly PizzaStoreContext pizzaStoreContext;

        public CartItemService(PizzaStoreContext pizzaStoreContext)
        {
            this.pizzaStoreContext = pizzaStoreContext;
        }

        public async Task<List<CartItem>> GetAll()
        {
            var cartItems = await pizzaStoreContext.
                                    CartItems.Include(a=>a.Product)
                                    .Where(a => a.OrderId == null)
                                    .ToListAsync();

            if (cartItems.Count > 0)
            {
                return cartItems;
            }

            return null;
        }

        public async Task Add(CartItem cartItem)
        {
            if (cartItem != null)
            {
                pizzaStoreContext.Add(cartItem);
                await pizzaStoreContext.SaveChangesAsync();
            }
        }


        public async Task Delete(int id)
        {
            var cartItem = await pizzaStoreContext.CartItems.FirstOrDefaultAsync(a => a.Id == id);

            if (cartItem != null)
            {
                pizzaStoreContext.Remove(cartItem);
                await pizzaStoreContext.SaveChangesAsync();
            }
        }

        //public async Task DeleteAll()
        //{
        //    var cartItems = await pizzaStoreContext.CartItems.ToListAsync();

        //    if (cartItems.Count > 0)
        //    {
        //        pizzaStoreContext.RemoveRange(cartItems);
        //        await pizzaStoreContext.SaveChangesAsync();
        //    }
        //}
    }
}
