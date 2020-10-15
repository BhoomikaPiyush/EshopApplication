using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EshopApplication.DBContext;
using EshopApplication.Model;
using Microsoft.EntityFrameworkCore;

namespace EshopApplication.Repository
{
    public class ProductRepository : IProductRepository
    {
        private ProductContext _dbcontext;
        public ProductRepository(ProductContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public void DeleteProduct(int ProductId)
        {
            var product = _dbcontext.Products.Find(ProductId);
            _dbcontext.Products.Remove(product);
            Save();
        }

        public Product GetProductByID(int ProductId)
        {
            return _dbcontext.Products.Find(ProductId);
            // throw new NotImplementedException();
        }

        public IEnumerable<Product> GetProducts()
        {
            //var data = from p in _dbcontext.Products
            //           join c in _dbcontext.Categories on p.CategoryId equals c.Id
            //           select new ProductCategory()
            //           {

            //              Id= p.Id,
            //             Name=  p.Name,
            //               Price = p.Price,
            //              Description= p.Description,
            //              CategoryName= c.Name,
            //           };

            return _dbcontext.Products.ToList();
            // throw new NotImplementedException();
        }

        public void InsertProduct(Product Product)
        {
            _dbcontext.Add(Product);
            Save();
            // throw new NotImplementedException();
        }

        public void Save()
        {
            _dbcontext.SaveChanges();

        }

        public void UpdateProduct(Product Product)
        {
            _dbcontext.Entry(Product).State = EntityState.Modified;
            Save();
        }
    }
}
