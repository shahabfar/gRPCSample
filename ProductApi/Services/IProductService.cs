using ProductApi.Model;

namespace ProductApi.Services
{
    public interface IProductService
    {
        Task<Product> GetProductById(int id);
        Task<IList<Product>> GetCategoryProducts(int categoryId);
    }
}