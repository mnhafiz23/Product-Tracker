using System.ComponentModel.DataAnnotations;

namespace ProductTracker.Domain
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }
        public string Fullname { get; set; }
        public string MobileNum { get; set; }
        public string Address { get; set; }
        public string PostCode { get; set; }
        public string City { get; set; }
        public string State { get; set; }
    }
}
