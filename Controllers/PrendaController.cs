using Repositories;
using Microsoft.AspNetCore.Mvc;
using Models;
using DTOs;

namespace Controllers;

[Route("api/[controller]")]
[ApiController]
public class PrendaController : ControllerBase
{
    private readonly IPrendaRepository _repository;
    public PrendaController(IPrendaRepository repository)
    {
        _repository = repository;
    }
    [HttpGet]
    public async Task<ActionResult<List<Prenda>>> GetAll(
        [FromQuery] string? categoria, 
        [FromQuery] bool? esImpermeable, 
        [FromQuery] bool? precioAscendente)
    {
        var prendas = await _repository.GetAllAsync();

        if (!string.IsNullOrWhiteSpace(categoria))
        {
            prendas = prendas.Where(p => p.Categoria.Equals(categoria, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        if (esImpermeable.HasValue)
        {
            prendas = prendas.Where(p => p.EsImpermeable == esImpermeable.Value).ToList();
        }

        if (precioAscendente.HasValue)
        {
            if (precioAscendente.Value)
            {
                prendas = prendas.OrderBy(p => p.Precio).ToList();
            }
            else
            {
                prendas = prendas.OrderByDescending(p => p.Precio).ToList();
            }
        }

        return Ok(prendas);
    }
    [HttpGet("{id}")]
    public async Task<ActionResult<Prenda>> GetById([FromRoute] int id)
    {
        var prenda = await _repository.GetByIdAsync(id);
        if (prenda == null)
        {
            return NotFound();
        }
        return Ok(prenda);
    }
    [HttpPost]
    public async Task<ActionResult<Prenda>> Create([FromBody] CreatePrendaDto dto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var nuevaPrenda = new Prenda
        {
            Nombre = dto.Nombre,
            Categoria = dto.Categoria,
            Precio = dto.Precio,
            Stock = dto.Stock,
            EsImpermeable = dto.EsImpermeable
        };

        await _repository.AddAsync(nuevaPrenda);
        return CreatedAtAction(nameof(GetById), new { id = nuevaPrenda.Id }, nuevaPrenda);
    }
    [HttpPut("{id}")]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] CreatePrendaDto dto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var aprenda = await _repository.GetByIdAsync(id);
        if (aprenda == null)
        {
            return NotFound();
        }

        aprenda.Nombre = dto.Nombre;
        aprenda.Categoria = dto.Categoria;
        aprenda.Precio = dto.Precio;
        aprenda.Stock = dto.Stock;
        aprenda.EsImpermeable = dto.EsImpermeable;

        await _repository.UpdateAsync(aprenda);
        return NoContent();
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var prenda = await _repository.GetByIdAsync(id);
        if (prenda == null)
        {
            return NotFound();
        }
        await _repository.DeleteAsync(id);
        return NoContent();
    }
}