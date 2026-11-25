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
    [HttpGet("{id}")]
    public async Task<ActionResult<Cliente>> GetById([FromRoute] int id)
    {
        var cliente = await _repository.GetByIdAsync(id);
        if (cliente == null)
        {
            return NotFound();
        }
        return Ok(cliente);
    }
    [HttpPost]
    public async Task<ActionResult<Cliente>> Create([FromBody] CreateClienteDto dto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var nuevoCliente = new Cliente
        {
            Nombre = dto.Nombre,
            Email = dto.Email,
            EsSocioClub = dto.EsSocioClub
        };
        await _repository.AddAsync(nuevoCliente);
        return CreatedAtAction(nameof(GetById), new { id = nuevoCliente.Id }, nuevoCliente);
    }
    
}