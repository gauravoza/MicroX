using System;
using System.Threading.Tasks;
using MicroX.Application.Interfaces;
using MicroX.Infrastructure.Services;
using Moq;
using StackExchange.Redis;
using Xunit;

namespace MicroX.Tests.Services
{
    public class RedisCacheServiceTests
    {
        private readonly Mock<IDatabase> _mockDb;
        private readonly Mock<IConnectionMultiplexer> _mockConnectionMultiplexer;
        private readonly RedisCacheService _service;

        public RedisCacheServiceTests()
        {
            _mockDb = new Mock<IDatabase>();
            _mockConnectionMultiplexer = new Mock<IConnectionMultiplexer>();

            _mockConnectionMultiplexer
                .Setup(c => c.GetDatabase(It.IsAny<int>(), It.IsAny<object>()))
                .Returns(_mockDb.Object);

            _service = new RedisCacheService(_mockConnectionMultiplexer.Object);
        }

        [Fact]
        public async Task GetAsync_ShouldReturnValue_WhenKeyExists()
        {
            // Arrange
            var key = "test:key";
            var expectedValue = "cached-value";

            _mockDb
                .Setup(db => db.StringGetAsync(key, It.IsAny<CommandFlags>()))
                .ReturnsAsync(expectedValue);

            // Act
            var result = await _service.GetAsync(key);

            // Assert
            Assert.Equal(expectedValue, result);
        }

        // [Fact]
        // public async Task SetAsync_ShouldStoreValueInRedis()
        // {
        //     // Arrange
        //     var key = "test:key";
        //     var value = "test-value";
        //     var expiry = TimeSpan.FromMinutes(10);

        //     _mockDb
        //         .Setup(db => db.StringSetAsync(key, value, expiry, When.Always, CommandFlags.None))
        //         .ReturnsAsync(true);

        //     // Act
        //     await _service.SetAsync(key, value, expiry);

        //     // Assert
        //     _mockDb.Verify(db =>
        //         db.StringSetAsync(key, value, expiry, When.Always, CommandFlags.None),
        //         Times.Once);
        // }

        [Fact]
        public async Task RemoveAsync_ShouldDeleteKeyFromRedis()
        {
            // Arrange
            var key = "test:key";

            _mockDb
                .Setup(db => db.KeyDeleteAsync(key, CommandFlags.None))
                .ReturnsAsync(true);

            // Act
            await _service.RemoveAsync(key);

            // Assert
            _mockDb.Verify(db => db.KeyDeleteAsync(key, CommandFlags.None), Times.Once);
        }
    }
}
