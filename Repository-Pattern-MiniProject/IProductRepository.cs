using System;
using System.Collections.Generic;
using System.Text;

namespace Repository_Pattern
{
    internal interface IProductRepository
    {
        void AddProduct(Product product);
        Product GetProductById(int productId);
        void UpdateProduct(Product product);
        void DeleteProduct(int productId);
    }
}
