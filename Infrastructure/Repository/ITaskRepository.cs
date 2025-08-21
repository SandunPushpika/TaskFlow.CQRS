using Domain.DTOs.Requests;
using Domain.Models;

namespace Infrastructure.Repository;

public interface ITaskRepository
{
    Task AddTask(TaskCreateRequest createRequest);
    Task DeleteTask(int id);
    Task<List<TaskModel>> GetAllTasks();
    Task<TaskModel?> GetTaskById(int id);
    Task<TaskModel[]> GetTasksByUser(string user);
}