using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductController
{
    internal class Product
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public ProductCategory Category { get; set; }

        public Product(string brand,
            string model,
            decimal price,
            int quantity,
            ProductCategory category)
        {
            Brand = brand;
            Model = model;
            Price = price;
            Quantity = quantity;
            Category = category;

        }
    }
}
