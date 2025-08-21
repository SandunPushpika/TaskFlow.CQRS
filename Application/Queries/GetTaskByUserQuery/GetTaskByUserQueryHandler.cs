using Domain.Models;
using Infrastructure.Repository;
using MediatR;

namespace Application.Queries.GetTaskByUserQuery;

public class GetTaskByUserQueryHandler : IRequestHandler<GetTaskByUserQuery, TaskModel[]>
{
    private readonly ITaskRepository _repository;

    public GetTaskByUserQueryHandler(ITaskRepository repository)
    {
        _repository = repository;
    }

    public async Task<TaskModel[]> Handle(GetTaskByUserQuery request, CancellationToken cancellationToken)
    {
        var result = await _repository.GetTasksByUser(request.User);
        return result;
    }
}