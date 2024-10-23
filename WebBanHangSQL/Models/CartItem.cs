﻿namespace WebMoHinh.Models
{
	public class CartItem
	{
        public int ImageUrl { get; set; }
        public int ProductId { get; set; }
        public string? Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}
