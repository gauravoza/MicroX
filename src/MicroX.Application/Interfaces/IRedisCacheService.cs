using System;
using System.Threading.Tasks;

namespace MicroX.Application.Interfaces
{
    public interface IRedisCacheService
    {
        Task<string?> GetAsync(string key);
        Task SetAsync(string key, string value, TimeSpan? expiry = null);
        Task RemoveAsync(string key);
    }
}
