namespace Repositories;

using Models;
using Microsoft.Data.SqlClient;

public class LineaPedidoRepository : ILineaPedidoRepository
{
    private readonly string _connectionString;

    public LineaPedidoRepository(string connectionString)
    {
        _connectionString = connectionString;
    }

    public async Task<List<LineaPedido>> GetByPedidoIdAsync(int pedidoId)
    {
        var lineas = new List<LineaPedido>();

        using (var connection = new SqlConnection(_connectionString))
        {
            await connection.OpenAsync();

            string query = "SELECT Id, Cantidad, PrecioUnitario, PedidoId, PrendaId FROM LineasPedido WHERE PedidoId = @PedidoId";
            using (var command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@PedidoId", pedidoId);

                using (var reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        var linea = new LineaPedido
                        {
                            Id = reader.GetInt32(0),
                            Cantidad = reader.GetInt32(1),
                            PrecioUnitario = reader.GetDecimal(2),
                            PedidoId = reader.GetInt32(3),
                            PrendaId = reader.GetInt32(4)
                        };

                        lineas.Add(linea);
                    }
                }
            }
        }
        return lineas;
    }

    public async Task<LineaPedido?> GetByIdAsync(int id)
    {
        LineaPedido? linea = null;

        using (var connection = new SqlConnection(_connectionString))
        {
            await connection.OpenAsync();

            string query = "SELECT Id, Cantidad, PrecioUnitario, PedidoId, PrendaId FROM LineasPedido WHERE Id = @Id";
            using (var command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Id", id);

                using (var reader = await command.ExecuteReaderAsync())
                {
                    if (await reader.ReadAsync())
                    {
                        linea = new LineaPedido
                        {
                            Id = reader.GetInt32(0),
                            Cantidad = reader.GetInt32(1),
                            PrecioUnitario = reader.GetDecimal(2),
                            PedidoId = reader.GetInt32(3),
                            PrendaId = reader.GetInt32(4)
                        };
                    }
                }
            }
        }
        return linea;
    }

    public async Task AddAsync(LineaPedido linea)
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            await connection.OpenAsync();

            string query = "INSERT INTO LineasPedido (Cantidad, PrecioUnitario, PedidoId, PrendaId) VALUES (@Cantidad, @PrecioUnitario, @PedidoId, @PrendaId)";
            using (var command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Cantidad", linea.Cantidad);
                command.Parameters.AddWithValue("@PrecioUnitario", linea.PrecioUnitario);
                command.Parameters.AddWithValue("@PedidoId", linea.PedidoId);
                command.Parameters.AddWithValue("@PrendaId", linea.PrendaId);

                await command.ExecuteNonQueryAsync();
            }
        }
    }

    public async Task DeleteAsync(int id)
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            await connection.OpenAsync();

            string query = "DELETE FROM LineasPedido WHERE Id = @Id";
            using (var command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Id", id);

                await command.ExecuteNonQueryAsync();
            }
        }
    }
}
