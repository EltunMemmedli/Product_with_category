using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductController
{
    internal class Product_Controller
    {
        ArrayList Products;

        public Product_Controller()
        {
            Products = new ArrayList();
        }

        public void AddProduct(Product product)
        {
            Products.Add(product);
        }

        public void ShowAllProducts()
        {
            int counter = 1;
            foreach (Product product in Products)
            {
                Console.WriteLine($"Product ID: {counter++}\n" +
                                    $"Brand: {product.Brand},\n" +
                                    $"Model: {product.Model},\n" +
                                    $"Price: {product.Price},\n" +
                                    $"Quantity: {product.Quantity},\n" +
                                    $"Category: {product.Category}\n");
            }
        }

        public ArrayList GetProducts()
        {
            return Products;
        }

        public void RemoveProduct(int IndexofProducts)
        {
            Products.RemoveAt(IndexofProducts - 1);

        }

        public void UpdateProduct(int IndexofProduct, Product products)
        {
            Products[IndexofProduct - 1] = products;
        }

        public void UpdateByProperty(int indexOfProduct, int indexOfProperty, string newProperty)
        {
            Product update = (Product)Products[indexOfProduct - 1];

            switch (indexOfProperty)
            {
                case 1: // Brand
                    update.Brand = newProperty;
                    break;
                case 2: // Model
                    update.Model = newProperty;
                    break;
                case 3: // Price
                    if (decimal.TryParse(newProperty, out decimal newPrice) && newPrice > 0)
                    {
                        update.Price = newPrice;
                    }
                    break;
                case 4: // Quantity
                    if (int.TryParse(newProperty, out int newQuantity) && newQuantity > 0)
                    {
                        update.Quantity = newQuantity;
                    }
                    break;
                case 5: // Category
                    if (Enum.TryParse(typeof(ProductCategory), newProperty, true, out var category))
                    {
                        update.Category = (ProductCategory)category;
                    }
                    break;
                default:
                    Console.WriteLine("Invalid property index.");
                    break;
            }
        }

    }
}
