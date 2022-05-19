using AutoMapper;
using ECommerce.Api.Products.Db;
using ECommerce.Api.Products.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Api.Products.Providers
{
    public class ProductsProvider : IProductsProvider
    {
        private readonly ProductsDbContext dbContext;
        private readonly ILogger<ProductsProvider> logger;
        private readonly IMapper mapper;

        public ProductsProvider(ProductsDbContext dbContext, ILogger<ProductsProvider> logger, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.logger = logger;
            this.mapper = mapper;

            SeedData();
        }

        private void SeedData()
        {
            if (!dbContext.Products.Any())
            {
                dbContext.Products.Add(new Db.Product { Id = 1, Name = "Keyboard", Price = 20, Inventory = 100 });
                dbContext.Products.Add(new Db.Product { Id = 2, Name = "Mouse", Price = 15, Inventory = 50 });
                dbContext.Products.Add(new Db.Product { Id = 3, Name = "Monitor", Price = 215, Inventory = 50 });

                dbContext.SaveChanges();
            }
        }

        public async Task<(bool IsSuccess, IEnumerable<Models.Product> Products, string ErrorMessage)> GetProductsAsync()
        {
            try
            {
                var products = await dbContext.Products.ToListAsync();

                if (products != null && products.Any())
                {
                    var result = mapper.Map<IEnumerable<Db.Product>, IEnumerable<Models.Product>>(products);
                    return (true, result, null);
                }

                return (false, null, "Not found");
            }
            catch (Exception exception)
            {
                logger?.LogError(exception.ToString());
                return (false, null, exception.Message);
            }
        }

        public async Task<(bool IsSuccess, Models.Product Product, string ErrorMessage)> GetProductAsync(int id)
        {
            try
            {
                var product = await dbContext.Products.SingleOrDefaultAsync(a => a.Id == id);

                if (product != null)
                {
                    var result = mapper.Map<Db.Product, Models.Product>(product);
                    return (true, result, null);
                }

                return (false, null, "Not found");
            }
            catch (Exception exception)
            {
                logger?.LogError(exception.ToString());
                return (false, null, exception.Message);
            }
        }
    }
}
