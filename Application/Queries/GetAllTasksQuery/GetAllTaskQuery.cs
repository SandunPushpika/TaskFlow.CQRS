using Domain.Models;
using MediatR;

namespace Application.Queries.GetAllTasksQuery;

public class GetAllTaskQuery : IRequest<TaskModel[]>
{
    
}