using Microsoft.EntityFrameworkCore;
using PizzaStore.Database;
using PizzaStore.Services.Product.Contract;

namespace PizzaStore.Services.Product
{
    public class ProductService : IProductService
    {
        private readonly PizzaStoreContext pizzaStoreContext;

        public ProductService(PizzaStoreContext pizzaStoreContext)
        {
            this.pizzaStoreContext = pizzaStoreContext;
        }

        public async Task<List<Database.Entities.Product>> GetProducts()
        {
            var products = await pizzaStoreContext.Products.ToListAsync();
            return products;
        }

        public async Task<Database.Entities.Product?> Get(int id)
        {
            var product = await pizzaStoreContext.Products.FirstOrDefaultAsync(a=>a.Id == id);
            return product;
        }

    }
}
