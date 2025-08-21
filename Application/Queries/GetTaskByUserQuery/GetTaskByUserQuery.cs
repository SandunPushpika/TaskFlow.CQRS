using Domain.Models;
using MediatR;

namespace Application.Queries.GetTaskByUserQuery;

public class GetTaskByUserQuery : IRequest<TaskModel[]>
{
    public string User { get; set; }

    public GetTaskByUserQuery(string user)
    {
        User = user;
    }
}