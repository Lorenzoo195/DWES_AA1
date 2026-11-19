using Repositories;
using Microsoft.AspNetCore.Mvc;
using Models;
using DTOs;

namespace Controllers;

[Route("api/[controller]")]
[ApiController]
public class ClienteController : ControllerBase
{
    private readonly IClienteRepository _repository;

    public ClienteController(IClienteRepository repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public async Task<ActionResult<List<Cliente>>> GetAll([FromQuery] bool? esSocio)
    {
        var clientes = await _repository.GetAllAsync();
        if (esSocio.HasValue)
        {
            clientes = clientes.Where(c => c.EsSocioClub == esSocio.Value).ToList();
        }
        return Ok(clientes);
    }

    
}