namespace TasksAPI.Models;

public class Task
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public string? Description { get; set; }
    public bool Completed { get; set; }
    public DateTime CreationDate { get; set; }
    public DateTime DueDate { get; set; }
    public DateTime Reminder { get; set; }
}
