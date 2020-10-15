using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EshopApplication.Model;

namespace EshopApplication.Repository
{
   public interface IProductRepository
    {
        IEnumerable<Product> GetProducts();
        Product GetProductByID(int ProductId);
        void InsertProduct(Product Product);
        void DeleteProduct(int ProductId);
        void UpdateProduct(Product Product);
        void Save();
    }
}
