using System.ComponentModel.DataAnnotations;

namespace PizzaStore.Database.Entities
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        [Required]
        public double Prices { get; set; }

        public List<CartItem> CartItems { get; set; } = new List<CartItem>();

       
    }
}
