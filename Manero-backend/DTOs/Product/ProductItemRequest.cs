﻿namespace Manero_backend.DTOs.Product
{
    public class ProductItemRequest  // Product Variation Request
    {     
        public int Color { get; set; } 
        public int Size { get; set; }
        public decimal Price { get; set; }
        public int  Stock { get; set; }     

        public ICollection<string>? ImageAlt { get; set; }
        public ICollection<string>? ImageName { get; set; }
       
    }
}
