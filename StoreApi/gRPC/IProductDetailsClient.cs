using StoreApi.Model;

namespace StoreApi.gRPC
{
    public interface IProductDetailsClient
    {
        Task<Product> GetProduct(int productId);
        Task<IList<Product>> GetCategoryProducts(IList<int> categoryIds);
    }
}