namespace PizzaStore.Services.Product.Contract
{
    public interface IProductService
    {
        Task<List<Database.Entities.Product>> GetProducts();
        Task<Database.Entities.Product?> Get(int id);
    }
}
