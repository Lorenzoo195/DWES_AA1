namespace Repositories;

using Models;
using Microsoft.Data.SqlClient;

public class PedidoRepository : IPedidoRepository
{
    private readonly string _connectionString;

    public PedidoRepository(string connectionString)
    {
        _connectionString = connectionString;
    }

    public async Task<List<Pedido>> GetAllAsync()
    {
        var pedidos = new List<Pedido>();

        using (var connection = new SqlConnection(_connectionString))
        {
            await connection.OpenAsync();

            string query = "SELECT Id, Codigo, Fecha, Total, Pagado, ClienteId FROM Pedidos";
            using (var command = new SqlCommand(query, connection))
            {
                using (var reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        var pedido = new Pedido
                        {
                            Id = reader.GetInt32(0),
                            Codigo = reader.GetString(1),
                            Fecha = reader.GetDateTime(2),
                            Total = reader.GetDecimal(3),
                            Pagado = reader.GetBoolean(4),
                            ClienteId = reader.GetInt32(5)
                        };

                        pedidos.Add(pedido);
                    }
                }
            }
        }
        return pedidos;
    }

    public async Task<Pedido?> GetByIdAsync(int id)
    {
        Pedido? pedido = null;

        using (var connection = new SqlConnection(_connectionString))
        {
            await connection.OpenAsync();

            string query = "SELECT Id, Codigo, Fecha, Total, Pagado, ClienteId FROM Pedidos WHERE Id = @Id";
            using (var command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Id", id);

                using (var reader = await command.ExecuteReaderAsync())
                {
                    if (await reader.ReadAsync())
                    {
                        pedido = new Pedido
                        {
                            Id = reader.GetInt32(0),
                            Codigo = reader.GetString(1),
                            Fecha = reader.GetDateTime(2),
                            Total = reader.GetDecimal(3),
                            Pagado = reader.GetBoolean(4),
                            ClienteId = reader.GetInt32(5)
                        };
                    }
                }
            }
        }
        return pedido;
    }

    public async Task<List<Pedido>> GetByClienteIdAsync(int clienteId)
    {
        var pedidos = new List<Pedido>();

        using (var connection = new SqlConnection(_connectionString))
        {
            await connection.OpenAsync();

            string query = "SELECT Id, Codigo, Fecha, Total, Pagado, ClienteId FROM Pedidos WHERE ClienteId = @ClienteId";
            using (var command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@ClienteId", clienteId);

                using (var reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        var pedido = new Pedido
                        {
                            Id = reader.GetInt32(0),
                            Codigo = reader.GetString(1),
                            Fecha = reader.GetDateTime(2),
                            Total = reader.GetDecimal(3),
                            Pagado = reader.GetBoolean(4),
                            ClienteId = reader.GetInt32(5)
                        };

                        pedidos.Add(pedido);
                    }
                }
            }
        }
        return pedidos;
    }

    public async Task AddAsync(Pedido pedido)
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            await connection.OpenAsync();

            string query = "INSERT INTO Pedidos (Codigo, Fecha, Total, Pagado, ClienteId) VALUES (@Codigo, @Fecha, @Total, @Pagado, @ClienteId)";
            using (var command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Codigo", pedido.Codigo);
                command.Parameters.AddWithValue("@Fecha", pedido.Fecha);
                command.Parameters.AddWithValue("@Total", pedido.Total);
                command.Parameters.AddWithValue("@Pagado", pedido.Pagado);
                command.Parameters.AddWithValue("@ClienteId", pedido.ClienteId);

                await command.ExecuteNonQueryAsync();
            }
        }
    }

    public async Task UpdateAsync(Pedido pedido)
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            await connection.OpenAsync();

            string query = "UPDATE Pedidos SET Codigo = @Codigo, Fecha = @Fecha, Total = @Total, Pagado = @Pagado, ClienteId = @ClienteId WHERE Id = @Id";
            using (var command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Id", pedido.Id);
                command.Parameters.AddWithValue("@Codigo", pedido.Codigo);
                command.Parameters.AddWithValue("@Fecha", pedido.Fecha);
                command.Parameters.AddWithValue("@Total", pedido.Total);
                command.Parameters.AddWithValue("@Pagado", pedido.Pagado);
                command.Parameters.AddWithValue("@ClienteId", pedido.ClienteId);

                await command.ExecuteNonQueryAsync();
            }
        }
    }

    public async Task DeleteAsync(int id)
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            await connection.OpenAsync();

            string query = "DELETE FROM Pedidos WHERE Id = @Id";
            using (var command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Id", id);

                await command.ExecuteNonQueryAsync();
            }
        }
    }
}
