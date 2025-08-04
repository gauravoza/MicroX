using MicroX.Domain.Entities;
using MicroX.Application.Interfaces;

namespace MicroX.Infrastructure.Repositories;

public class InMemoryServiceInfoRepository : IServiceInfoRepository
{
    private readonly List<ServiceInfo> _store = new();

    public IEnumerable<ServiceInfo> GetAll() => _store;

    public void Add(ServiceInfo entity) => _store.Add(entity);
}

