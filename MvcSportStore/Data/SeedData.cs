using Microsoft.EntityFrameworkCore;
using MvcSportStore.Models;

namespace MvcSportStore.Data
{
    public static class SeedData
    {
        public static void EnsurePopulated(WebApplication app)
        {
            //StoreDbContext context=new stor
            using (var scope = app.Services.CreateScope())
            {

                var context = scope.ServiceProvider.GetRequiredService<StoreDbContext>();
                context.Database.Migrate();
                if (!context.Products.Any())
                {
                    var products = DefaultData.GetProductList();
                    foreach (var product in products)
                    {
                        context.Products.Add(GetProduct(product));
                    }
                    context.SaveChanges();
                }

            }
        }
        private static Product GetProduct(string data)
        {            
            var productData = data.Split(';');
            var product = new Product(productData);
            return product;
        }
    }
}
