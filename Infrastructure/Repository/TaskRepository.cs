using AutoMapper;
using Domain.DTOs.Requests;
using Domain.Models;
using Infrastructure.Persistent;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository;

public class TaskRepository : ITaskRepository
{
    private DbHelper _helper;
    private IMapper _mapper;

    public TaskRepository(DbHelper helper, IMapper mapper)
    {
        _helper = helper;
        _mapper = mapper;
    }

    public async Task AddTask(TaskCreateRequest createRequest)
    {
        TaskModel model = _mapper.Map<TaskModel>(createRequest);
        await _helper.Tasks.AddAsync(model);
        await _helper.SaveChangesAsync();
    }

    public async Task DeleteTask(int id)
    {
        var task = await _helper.Tasks.FindAsync(id);
        if(task == null)
            return;
        
        _helper.Tasks.Remove(task);
        await _helper.SaveChangesAsync();
    }

    public async Task<List<TaskModel>> GetAllTasks()
    {
        var tasks = await _helper.Tasks.ToListAsync();
        return tasks;
    }

    public async Task<TaskModel?> GetTaskById(int id)
    {
        var task = await _helper.Tasks.FindAsync(id);
        return task;
    }

    public async Task<TaskModel[]> GetTasksByUser(string user)
    {
        return await _helper.Tasks
            .Where(t => t.AssignedUser.Equals(user, StringComparison.OrdinalIgnoreCase))
            .ToArrayAsync();
    }
}