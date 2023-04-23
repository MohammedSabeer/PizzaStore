using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PizzaStore.Database.Entities
{
    public class CartItem
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int ProductId { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public double Price { get; set; }

        public int? OrderId { get; set; }

        public Product Product { get; set; } = null!;

        public Order Order { get; set; } = null!;

        public List<CartItemTopping> CartItemToppings { get; set; } = new List<CartItemTopping>();
    }
}
