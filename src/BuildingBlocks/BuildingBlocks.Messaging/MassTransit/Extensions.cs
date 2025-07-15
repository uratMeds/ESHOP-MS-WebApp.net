using MassTransit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace BuildingBlocks.Messaging.MassTransit;

public static class Extensions
{
    public static IServiceCollection AddMessageBroker(this IServiceCollection services, IConfiguration configuration, Assembly? assembly = null)
    {
        services.AddMassTransit(x =>
        {
            x.SetKebabCaseEndpointNameFormatter();
            if (assembly is not null)
            {
                x.AddConsumers(assembly);
            }   
            x.UsingRabbitMq((context, cfg) =>
            {
                cfg.Host(new Uri(configuration["MessageBroker:Host"]!), h =>
                {
                    h.Username(configuration["MessageBroker:UserName"]!);
                    h.Password(configuration["MessageBroker:Password"]!);
                });
                cfg.ConfigureEndpoints(context);
            });
        });

        return services;
    }
}