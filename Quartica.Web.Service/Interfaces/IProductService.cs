using Quartica.Web.Service.Models;

namespace Quartica.Web.Service.Interfaces
{
    public interface IProductService
    {
        Task<bool> InsertOrUpdateProductAsync(Product product);
        Task<Product> fetchProductByProductAsync(long productId);
        Task<Product> fetchProductByProductAsync(string productName);
        Task<List<Product>> fetchAllProductAsync(string searchString = "");
    }
}
