using System;
using System.Collections.Generic;

namespace ProductTracker.Domain
{
    public class Order
    {
        public int Id { get; set; }
        public string OrderNum { get; set; }
        public int CustomerId { get; set; }
        public DateTime DatePurchase { get; set; }

        public virtual ICollection<Item> Items { get; set; }
    }
}
