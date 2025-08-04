using Xunit;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using MicroX.Domain.Entities;
using MicroX.Infrastructure.Services;

namespace MicroX.Tests.Services
{
    public class ProductServiceTests
    {
        private readonly ProductService _service;

        public ProductServiceTests()
        {
            _service = new ProductService();
        }

        [Fact]
        public async Task CreateAsync_ShouldAddProduct()
        {
            // Arrange
            var product = new Product { Name = "Test Product", Price = 100 };

            // Act
            var created = await _service.CreateAsync(product);
            var allProducts = await _service.GetAllAsync();

            // Assert
            Assert.NotEqual(Guid.Empty, created.Id);
            Assert.Contains(allProducts, p => p.Id == created.Id);
        }

        [Fact]
        public async Task GetAllAsync_ShouldReturnAllProducts()
        {
            // Arrange
            var p1 = await _service.CreateAsync(new Product { Name = "A", Price = 10 });
            var p2 = await _service.CreateAsync(new Product { Name = "B", Price = 20 });

            // Act
            var result = await _service.GetAllAsync();

            // Assert
            Assert.Equal(2, result.Count());
        }

        [Fact]
        public async Task GetByIdAsync_ShouldReturnCorrectProduct()
        {
            // Arrange
            var created = await _service.CreateAsync(new Product { Name = "Test", Price = 99 });

            // Act
            var result = await _service.GetByIdAsync(created.Id);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Test", result?.Name);
        }

        [Fact]
        public async Task UpdateAsync_ShouldReturnTrueWhenSuccessful()
        {
            // Arrange
            var created = await _service.CreateAsync(new Product { Name = "Old", Price = 50 });
            created.Name = "Updated";
            created.Price = 150;

            // Act
            var success = await _service.UpdateAsync(created);
            var updated = await _service.GetByIdAsync(created.Id);

            // Assert
            Assert.True(success);
            Assert.Equal("Updated", updated?.Name);
            Assert.Equal(150, updated?.Price);
        }

        [Fact]
        public async Task UpdateAsync_ShouldReturnFalseWhenProductNotFound()
        {
            // Arrange
            var nonExisting = new Product { Id = Guid.NewGuid(), Name = "Ghost", Price = 0 };

            // Act
            var result = await _service.UpdateAsync(nonExisting);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public async Task DeleteAsync_ShouldRemoveProduct()
        {
            // Arrange
            var created = await _service.CreateAsync(new Product { Name = "To Delete", Price = 10 });

            // Act
            var deleted = await _service.DeleteAsync(created.Id);
            var retrieved = await _service.GetByIdAsync(created.Id);

            // Assert
            Assert.True(deleted);
            Assert.Null(retrieved);
        }

        [Fact]
        public async Task DeleteAsync_ShouldReturnFalseWhenProductNotFound()
        {
            // Act
            var result = await _service.DeleteAsync(Guid.NewGuid());

            // Assert
            Assert.False(result);
        }
    }
}
