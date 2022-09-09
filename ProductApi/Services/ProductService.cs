using ProductApi.Model;

namespace ProductApi.Services
{
    public class ProductService : IProductService
    {
        public List<Product> Products { get; set; } = default!;

        public ProductService()
        {
            CreateProducts();
        }

        private void CreateProducts()
        {
            Products = new Product[]{
                new Product{
                    Id = 1,
                    Name = "Laptop",
                    Description = "Description of laptop",
                    CategoryId = 1},
                new Product{
                    Id = 2,
                    Name = "Tablet",
                    Description = "Description of tablet",

                    CategoryId = 1},
                new Product{
                    Id = 3,
                    Name = "Speaker",
                    Description = "Description of Speaker",
                    CategoryId = 2},
                new Product{
                    Id = 3,
                    Name = "Headphone",
                    Description = "Description of Headphone",
                    CategoryId = 2}
            }.ToList();
        }

        public async Task<IList<Product>> GetCategoryProducts(int categoryId)
        {
            return await Task.Run(() => Products.Where(p => p.CategoryId == categoryId).ToList());
        }

        public async Task<Product> GetProductById(int id)
        {
            var product = Products.FirstOrDefault(p => p.Id == id);
            return await Task.Run(() => product!);
        }
    }
}