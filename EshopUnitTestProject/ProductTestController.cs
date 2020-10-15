using System;
using System.Collections.Generic;
using System.Text;
using EshopApplication.Controllers;
using EshopApplication.DBContext;
using EshopApplication.Model;
using EshopApplication.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace EshopUnitTestProject
{
    public class ProductTestController
    {
        private IProductRepository repository;
       
        public ProductTestController()
        {
            var options = new DbContextOptionsBuilder<ProductContext>()
           .UseInMemoryDatabase("ProductDB")
           .Options;

            // Insert seed data into the database using one instance of the context
            var context = new ProductContext(options);
            
                context.Products.AddRange(
                       new Product
                       {
                           Id = 1,
                           Name = "TV",
                           Description = "LG TV",
                           Price = 12,
                           CategoryId = 1,
                       },
                   new Product
                   {
                       Id = 2,
                       Name = "Shirts",
                       Description = "Dresses",
                       Price = 300,
                       CategoryId = 2,
                   },
                    new Product
                    {
                        Id = 3,
                        Name = "Garam Masala",
                        Description = "Grocery Items",
                        Price = 50,
                        CategoryId = 3,
                    }
                       );
                context.SaveChanges();
                repository = new ProductRepository(context);
            
            
        }
        [Fact]
        public void Task_GetProduct_Return_OkResult()
        {
            //Arrange  
            var controller = new ProductController(repository);
           

            //Act  
            var data = controller.Get();
           
            //Assert  
            Assert.IsType<OkObjectResult>(data);
        }
        [Fact]
        public void Task_GetProductByID_Return_OkResult()
        {
            //Arrange  
            var controller = new ProductController(repository);
            int Id = 1;

            //Act  
            var data = controller.Get(Id);

            //Assert  
            Assert.IsType<OkObjectResult>(data);
        }
        [Fact]
        public void Task_PostProduct_Return_OkResult()
        {
            //Arrange  
            var controller = new ProductController(repository);
            Product product = new Product
            {
                Id = 4,
                Name = "Tops",
                Description = "Dresses",
                Price = 3003,
                CategoryId = 2,
            };

            //Act  
            var data = controller.Post(product);

            //Assert  
            Assert.IsType<OkObjectResult>(data);
        }
        [Fact]
        public  void Task_Delete_Product_Return_OkResult()
        {
            //Arrange  
            var controller = new ProductController(repository);
            var id = 2;

            //Act  
            var data =  controller.Delete(id);

            //Assert  
            Assert.IsType<OkResult>(data);
        }
    }
}
