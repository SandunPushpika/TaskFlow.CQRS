using Domain.Models;
using Infrastructure.Repository;
using MediatR;

namespace Application.Queries.GetAllTasksQuery;

public class GetAllTaskQueryHandler : IRequestHandler<GetAllTaskQuery, TaskModel[]>
{
    
    private readonly ITaskRepository _repository;

    public GetAllTaskQueryHandler(ITaskRepository repository)
    {
        _repository = repository;
    }
    
    public async Task<TaskModel[]> Handle(GetAllTaskQuery request, CancellationToken cancellationToken)
    {
        var res = await _repository.GetAllTasks();
        return res.ToArray();
    }
}