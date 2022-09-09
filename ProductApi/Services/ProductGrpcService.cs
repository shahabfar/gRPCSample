using Grpc.Core;
using ProductApi;
using ProductApi.Model;

namespace ProductApi.Services
{
    public class ProductGrpcService : ProductDetails.ProductDetailsBase
    {
        private readonly IProductService _productServie;

        public ProductGrpcService(IProductService productServie)
        {
            _productServie = productServie;
        }

        public override async Task<ProductResponse> GetProduct(ProductRequest request, ServerCallContext context)
        {
            var product = await _productServie.GetProductById(request.Id);
            return await Task.FromResult(new ProductResponse
            {
                Id = request.Id,
                Name = product.Name,
                Description = product.Description,
                CategoryId = product.CategoryId
            });
        }

        public override async Task GetCategoryProducts(IAsyncStreamReader<CatergoryRequest> requestStream, IServerStreamWriter<ProductResponse> responseStream, ServerCallContext context)
        {
            var products = new List<Product>();
            while (await requestStream.MoveNext())
            {
                products.AddRange(await _productServie.GetCategoryProducts(requestStream.Current.Id));
            }

            foreach (var product in products)
            {
                await responseStream.WriteAsync(new ProductResponse
                {
                    Id = product.Id,
                    Name = product.Name,
                    Description = product.Description,
                    CategoryId = product.CategoryId
                });
            }
            //return;
        }
    }
}