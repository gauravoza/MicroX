using MicroX.Contracts.DTOs;

namespace MicroX.Application.Interfaces;

public interface IServiceInfoService
{
    IEnumerable<ServiceInfoDto> GetAll();
    void Add(ServiceInfoDto dto);
}
