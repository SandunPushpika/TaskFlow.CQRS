using Application.Commands;
using Infrastructure.Repository;
namespace TaskFlow.CQRS.Extensions;

public static class ServiceRegistryExtension
{
    public static void AddServices(this IServiceCollection services)
    {
        services.AddScoped<ITaskRepository, TaskRepository>();

        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssemblyContaining<CreateTaskCommand>();
        });
    }
}