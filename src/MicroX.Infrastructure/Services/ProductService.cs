using MicroX.Application.Interfaces;
using MicroX.Domain.Entities;

namespace MicroX.Infrastructure.Services
{
    public class ProductService : IProductService
    {
        private readonly List<Product> _products = new();

        public Task<IEnumerable<Product>> GetAllAsync()
        {
            return Task.FromResult<IEnumerable<Product>>(_products);
        }

        public Task<Product?> GetByIdAsync(Guid id)
        {
            var product = _products.FirstOrDefault(p => p.Id == id);
            return Task.FromResult(product);
        }

        public Task<Product> CreateAsync(Product product)
        {
            product.Id = Guid.NewGuid();
            _products.Add(product);
            return Task.FromResult(product);
        }

        public Task<bool> UpdateAsync(Product product)
        {
            var index = _products.FindIndex(p => p.Id == product.Id);
            if (index == -1) return Task.FromResult(false);

            _products[index] = product;
            return Task.FromResult(true);
        }

        public Task<bool> DeleteAsync(Guid id)
        {
            var product = _products.FirstOrDefault(p => p.Id == id);
            if (product == null) return Task.FromResult(false);

            _products.Remove(product);
            return Task.FromResult(true);
        }
    }
}
