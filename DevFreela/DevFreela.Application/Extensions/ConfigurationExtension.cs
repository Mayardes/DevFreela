using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace DevFreela.Application.Extensions;

public static class ConfigurationExtension
{
    public static IServiceCollection AddMediatorExtensions(this IServiceCollection services)
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
        return services;
    }
}