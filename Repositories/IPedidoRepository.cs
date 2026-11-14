namespace Repositories;

using Models;

public interface IPedidoRepository
{
    Task<List<Pedido>> GetAllAsync();
    Task<Pedido?> GetByIdAsync(int id);
    Task<List<Pedido>> GetByClienteIdAsync(int clienteId);
    Task AddAsync(Pedido pedido);
    Task UpdateAsync(Pedido pedido);
    Task DeleteAsync(int id);
}
