namespace PizzaStore.Models
{
    public class ProductModel
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
        public int[]? Prices { get; set; }
        public object? ExtraOptions { get; set; }

    }
}