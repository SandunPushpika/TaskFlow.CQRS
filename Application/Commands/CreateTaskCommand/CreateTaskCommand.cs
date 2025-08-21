using Domain.Models;
using MediatR;

namespace Application.Commands;

public class CreateTaskCommand : IRequest
{
    public string AssignedUser { get; set; }
    public string Name {get;set;}
    public string Description {get;set;}
}