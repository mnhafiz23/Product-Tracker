using System.ComponentModel.DataAnnotations;

namespace ProductTracker.Domain
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public decimal ProfitMargin { get; set; }
    }
}
