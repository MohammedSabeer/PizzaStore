using PizzaStore.Database.Entities;
using PizzaStore.Models;

namespace PizzaStore.Mapper
{
    public class ProductMapper
    {
        public static ProductModel MapProduct(Database.Entities.Product product, List<Topping> toppings = null)
        {

            return new ProductModel
            {
                Id = product.Id,
                Title = product.Name,
                Description = product.Description,
                ImageUrl = $"/images/pizza{product.Id}.jpg",
                Prices = new int[] { (int)product.Prices, (int)product.Prices + 200, (int)product.Prices + 400 },
                ExtraOptions = toppings?.ToArray()
            };
        }
    }
}
