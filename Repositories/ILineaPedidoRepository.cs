namespace Repositories;

using Models;

public interface ILineaPedidoRepository
{
    Task<List<LineaPedido>> GetByPedidoIdAsync(int pedidoId);
    Task<LineaPedido?> GetByIdAsync(int id);
    Task AddAsync(LineaPedido linea);
    Task DeleteAsync(int id);
}
