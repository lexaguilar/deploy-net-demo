using Microsoft.AspNetCore.Mvc;
using TaskManagerAPI.Core.Application.Interfaces;
using TaskManagerAPI.Core.Domain.Entities;

namespace TaskManagerAPI.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TareasController : ControllerBase
{
    private readonly ITareaService _tareaService;
    private readonly ILogger<TareasController> _logger;

    public TareasController(ITareaService tareaService, ILogger<TareasController> logger)
    {
        _tareaService = tareaService;
        _logger = logger;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Tarea>>> GetTareas()
    {
        _logger.LogInformation("Obteniendo todas las tareas");
        var tareas = await _tareaService.GetAllTareasAsync();
        return Ok(tareas);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Tarea>> GetTarea(int id)
    {
        _logger.LogInformation("Obteniendo tarea con ID: {Id}", id);
        var tarea = await _tareaService.GetTareaByIdAsync(id);

        if (tarea == null)
        {
            _logger.LogWarning("Tarea con ID: {Id} no encontrada", id);
            return NotFound();
        }

        return Ok(tarea);
    }

    [HttpPost]
    public async Task<ActionResult<Tarea>> PostTarea(Tarea tarea)
    {
        _logger.LogInformation("Creando nueva tarea");
        await _tareaService.AddTareaAsync(tarea);
        return CreatedAtAction(nameof(GetTarea), new { id = tarea.Id }, tarea);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutTarea(int id, Tarea tarea)
    {
        if (id != tarea.Id)
        {
            _logger.LogWarning("ID de tarea no coincide");
            return BadRequest();
        }

        _logger.LogInformation("Actualizando tarea con ID: {Id}", id);
        await _tareaService.UpdateTareaAsync(tarea);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTarea(int id)
    {
        _logger.LogInformation("Eliminando tarea con ID: {Id}", id);
        await _tareaService.DeleteTareaAsync(id);
        return NoContent();
    }
}