using Grpc.Core;
using Grpc.Net.Client;
using StoreApi.Model;

namespace StoreApi.gRPC
{
    public class ProductDetailsClient : IProductDetailsClient, IDisposable
    {
        private readonly GrpcChannel channel;
        private readonly ProductDetails.ProductDetailsClient client;

        public ProductDetailsClient(string serverUrl)
        {
            channel = GrpcChannel.ForAddress(serverUrl);
            client = new ProductDetails.ProductDetailsClient(channel);
        }

        public async Task<Product> GetProduct(int productId)
        {
            var response = await client.GetProductAsync(new ProductRequest { Id = productId });

            return new Product
            {
                Id = productId,
                Name = response.Name,
                Description = response.Description,
                CategoryId = response.CategoryId
            };
        }

        public async Task<IList<Product>> GetCategoryProducts(IList<int> categoryIds)
        {
            using var call = client.GetCategoryProducts();
            foreach (var id in categoryIds)
            {
                await call.RequestStream.WriteAsync(new CatergoryRequest { Id = id });
            }
            await call.RequestStream.CompleteAsync();
 
            var products = new List<Product>();            
            while (await call.ResponseStream.MoveNext())
            {
                var current = call.ResponseStream.Current;
                products.Add(new Product{
                    Id = current.Id,
                    Name = current.Name,
                    Description = current.Description,
                    CategoryId = current.CategoryId
                });
            }
            return products;
        }

        public void Dispose()
        {
            channel.Dispose();
        }
    }
}