using Repositories;
using Microsoft.AspNetCore.Mvc;
using Models;
using DTOs;

namespace Controllers;

[Route("api/[controller]")]
[ApiController]
public class PedidoController : ControllerBase
{
    private readonly IPedidoRepository _pedidoRepository;
    private readonly ILineaPedidoRepository _lineaRepository;
    private readonly IEnvioRepository _envioRepository;

    public PedidoController(
        IPedidoRepository pedidoRepository,
        ILineaPedidoRepository lineaRepository,
        IEnvioRepository envioRepository)
    {
        _pedidoRepository = pedidoRepository;
        _lineaRepository = lineaRepository;
        _envioRepository = envioRepository;
    }

    [HttpGet]
    public async Task<ActionResult<List<Pedido>>> GetAll([FromQuery] PedidoFilters filter)
    {
        var pedidos = await _pedidoRepository.GetAllAsync();

        if (filter.pagado.HasValue)
        {
            pedidos = pedidos.Where(p => p.Pagado == filter.pagado.Value).ToList();
        }

        if (filter.masRecientesPrimero.HasValue)
        {
            if (filter.masRecientesPrimero.Value)
            {
                pedidos = pedidos.OrderByDescending(p => p.Fecha).ToList();
            }
            else
            {
                pedidos = pedidos.OrderBy(p => p.Fecha).ToList();
            }
        }

        return Ok(pedidos);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Pedido>> GetById([FromRoute] int id)
    {
        var pedido = await _pedidoRepository.GetByIdAsync(id);
        if (pedido == null)
        {
            return NotFound();
        }
        return Ok(pedido);
    }

    [HttpPost]
    public async Task<ActionResult<Pedido>> Create([FromBody] CreatePedidoDto dto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var nuevoPedido = new Pedido
        {
            Codigo = dto.Codigo,
            Total = dto.Total,
            Pagado = dto.Pagado,
            ClienteId = dto.ClienteId,
            Fecha = DateTime.Now
        };

        await _pedidoRepository.AddAsync(nuevoPedido);
        return CreatedAtAction(nameof(GetById), new { id = nuevoPedido.Id }, nuevoPedido);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] CreatePedidoDto dto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var pedido = await _pedidoRepository.GetByIdAsync(id);
        if (pedido == null)
        {
            return NotFound();
        }

        pedido.Codigo = dto.Codigo;
        pedido.Total = dto.Total;
        pedido.Pagado = dto.Pagado;
        pedido.ClienteId = dto.ClienteId;

        await _pedidoRepository.UpdateAsync(pedido);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        var pedido = await _pedidoRepository.GetByIdAsync(id);
        if (pedido == null)
        {
            return NotFound();
        }

        await _pedidoRepository.DeleteAsync(id);
        return NoContent();
    }

    [HttpGet("{id}/lineaspedido")]
    public async Task<ActionResult<List<LineaPedido>>> GetLineasPedidoByPedido([FromRoute] int id)
    {
        var pedido = await _pedidoRepository.GetByIdAsync(id);
        if (pedido == null)
        {
            return NotFound();
        }

        var lineas = await _lineaRepository.GetByPedidoIdAsync(id);
        return Ok(lineas);
    }

    [HttpGet("{id}/envios")]
    public async Task<ActionResult<List<Envio>>> GetEnviosByPedido([FromRoute] int id)
    {
        var pedido = await _pedidoRepository.GetByIdAsync(id);
        if (pedido == null)
        {
            return NotFound();
        }

        var envios = await _envioRepository.GetByPedidoIdAsync(id);
        return Ok(envios);
    }
}
