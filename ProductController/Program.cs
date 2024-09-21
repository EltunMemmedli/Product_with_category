using ProductController;
using System.Collections;

Product Product_1 = new Product("Apple", "Iphone 16 Pro", 3000, 20, ProductCategory.Phone);
Product Product_2 = new Product("Samsung", "S22 Ultra", 3500, 30, ProductCategory.Phone);
Product Product_3 = new Product("Apple", "SmartWatch", 1000, 50, ProductCategory.Watch);
Product Product_4 = new Product("Asus", "TUF F15 Gaming", 2000, 40, ProductCategory.Laptop);

Product_Controller Products = new Product_Controller();

Products.AddProduct(Product_1);
Products.AddProduct(Product_2);
Products.AddProduct(Product_3);
Products.AddProduct(Product_4);

Secim:
Console.WriteLine("Welcome!" +
                    "Select an option:\n" +
                    "1.Show all products,\n" +
                    "2.Show products by category,\n" +
                    "3.Add new product,\n" +
                    "4.Show total price of products,\n" +
                    "5.Show total price of products for category,\n" +
                    "6.Show total quantity of products,\n" +
                    "7.Show total quantity of products for category,\n" +
                    "8.Sell products,\n" +
                    "9.Remove product,\n" +
                    "10.Update product,\n" +
                    "11.Update product for property\n" +
                    "-------------------------------------");
string Secim = Console.ReadLine();
int secim;
if(int.TryParse(Secim, out secim) && 0 < secim && secim < 12)
{
    if(secim == 1)
    {
        Console.Clear();
        Products.ShowAllProducts();
    Kec:
        Thread.Sleep(1000);
        Console.WriteLine("\nPress 'f' to return to the start or any other key to exit...");
        string Kec = Console.ReadLine().ToLower();

        if (Kec == "f".ToLower())
        {
            Console.Clear();
            goto Secim;
        }
        else
        {
            Console.Clear();
            Console.WriteLine("Press the right button!");
            Thread.Sleep(1000);
            Console.Clear();
            goto Kec;
        }
    }

    else if(secim == 2)
    {
        Console.Clear();
    Category:
        Console.WriteLine("Which category do you want?");
        string Category = Console.ReadLine();
        if (!(string.IsNullOrEmpty(Category)))
        {
            Console.Clear() ;
            ArrayList products = Products.GetProducts();
            int counter = 1;

            
            bool foundCategory = false;

            foreach (Product product in products)
            {
                if (Category.ToLower() == product.Category.ToString().ToLower())
                {
                    foundCategory = true;
                    Console.WriteLine($"Product ID: {counter++}\n" +
                                      $"Brand: {product.Brand},\n" +
                                      $"Model: {product.Model},\n" +
                                      $"Price: {product.Price},\n" +
                                      $"Quantity: {product.Quantity},\n" +
                                      $"Category: {product.Category}\n");
                }
            
            }

            if (!foundCategory)
            {
                Console.Clear();
                Console.WriteLine("Cannot find category!");
                Thread.Sleep(1000);
                Console.Clear();
                goto Category;
            }

        Kec:
            Thread.Sleep(1000);
            Console.WriteLine("\nPress 'f' to return to the start or any other key to exit...");
            string Kec = Console.ReadLine().ToLower();

            if (Kec == "f".ToLower())
            {
                Console.Clear();
                goto Secim;
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Press the right button!");
                Thread.Sleep(1000);
                Console.Clear();
                goto Kec;
            }

        }
        else
        {
            Console.Clear();
            Console.WriteLine("Invalid Category!");
            Thread.Sleep(1000); 
            Console.Clear();
            goto Category;
        }
    }

    else if(secim == 3)
    {
        Console.Clear();
        Console.WriteLine("Please, enter product's category");
        string Category = Console.ReadLine();
        
        ArrayList Categories = new ArrayList(Enum.GetValues(typeof(ProductCategory)));

        foreach(ProductCategory category in Categories)
        {
            if(!(string.IsNullOrEmpty(Category)) && (Category.ToLower() == category.ToString().ToLower()))
            {
                Console.Clear();
            Brand:
                Console.WriteLine("Please, enter product's Brand");
                string Brand = Console.ReadLine();
                if (!(string.IsNullOrEmpty(Brand)))
                {
                    Console.Clear();
                Model:
                    Console.WriteLine("Please, enter product's Model");
                    string Model = Console.ReadLine();
                    if (!(string.IsNullOrEmpty(Model)))
                    {
                        Console.Clear();
                    Price:
                        Console.WriteLine("Please, enter product's Price");
                        string Price = Console.ReadLine();
                        decimal price;
                        if (decimal.TryParse(Price, out price) && price > 0)
                        {
                            Console.Clear();
                        Quantity:
                            Console.WriteLine("Please, enter product's Quantity");
                            string Quantity = Console.ReadLine();
                            int quantity;
                            if (int.TryParse(Quantity, out quantity) && quantity > 0)
                            {
                                Console.Clear();
                                Product NewProduct = new Product(Brand, Model, price, quantity, category);

                                Products.AddProduct(NewProduct);
                                Console.Clear();


                                ArrayList products = Products.GetProducts();

                                int counter = 1;
                                foreach (Product product in products)
                                {
                                    Console.WriteLine($"Product ID: {counter++}\n" +
                                                        $"Brand: {product.Brand},\n" +
                                                        $"Model: {product.Model},\n" +
                                                        $"Price: {product.Price},\n" +
                                                        $"Quantity: {product.Quantity},\n" +
                                                        $"Category: {product.Category}\n");
                                }
                            Kec:
                                Thread.Sleep(1000);
                                Console.WriteLine("\nPress 'f' to return to the start or any other key to exit...");
                                string Kec = Console.ReadLine().ToLower();

                                if (Kec == "f".ToLower())
                                {
                                    Console.Clear();
                                    goto Secim;
                                }
                                else
                                {
                                    Console.Clear();
                                    Console.WriteLine("Press the right button!");
                                    Thread.Sleep(1000);
                                    Console.Clear();
                                    goto Kec;
                                }
                            }
                            else
                            {
                                Console.Clear();
                                Console.WriteLine("Invalid Quantity!");
                                Thread.Sleep(1000);
                                Console.Clear();
                                goto Quantity;
                            }
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("Invalid Price!");
                            Thread.Sleep(1000);
                            Console.Clear();
                            goto Price;
                        }
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Invalid Model!");
                        Thread.Sleep(1000);
                        Console.Clear();
                        goto Model;
                    }
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Invalid Brand!");
                    Thread.Sleep(1000);
                    Console.Clear();
                    goto Brand;
                }
            }
        }
    }

    else if(secim == 4)
    {
        Console.Clear();
        ArrayList TotalPrice = Products.GetProducts();

        int s = 0;
        foreach (Product product in TotalPrice)
        {
            decimal Price = decimal.Parse(product.Price.ToString());

            int Quantity = int.Parse(product.Quantity.ToString());

            s = s + ((int)Price * Quantity);
        }
        Console.WriteLine($"Total Price is : {s}");
    Kec:
        Thread.Sleep(1000);
        Console.WriteLine("\nPress 'f' to return to the start or any other key to exit...");
        string Kec = Console.ReadLine().ToLower();

        if (Kec == "f".ToLower())
        {
            Console.Clear();
            goto Secim;
        }
        else
        {
            Console.Clear();
            Console.WriteLine("Press the right button!");
            Thread.Sleep(1000);
            Console.Clear();
            goto Kec;
        }
    }

    else if(secim == 5)
    {
        Console.Clear();
        Category:
        Console.WriteLine("Whcih category do you want?");
        string Category = Console.ReadLine();
        ArrayList products = Products.GetProducts();
        int s = 0;
        bool valid = false;
        foreach (Product product in products)
        {
            
            if (!(string.IsNullOrEmpty(Category)) && 
                (Category.ToLower() == product.Category.ToString().ToLower()))
            {
                valid = true;
                Console.Clear();
                decimal Price = decimal.Parse(product.Price.ToString());

                int Quantity = int.Parse(product.Quantity.ToString());

                s = s + ((int)Price * Quantity);
            }

        }
        if (!valid)
        {
            Console.Clear();
            Console.WriteLine("Can not find category!");
            Thread.Sleep(1000);
            Console.Clear();
            goto Category;
        }
        else
        {
            Console.WriteLine($"Total price for category {Category} is {s}");
        }
    Kec:
        Thread.Sleep(1000);
        Console.WriteLine("\nPress 'f' to return to the start or any other key to exit...");
        string Kec = Console.ReadLine().ToLower();

        if (Kec == "f".ToLower())
        {
            Console.Clear();
            goto Secim;
        }
        else
        {
            Console.Clear();
            Console.WriteLine("Press the right button!");
            Thread.Sleep(1000);
            Console.Clear();
            goto Kec;
        }
    }

    else if(secim == 6)
    {
        Console.Clear();
        ArrayList TotalPrice = Products.GetProducts();

        int s = 0;
        foreach (Product product in TotalPrice)
        { 

            int Quantity = int.Parse(product.Quantity.ToString());

            s = s +  Quantity;
        }
        Console.WriteLine($"Total Quantity is : {s}");
    Kec:
        Thread.Sleep(1000);
        Console.WriteLine("\nPress 'f' to return to the start or any other key to exit...");
        string Kec = Console.ReadLine().ToLower();

        if (Kec == "f".ToLower())
        {
            Console.Clear();
            goto Secim;
        }
        else
        {
            Console.Clear();
            Console.WriteLine("Press the right button!");
            Thread.Sleep(1000);
            Console.Clear();
            goto Kec;
        }

    }

    else if(secim == 7)
    {
        Console.Clear();
    Category:
        Console.WriteLine("Whcih category do you want?");
        string Category = Console.ReadLine();
        ArrayList products = Products.GetProducts();
        int s = 0;
        bool valid = false;
        foreach (Product product in products)
        {

            if (!(string.IsNullOrEmpty(Category)) &&
                (Category.ToLower() == product.Category.ToString().ToLower()))
            {
                valid = true;
                Console.Clear();
                

                int Quantity = int.Parse(product.Quantity.ToString());

                s = s +  Quantity;
            }

        }
        if (!valid)
        {
            Console.Clear();
            Console.WriteLine("Can not find category!");
            Thread.Sleep(1000);
            Console.Clear();
            goto Category;
        }
        else
        {
            Console.WriteLine($"Total Quantity for category {Category} is {s}");
        }
    Kec:
        Thread.Sleep(1000);
        Console.WriteLine("\nPress 'f' to return to the start or any other key to exit...");
        string Kec = Console.ReadLine().ToLower();

        if (Kec == "f".ToLower())
        {
            Console.Clear();
            goto Secim;
        }
        else
        {
            Console.Clear();
            Console.WriteLine("Press the right button!");
            Thread.Sleep(1000);
            Console.Clear();
            goto Kec;
        }
    }

    else if (secim == 8)
    {
        Console.Clear();
        ArrayList products = Products.GetProducts();
        Products.ShowAllProducts();  

        Category:
        int say = products.Count; 
        Console.WriteLine("\nWrite product's ID");
        string ID = Console.ReadLine();
        int id;

        
        if (int.TryParse(ID, out id) && id > 0 && id <= say)
        {
            Product selectedProduct = (Product)products[id - 1]; 

            if (selectedProduct.Quantity > 0)  
            {
                selectedProduct.Quantity--;  
                Console.Clear();
                Console.WriteLine("Product sold successfully!\n");

                
                Products.ShowAllProducts();
            }
            else
            {
                Console.Clear();
                Console.WriteLine("No quantity available for this product!");
            }

        
        Kec:
            Thread.Sleep(2000);
            Console.WriteLine("\nPress 'f' to return to the start or any other key to exit...");

            string Kec = Console.ReadLine();

            if (Kec.ToLower() == "f")
            {
                Console.Clear();
                goto Secim;
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Duzgun duymeye basdiginizdan emin olun!");
                goto Kec;
            }
        }
        else
        {
            Console.Clear();
            Console.WriteLine("Invalid ID!");
            Thread.Sleep(1000);
            Console.Clear();
            goto Category;
        }
    }

    else if(secim == 9)
    {
        Console.Clear();
        ArrayList products = Products.GetProducts();
        Products.ShowAllProducts();

        Category:
        Console.WriteLine("Write product ID");
        string ID = Console.ReadLine();
        int id;
        int say = products.Count;
        if(int.TryParse(ID, out id) && id > 0 && id < say + 1)
        {
            Console.Clear();
            Products.RemoveProduct(id);
            Console.WriteLine("Removed succesfully!");
            Products.ShowAllProducts();
        }
        else
        {
            Console.Clear();
            Console.WriteLine("Invalid ID!");
            Thread.Sleep(1000);
            Console.Clear();
            goto Category;
        }
    Kec:
        Thread.Sleep(2000);
        Console.WriteLine("\nPress 'f' to return to the start or any other key to exit...");

        string Kec = Console.ReadLine();

        if (Kec.ToLower() == "f")
        {
            Console.Clear();
            goto Secim;
        }
        else
        {
            Console.Clear();
            Console.WriteLine("Duzgun duymeye basdiginizdan emin olun!");
            goto Kec;
        }

    }

    else if(secim == 10)
    {
        Console.Clear();
        ArrayList update = Products.GetProducts();
        ArrayList Update = new ArrayList(Enum.GetValues(typeof(ProductCategory)));
        Products.ShowAllProducts();
        int say = update.Count;
        ID:
        Console.WriteLine("\nWrite product ID");
        string ID = Console.ReadLine();
        int id;
        if(int.TryParse(ID, out id) && id > 0 && id < say + 1)
        {
            Console.Clear();
            Category:
            Console.WriteLine("Please, enter product's category");
            string Category = Console.ReadLine();
            bool valid = false;
            foreach (ProductCategory updated in Update)
            {
                if (!(string.IsNullOrEmpty(Category)) && (Category.ToLower() == updated.ToString().ToLower()))
                {
                    valid = true;
                    Console.Clear();
                    Brand:
                    Console.WriteLine("Please, enter new Brand");
                    string Brand = Console.ReadLine();
                    if (!(string.IsNullOrEmpty(Brand)))
                    {
                        Console.Clear();
                        Model:
                        Console.WriteLine("Please, enter new Model");
                        string Model = Console.ReadLine();
                        if (!(string.IsNullOrEmpty(Model)))
                        {
                            Console.Clear();
                            Price:
                            Console.WriteLine("Please, enter new Price");
                            string Price = Console.ReadLine();
                            decimal price;
                            if (decimal.TryParse(Price, out price) && price > 0)
                            {
                                Console.Clear();
                                Quantity:
                                Console.WriteLine("Please, enter new Quantity");
                                string Quantity = Console.ReadLine();
                                int quantity;
                                if (int.TryParse(Quantity, out quantity) && quantity > 0)
                                {
                                    Console.Clear();
                                    Product Updated = new Product(Brand, Model, price, quantity, updated);

                                    Products.UpdateProduct(id, Updated);
                                    Products.ShowAllProducts();
                                Kec:
                                    Thread.Sleep(2000);
                                    Console.WriteLine("\nPress 'f' to return to the start or any other key to exit...");

                                    string Kec = Console.ReadLine();

                                    if (Kec.ToLower() == "f")
                                    {
                                        Console.Clear();
                                        goto Secim;
                                    }
                                    else
                                    {
                                        Console.Clear();
                                        Console.WriteLine("Duzgun duymeye basdiginizdan emin olun!");
                                        goto Kec;
                                    }
                                }
                                else
                                {
                                    Console.Clear();
                                    Console.WriteLine("Invalid Quantity!");
                                    Thread.Sleep(1000);
                                    goto Quantity;
                                }
                            }
                            else
                            {
                                Console.Clear();
                                Console.WriteLine("Invalid Price!");
                                Thread.Sleep(1000);
                                goto Price;
                            }
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("Invalid Model!");
                            Thread.Sleep(1000);
                            goto Model;
                        }
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Invalid Brand!");
                        Thread.Sleep(1000);
                        goto Brand;
                    }
                }
            }
            if (!valid)
            {
                Console.Clear();
                Console.WriteLine("Invalid Category!");
                Thread.Sleep(1000);
                Console.Clear();
                goto Category;
            }
        }
        else
        {
            Console.Clear();
            Console.WriteLine("Invalid ID!");
            Thread.Sleep(1000);
            Console.Clear();
            goto ID;
        }

    }

    else if (secim == 11)
    {
        Console.Clear();
        Products.ShowAllProducts();
        ArrayList products = Products.GetProducts();
        int say = products.Count;
        ID:
        Console.WriteLine("\nWrite product's ID:");
        string ID = Console.ReadLine();
        int id;

        
        if (int.TryParse(ID, out id) && id > 0 && id <= say)
        {
           
            Product selectedProduct = (Product)products[id - 1]; 
            
            
            Console.Clear();
            Console.WriteLine("Selected Product:");
            Console.WriteLine($"Brand: {selectedProduct.Brand}");
            Console.WriteLine($"Model: {selectedProduct.Model}");
            Console.WriteLine($"Price: {selectedProduct.Price}");
            Console.WriteLine($"Quantity: {selectedProduct.Quantity}");
            Console.WriteLine($"Category: {selectedProduct.Category}");

            Console.WriteLine("\nWrite property ID");
            string PropID = Console.ReadLine();
            int propid;
            if(int.TryParse(PropID, out propid) && propid > 0 && propid < 6)
            {
                Console.Clear();
                Console.WriteLine("Write new property");
                string newProperty = Console.ReadLine();

                Products.UpdateByProperty(id, propid, newProperty);
                Products.ShowAllProducts();
            Kec:
                Thread.Sleep(2000);
                Console.WriteLine("\nPress 'f' to return to the start or any other key to exit...");

                string Kec = Console.ReadLine();

                if (Kec.ToLower() == "f")
                {
                    Console.Clear();
                    goto Secim;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Duzgun duymeye basdiginizdan emin olun!");
                    goto Kec;
                }
            }

            
        }
        else
        {
            Console.Clear();
            Console.WriteLine("Invalid Product ID!");
            Thread.Sleep(1000);
            Console.Clear();
            goto ID;
        }
    }



}
else
{
    Console.Clear();
    Console.WriteLine("Invalid option!");
    Thread.Sleep(1000);
    Console.Clear() ;
    goto Secim;

}