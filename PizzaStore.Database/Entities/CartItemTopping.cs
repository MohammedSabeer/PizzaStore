using System.ComponentModel.DataAnnotations;

namespace PizzaStore.Database.Entities
{
    public class CartItemTopping
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int CartItemId { get; set; }

        [Required]
        public int ToppingId { get; set; }

        public CartItem CartItem { get; set; }

        public  Topping Topping { get; set; }
    }
}
