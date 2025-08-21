namespace Domain.Models;

public class TaskModel
{
    public int Id {get;set;}
    public string AssignedUser {get;set;}
    public string Name {get;set;}
    public string Description {get;set;}
    public TaskStatus Status {get;set;}
}