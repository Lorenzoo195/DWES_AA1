namespace Repositories;
using Models;
public interface IPrendaRepository
{
        Task<List<Prenda>> GetAllAsync();
        Task<Prenda?> GetByIdAsync(int id);
        Task AddAsync(Prenda prenda);
        Task UpdateAsync(Prenda prenda);
        Task DeleteAsync(int id);
}