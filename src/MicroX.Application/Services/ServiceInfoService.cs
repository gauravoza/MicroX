using Microsoft.Extensions.Logging;
using MicroX.Application.Interfaces;
using MicroX.Contracts.DTOs;
using MicroX.Domain.Entities;

public class ServiceInfoService : IServiceInfoService
{
    private readonly ILogger<ServiceInfoService> _logger;
    private readonly IServiceInfoRepository _repository;

    public ServiceInfoService(IServiceInfoRepository repository, ILogger<ServiceInfoService> logger)
    {
        _repository = repository;
        _logger = logger;
    }

    public IEnumerable<ServiceInfoDto> GetAll()
    {
        return _repository.GetAll().Select(e => new ServiceInfoDto
        {
            Name = e.Name,
            Version = e.Version,
            Status = e.Status,
            LastChecked = e.LastChecked
        });
    }

    public void Add(ServiceInfoDto dto)
    {
        _logger.LogInformation("Adding new service info for service: {ServiceName}", dto.Name);

        var entity = new ServiceInfo
        {
            Name = dto.Name,
            Version = dto.Version,
            Status = dto.Status,
            LastChecked = dto.LastChecked
        };

        _repository.Add(entity);
    }
}
