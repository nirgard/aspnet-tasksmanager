using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TasksAPI.Data;
using Task = TasksAPI.Models.Task;

namespace TasksAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TasksController : ControllerBase
{
    private readonly ILogger<TasksController> _logger;
    private readonly DataContext _context;

    public TasksController(ILogger<TasksController> logger, DataContext context)
    {
        _logger = logger;
        _context = context;
    }

    [HttpGet(Name = "GetTasks")]
    public async Task<ActionResult<IEnumerable<Task>>> GetTasks()
    {
        var tasks = await _context.Tasks.ToListAsync();

        return Ok(tasks);
    }

    [HttpGet("{id}", Name = "GetTask")]
    public async Task<ActionResult<Task>> GetTask(int id)
    {
        var task = await _context.Tasks.FindAsync(id);

        if (task == null)
        {
            return NotFound();
        }

        return Ok(task);
    }

    [HttpPost]
    public async Task<ActionResult<Task>> Post(Task task)
    {
        _context.Tasks.Add(task);
        await _context.SaveChangesAsync();

        return new CreatedAtRouteResult("GetTask", new { id = task.Id }, task);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Put(int id, Task task)
    {   
        if (id != task.Id)
        {
            return BadRequest();
        }

        _context.Entry(task).State = EntityState.Modified;
        await _context.SaveChangesAsync();

        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<Task>> Delete(int id)
    {
        var task = await _context.Tasks.FindAsync(id);

        if (task == null)
        {
            return NotFound();
        }

        _context.Tasks.Remove(task);
        await _context.SaveChangesAsync();

        return Ok();
    }
}
