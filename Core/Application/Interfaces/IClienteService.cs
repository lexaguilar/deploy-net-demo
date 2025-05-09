using TaskManagerAPI.Core.Domain.Entities;

namespace TaskManagerAPI.Core.Application.Interfaces;

public interface IClienteService
{
    Task<IEnumerable<Cliente>> GetAllClientesAsync();
    Task<Cliente?> GetClienteByIdAsync(int id);
    Task AddClienteAsync(Cliente cliente);
    Task UpdateClienteAsync(Cliente cliente);
    Task DeleteClienteAsync(int id);
}