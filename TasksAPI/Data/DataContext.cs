using Microsoft.EntityFrameworkCore;
using Task = TasksAPI.Models.Task;

namespace TasksAPI.Data;

public class DataContext(DbContextOptions<DataContext> options) : DbContext(options)
{
    public DbSet<Task> Tasks { get; set; }
}
