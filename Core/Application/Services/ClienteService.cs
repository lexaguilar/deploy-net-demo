// Core/Application/Services/ClienteService.cs
using TaskManagerAPI.Core.Application.Interfaces;
using TaskManagerAPI.Core.Domain.Entities;

public class ClienteService: IClienteService
{
    public Task AddClienteAsync(Cliente cliente)
    {
        throw new NotImplementedException();
    }

    public Task DeleteClienteAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Cliente>> GetAllClientesAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Cliente?> GetClienteByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public void ProcessClientData(Cliente cliente)
    {
        // 100+ líneas de código haciendo múltiples tareas
        if (cliente.Nombre != null) { /* ... */ }
        if (cliente.Email != null) { /* ... */ }
        // ... muchas más condiciones y operaciones ...
        
        // Debería dividirse en varios métodos más pequeños
    }

    public Task UpdateClienteAsync(Cliente cliente)
    {
        throw new NotImplementedException();
    }

    public void ValidateCliente(Cliente cliente)
    {
        if (string.IsNullOrEmpty(cliente.Nombre))
            throw new ArgumentException("El nombre es requerido");
        
        if (cliente.Nombre.Length > 100)
            throw new ArgumentException("El nombre es demasiado largo");
        
        // SonarQube: S4144 - Methods with similar implementations should be merged
        // La validación de longitud es duplicada
    }
}