﻿namespace Domain.Entities
{
    public class CartItem
    {
        public Guid Id { get; set; }
        public int CartId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public Cart? Cart { get; set; }
        public Product? Product { get; set; }
    }
}
