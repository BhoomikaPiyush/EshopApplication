using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EshopApplication.Model;
using Microsoft.EntityFrameworkCore;
namespace EshopApplication.DBContext
{
   public class ProductContext:DbContext
        {
            public ProductContext(DbContextOptions<ProductContext> options) : base(options)
            {
            }
            public DbSet<Product> Products { get; set; }
        }
}
