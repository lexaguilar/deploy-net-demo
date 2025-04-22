using TaskManagerAPI.Core.Domain.Entities;

namespace TaskManagerAPI.Core.Application.Interfaces;

public interface ITareaService
{
    Task<IEnumerable<Tarea>> GetAllTareasAsync();
    Task<Tarea?> GetTareaByIdAsync(int id);
    Task AddTareaAsync(Tarea tarea);
    Task UpdateTareaAsync(Tarea tarea);
    Task DeleteTareaAsync(int id);
}