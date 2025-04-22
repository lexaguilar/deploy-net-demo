using Microsoft.AspNetCore.Mvc;
using TaskManagerAPI.Core.Application.Interfaces;
using TaskManagerAPI.Core.Domain.Entities;

namespace TaskManagerAPI.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ClientesController : ControllerBase
{
     private readonly IClienteService _clienteService;
    private readonly ILogger<ClientesController> _logger;

    public ClientesController(IClienteService clienteService, ILogger<ClientesController> logger)
    {
        _clienteService = clienteService;
        _logger = logger;
    }
    [HttpPost]
    public async Task<ActionResult<Cliente>> CreateCliente([FromBody] Cliente cliente)
    {
        // SonarQube: S2077 - Formatting strings used as SQL queries
        // No hay validación de los datos de entrada
        await _clienteService.AddClienteAsync(cliente);
        return new JsonResult(cliente)
        {
            StatusCode = StatusCodes.Status201Created
        };
    }
}