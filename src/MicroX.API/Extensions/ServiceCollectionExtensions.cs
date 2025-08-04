using FluentValidation;
using FluentValidation.AspNetCore;
using MicroX.Application.Interfaces;
using MicroX.Application.Validators;
using MicroX.Infrastructure.Repositories;
using MicroX.Infrastructure.Services;

namespace MicroX.API.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddMicroXServices(this IServiceCollection services)
    {
        services.AddScoped<IServiceInfoService, ServiceInfoService>();
        services.AddScoped<IServiceInfoRepository, InMemoryServiceInfoRepository>();

        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<IProductService, ProductService>();

        services.AddValidatorsFromAssemblyContaining<ServiceInfoDtoValidator>();
        services.AddFluentValidationAutoValidation();

        return services;
    }
}
