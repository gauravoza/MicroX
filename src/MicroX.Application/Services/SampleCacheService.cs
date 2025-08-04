using MicroX.Application.Interfaces;

namespace MicroX.Application.App.Services
{
    public class SampleCacheService
    {
        private readonly IRedisCacheService _redis;

        public SampleCacheService(IRedisCacheService redis)
        {
            _redis = redis;
        }

        public async Task<string> GetGreetingFromCache()
        {
            var value = await _redis.GetAsync("microx:greeting");
            return value ?? "Cache Miss";
        }
    }
}
