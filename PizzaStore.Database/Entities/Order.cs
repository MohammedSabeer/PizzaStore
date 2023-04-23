using System.ComponentModel.DataAnnotations;

namespace PizzaStore.Database.Entities
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        public Guid OrderId { get; set; }
        public double Amount { get; set; }

        public List<CartItem> CartItems { get; set; } = new List<CartItem>();
    }
}
