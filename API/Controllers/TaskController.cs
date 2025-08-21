using Application.Commands;
using Application.Commands.DeleteTaskCommand;
using Application.Queries.GetAllTasksQuery;
using Application.Queries.GetTaskByUserQuery;
using Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace TaskFlow.CQRS.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TaskController: ControllerBase
{
    private readonly IMediator _mediator;

    public TaskController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateTask([FromBody] CreateTaskCommand request)
    {
        await _mediator.Send(request);
        return Ok("Created a Task");
    }

    [HttpGet]
    public async Task<IActionResult> GetTasks()
    {
        var result = await _mediator.Send<TaskModel[]>(new GetAllTaskQuery());
        return Ok(result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTask(int id)
    {
        await _mediator.Send(new DeleteTaskCommand() { Id = id });
        return Ok("Task deleted");
    }

    [HttpGet("get-by-user/{user}")]
    public async Task<IActionResult> GetTasksByUser(string user)
    {
        var result = await _mediator.Send(new GetTaskByUserQuery(user));
        return Ok(result);
    }
}