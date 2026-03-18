using Repository_Pattern;
using System;

class Program
{
    static void Main(string[] args)
    {

        IProductRepository productRepo = new InMemoryProductRepository();

        productRepo.AddProduct(new Product(1, "Keyboard", 25.0f));
        productRepo.AddProduct(new Product(2, "Mouse", 15.0f));

        Product retrievedProduct = productRepo.GetProductById(1);
        Console.WriteLine($"Retrieved Product: {retrievedProduct.Name} - ${retrievedProduct.Price}");

        retrievedProduct.Price = 30.0f;
        productRepo.UpdateProduct(retrievedProduct);

        productRepo.DeleteProduct(2);


    }
}