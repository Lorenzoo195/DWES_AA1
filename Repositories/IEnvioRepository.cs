namespace Repositories;

using Models;

public interface IEnvioRepository
{
    Task<List<Envio>> GetAllAsync();
    Task<Envio?> GetByIdAsync(int id);
    Task<List<Envio>> GetByPedidoIdAsync(int pedidoId);
    Task AddAsync(Envio envio);
    Task UpdateAsync(Envio envio);
    Task DeleteAsync(int id);
}
