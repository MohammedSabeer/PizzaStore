using PizzaStore.Database.Entities;

namespace PizzaStore.Models
{
    public class CartItemModel
    {
        public int Id { get; set; }
        public int ProductId { get; set; }

        public int Quantity { get; set; }

        public double Price { get; set; }

        public ProductModel? ProductModel { get; set; }

        public List<ToppingModel>? Toppings { get; set; }
    }
}
