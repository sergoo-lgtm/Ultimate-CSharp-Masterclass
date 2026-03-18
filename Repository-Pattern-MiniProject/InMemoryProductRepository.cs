using Repository_Pattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class InMemoryProductRepository : IProductRepository
{
    private readonly List<Product> products = new List<Product>();

    public void AddProduct(Product product)
    {
        products.Add(product);
    }

    public Product GetProductById(int productId)
    {
        var product = products.FirstOrDefault(p => p.Id == productId);
        if (product == null)
        {
            return new Product(-1, "Not Found", 0.0f); 
        }
        return product;
    }

    public void UpdateProduct(Product updatedProduct)
    {
        for (int i = 0; i < products.Count; i++)
        {
            if (products[i].Id == updatedProduct.Id)
            {
                products[i] = updatedProduct;
                return;
            }
        }
    }

    public void DeleteProduct(int productId)
    {
        products.RemoveAll(p => p.Id == productId);
    }
}