using PizzaStore.Database.Entities;

namespace PizzaStore.Services.Cart.Contract
{
    public interface ICartItemService
    {
        Task Add(CartItem cartItem);
        Task<List<CartItem>> GetAll();
        Task Delete(int id);
        //Task DeleteAll();
    }
}
