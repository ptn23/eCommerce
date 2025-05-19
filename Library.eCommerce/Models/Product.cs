using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.eCommerce.Models;

namespace Spring2025_Samples.Models
{
    public class Product
    {
        public int Id { get; set; }

        public int Quantity { get; set; }
        public string? Name { get; set; }

        public double? Price { get; set; }
        public string? Display
        {
            get
            {
                return $"{Id}. {Name} ";
            }
        }

        public Product()
        {
            Name = string.Empty;
            Price = 100;
            Quantity = 100;
        }

        public Product(Product p)
        {
            Name = p.Name;
            Id = p.Id;
            Price = p.Price;
            Quantity = p.Quantity;
        }

        public override string ToString()
        {
            return Display ?? string.Empty;
        }
    }
}