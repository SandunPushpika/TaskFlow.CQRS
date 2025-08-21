namespace Domain.DTOs.Requests;

public class TaskCreateRequest
{
    public string AssignedUser { get; set; }
    public string Name {get;set;}
    public string Description {get;set;}
}