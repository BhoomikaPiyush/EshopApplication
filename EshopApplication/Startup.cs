using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EshopApplication.DBContext;
using EshopApplication.Model;
using EshopApplication.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace EshopApplication
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddDbContext<ProductContext>(opt => opt.UseInMemoryDatabase("ProductDB"));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();
           
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            AddTestData(app);
        }
        private static void AddTestData(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                using (var context = serviceScope.ServiceProvider.GetRequiredService<ProductContext>())// (serviceProvider.GetRequiredService<DbContextOptions<ProductContext>>()))
                {
                    if (context.Products.Any())
                        return;
                   
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
                }

            }

        }
    }
}
