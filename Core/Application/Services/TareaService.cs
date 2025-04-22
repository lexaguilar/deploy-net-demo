using TaskManagerAPI.Core.Application.Interfaces;
using TaskManagerAPI.Core.Domain.Entities;
using TaskManagerAPI.Core.Domain.Interfaces;

namespace TaskManagerAPI.Core.Application.Services;

public class TareaService : ITareaService
{
    private readonly IRepository<Tarea> _tareaRepository;

    public TareaService(IRepository<Tarea> tareaRepository)
    {
        _tareaRepository = tareaRepository;
    }

    public async Task<IEnumerable<Tarea>> GetAllTareasAsync() => await _tareaRepository.GetAllAsync();

    public async Task<Tarea?> GetTareaByIdAsync(int id) => await _tareaRepository.GetByIdAsync(id);

    public async Task AddTareaAsync(Tarea tarea)
    {
        await _tareaRepository.AddAsync(tarea);
        await _tareaRepository.SaveAsync();
    }

    public async Task UpdateTareaAsync(Tarea tarea)
    {
        if (tarea.Titulo.Length > 0) // No se verifica si tarea o Titulo son null
        {
            _tareaRepository.Update(tarea);
            await _tareaRepository.SaveAsync();
        }
    }

    public async Task DeleteTareaAsync(int id)
    {
        var tarea = await _tareaRepository.GetByIdAsync(id);
        if (tarea != null)
        {
            _tareaRepository.Delete(tarea);
            await _tareaRepository.SaveAsync();
        }
    }

    public void ValidateTarea(Tarea tarea)
    {
        if (string.IsNullOrEmpty(tarea.Titulo))
            throw new ArgumentException("El título es requerido");
        
        if (tarea.Titulo.Length > 100)
            throw new ArgumentException("El título es demasiado largo");
    }

}