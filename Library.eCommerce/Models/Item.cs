﻿using Spring2025_Samples.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.eCommerce.Models
{
    public class Item
    {
        public int Id { get; set; }
        public Product Product { get; set; }
        public int? Quantity { get; set; }
        public double? Price { get; set; }
        public override string ToString()
        {
            return $"{Product} Quantity:{Quantity} Price: {Price}";
        }

        public string Display
        {
            get
            {
                return Product?.Display ?? string.Empty;
            }
        }
        
        public Item()
        {
            Product = new Product();
            Quantity = 0;
            Price = 0;
        }

        public Item(Item i)
        {
            Product = new Product(i.Product);
            Quantity = i.Quantity;
            Price = i.Price;
            Id = i.Id;
        }
    }
}