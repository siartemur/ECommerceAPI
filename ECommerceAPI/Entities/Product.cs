using System.Collections.Generic;

namespace ECommerceAPI.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public bool IsDeleted { get; set; } = false; 
        public ICollection<Order> Orders { get; set; }
    }
}
