using Microsoft.EntityFrameworkCore;
using Quartica.Web.Service.DdContextConfiguration;
using Quartica.Web.Service.Helpers;
using Quartica.Web.Service.Interfaces;
using Quartica.Web.Service.Models;

namespace Quartica.Web.Service.Repository
{
    public class ProductService : IProductService
    {
        private readonly ApplicationDBContext dBContext;
        public ProductService(ApplicationDBContext dBContext)
        {
            this.dBContext = dBContext;
        }
        public async Task<List<Product>> fetchAllProductAsync(string searchString = "")
        {
            if (string.IsNullOrEmpty(searchString))
            {
                return await dBContext.products.Include(p => p.productAuditLogs).ToListAsync();
            }
            else
            {
                return await dBContext.products.Where(p => p.Name.Contains(searchString)).Include(p => p.productAuditLogs)
                    .ToListAsync();
            }
        }

        public async Task<Product> fetchProductByProductAsync(long productId)
        {
            return await dBContext.products.Where(x=>x.ProductId==productId).Include(p => p.productAuditLogs).FirstOrDefaultAsync();
        }

        public async Task<Product> fetchProductByProductAsync(string productName)
        {
            return await dBContext.products.Include(p=>p.productAuditLogs).FirstOrDefaultAsync(p => p.Name.Equals(productName, StringComparison.OrdinalIgnoreCase));
        }

        public async Task<bool> InsertOrUpdateProductAsync(Product product)
        {
            try
            {
                if (product.ProductId == 0)
                {
                    await dBContext.products.AddAsync(product);
                    await dBContext.SaveChangesAsync();

                    ProductAuditLog productAuditLog = new ProductAuditLog()
                    {
                        ActivityId = (long)UserActivity.Create,
                        ProductId = product.ProductId,
                        CreatedBy = product.CreatedBy,
                        CreatedOn = product.CreatedOn,
                        IsActive = product.IsActive,
                        ModifiedBy = product.ModifiedBy,
                        ModifiedOn = product.ModifiedOn,
                        UserId = product.CreatedBy,
                        ValueAfter = "New product was created",
                        ValueBefore = ""
                    };
                    await dBContext.productAuditLogs.AddAsync(productAuditLog);

                    var responce = await dBContext.SaveChangesAsync();
                    return responce == 1 ? true : false;
                }
                else
                {
                    dBContext.products.Update(product);

                    ProductAuditLog productAuditLog = new ProductAuditLog()
                    {
                        ActivityId = (long)UserActivity.Update,
                        ProductId = product.ProductId,
                        CreatedBy = product.CreatedBy,
                        CreatedOn = product.CreatedOn,
                        IsActive = product.IsActive,
                        ModifiedBy = product.ModifiedBy,
                        ModifiedOn = product.ModifiedOn,
                        UserId = product.CreatedBy,
                        ValueAfter = "New product was created",
                        ValueBefore = ""
                    };
                    await dBContext.productAuditLogs.AddAsync(productAuditLog);
                    var responce = await dBContext.SaveChangesAsync();
                    return responce == 1 ? true : false;
                }


                return false;
            }
            catch (Exception)
            {
                // Handle exception
                return false;
            }
        }
    }
}
