using MicroX.Domain.Entities;

namespace MicroX.Application.Interfaces;

public interface IServiceInfoRepository
{
    IEnumerable<ServiceInfo> GetAll();
    void Add(ServiceInfo entity);
}
