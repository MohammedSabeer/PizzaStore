namespace PizzaStore.Services.Toppings.Contract
{
    public interface IToppingService
    {
        Task<List<Database.Entities.Topping>> Get();
    }
}
