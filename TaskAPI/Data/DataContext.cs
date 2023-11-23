using Microsoft.EntityFrameworkCore;
using TaskAPI.Models;
using Task = TaskAPI.Models.Task;

namespace TaskAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        public DbSet<Task> Tasks { get; set; }
    }
}