using AutoMapper;
using Domain.DTOs.Requests;
using Domain.Models;
using Infrastructure.Repository;
using MediatR;

namespace Application.Commands;

public class CreateTaskCommandHandler(ITaskRepository repository, IMapper mapper) : IRequestHandler<CreateTaskCommand>
{

    public async Task Handle(CreateTaskCommand request, CancellationToken cancellationToken)
    {
        await repository.AddTask(mapper.Map<TaskCreateRequest>(request));
    }
}