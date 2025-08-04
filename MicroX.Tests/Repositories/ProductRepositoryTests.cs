using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Xunit;
using MicroX.Domain.Entities;
using MicroX.Infrastructure.Repositories;
using MicroX.Infrastructure;

namespace MicroX.Tests.Repositories
{
    /// <summary>
    /// Unit tests for ProductRepository using EF Core InMemory database.
    /// </summary>
    public class ProductRepositoryTests : IDisposable
    {
        private readonly ApplicationDbContext _context;
        private readonly ProductRepository _repository;

        public ProductRepositoryTests()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            _context = new ApplicationDbContext(options);
            _repository = new ProductRepository(_context);

            SeedTestData();
        }

        private void SeedTestData()
        {
            var products = new List<Product>
            {
                new Product
                {
                    Id = Guid.NewGuid(),
                    Name = "Laptop",
                    Description = "Powerful laptop",
                    Price = 1200
                },
                new Product
                {
                    Id = Guid.NewGuid(),
                    Name = "Headphones",
                    Description = "Noise-cancelling headphones",
                    Price = 300
                }
            };

            _context.Products.AddRange(products);
            _context.SaveChanges();
        }

        [Fact]
        public async Task GetAllAsync_ShouldReturnAllProducts()
        {
            var result = await _repository.GetAllAsync();

            Assert.NotNull(result);
            Assert.Equal(2, result.Count());
        }

        [Fact]
        public async Task GetByIdAsync_ShouldReturnCorrectProduct()
        {
            var seededProduct = _context.Products.First();
            var result = await _repository.GetByIdAsync(seededProduct.Id);

            Assert.NotNull(result);
            Assert.Equal(seededProduct.Name, result.Name);
        }

        [Fact]
        public async Task CreateAsync_ShouldAddProduct()
        {
            var newProduct = new Product
            {
                Name = "Tablet",
                Description = "Android Tablet",
                Price = 600
            };

            var result = await _repository.CreateAsync(newProduct);
            var saved = await _repository.GetByIdAsync(result.Id);

            Assert.NotNull(saved);
            Assert.Equal("Tablet", saved.Name);
        }

        [Fact]
        public async Task UpdateAsync_ShouldUpdateProduct()
        {
            var product = _context.Products.First();
            product.Price = 999;

            var success = await _repository.UpdateAsync(product);
            var updated = await _repository.GetByIdAsync(product.Id);

            Assert.True(success);
            Assert.Equal(999, updated.Price);
        }

        [Fact]
        public async Task DeleteAsync_ShouldDeleteProduct()
        {
            var product = _context.Products.First();
            var deleted = await _repository.DeleteAsync(product.Id);
            var result = await _repository.GetByIdAsync(product.Id);

            Assert.True(deleted);
            Assert.Null(result);
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}
