﻿namespace ECommerceAPI.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}
