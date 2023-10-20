﻿namespace PLMS.Core.Entity
{
    public class Product:BaseEntity
    {
        public required string Name { get; set; }
        public int Stock { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
        public required Category Category { get; set; }
    }
}