namespace Repositories;
using Models;
using Microsoft.Data.SqlClient;

public class PrendaRepository : IPrendaRepository
{
    private readonly string _connectionString;
    public PrendaRepository(string connectionString)
        {
            _connectionString = connectionString;
        }
    
     public async Task<List<Prenda>> GetAllAsync()
        {
            var prendas = new List<Prenda>();

            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                string query = "SELECT Id, Nombre,Categoria, Precio, Stock, EsImpermeable FROM Prendas";
                using (var command = new SqlCommand(query, connection))
                {
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            var prenda = new Prenda
                            {
                            Id = reader.GetInt32(0),
                            Nombre = reader.GetString(1),
                            Categoria = reader.GetString(2),
                            Precio = reader.GetDecimal(3),
                            Stock = reader.GetInt32(4),
                            EsImpermeable = reader.GetBoolean(5)
                            }; 

                            prendas.Add(prenda);
                        }
                    }
                }
            }
            return prendas;
        }
        public async Task<Prenda?> GetByIdAsync(int id)
        {
            Prenda? prenda = null;

            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                string query = "SELECT Id, Nombre,Categoria, Precio, Stock, EsImpermeable FROM Prendas WHERE Id = @Id";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            prenda = new Prenda
                            {
                                 Id = reader.GetInt32(0),
                                Nombre = reader.GetString(1),
                                Categoria = reader.GetString(2),
                                Precio = reader.GetDecimal(3),
                                Stock = reader.GetInt32(4),
                                EsImpermeable = reader.GetBoolean(5)
                            };
                        }
                    }
                }
            }
            return prenda;
        }
        public async Task AddAsync(Prenda prenda)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                string query = "INSERT INTO Prendas (Nombre,Categoria, Precio, Stock, EsImpermeable) VALUES (@Nombre,@Categoria, @Precio, @Stock, @EsImpermeable)";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Nombre", prenda.Nombre);
                    command.Parameters.AddWithValue("@Categoria", prenda.Categoria);
                    command.Parameters.AddWithValue("@Precio", prenda.Precio);
                    command.Parameters.AddWithValue("@Stock", prenda.Stock);
                    command.Parameters.AddWithValue("@EsImpermeable", prenda.EsImpermeable);
                    

                    await command.ExecuteNonQueryAsync();
                }
            }
        }
        public async Task UpdateAsync(Prenda prenda)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                string query = "UPDATE Prendas SET Nombre = @Nombre, Categoria = @Categoria, Precio = @Precio, Stock = @Stock, EsImpermeable = @EsImpermeable WHERE Id = @Id";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", prenda.Id);
                    command.Parameters.AddWithValue("@Nombre", prenda.Nombre);
                    command.Parameters.AddWithValue("@Categoria", prenda.Categoria);
                    command.Parameters.AddWithValue("@Precio", prenda.Precio);
                    command.Parameters.AddWithValue("@Stock", prenda.Stock);
                    command.Parameters.AddWithValue("@EsImpermeable", prenda.EsImpermeable);

                    await command.ExecuteNonQueryAsync();
                }
            }
        }
        public async Task DeleteAsync(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                string query = "DELETE FROM Prendas WHERE Id = @Id";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);

                    await command.ExecuteNonQueryAsync();
                }
            }
        }

}