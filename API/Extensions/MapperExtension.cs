using Application.Commands;
using Domain.DTOs.Requests;
using Domain.Models;

namespace TaskFlow.CQRS.Extensions;

public static class MapperExtension
{
    public static void AddAutoMapper(this IServiceCollection services)
    {
        services.AddAutoMapper(config =>
        {
            config.CreateMap<TaskCreateRequest, TaskModel>()
                .ReverseMap();
            config.CreateMap<CreateTaskCommand, TaskCreateRequest>()
                .ReverseMap();
        });
    }
}