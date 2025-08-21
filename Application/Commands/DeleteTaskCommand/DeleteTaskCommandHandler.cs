using Infrastructure.Repository;
using MediatR;

namespace Application.Commands.DeleteTaskCommand;

public class DeleteTaskCommandHandler : IRequestHandler<DeleteTaskCommand>
{
    private readonly ITaskRepository _repository;

    public DeleteTaskCommandHandler(ITaskRepository repository)
    {
        _repository = repository;
    }
    
    public async Task Handle(DeleteTaskCommand request, CancellationToken cancellationToken)
    {
        await _repository.DeleteTask(request.Id);
    }
}