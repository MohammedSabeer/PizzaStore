using System.ComponentModel.DataAnnotations;

namespace PizzaStore.Database.Entities
{
    public class Topping
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public double Price { get; set; }

        public List<CartItemTopping> CartItemToppings { get; set; } = new List<CartItemTopping>();
    }
}
