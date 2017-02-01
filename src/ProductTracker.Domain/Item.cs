using System.ComponentModel.DataAnnotations;

namespace ProductTracker.Domain
{
    public class Item
    {
        [Key]
        public int Id { get; set; }
        public int Quantity { get; set; }
        public int ProductId { get; set; }
        public int OrderId { get; set; }
        public decimal TotalPrice { get; set; }
        public decimal TotalProfit { get; set; }

        public virtual Product Product { get; set; }
        public virtual Order Order { get; set; }
    }
}
