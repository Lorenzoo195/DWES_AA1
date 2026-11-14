namespace Repositories;

using Models;
using Microsoft.Data.SqlClient;

public class EnvioRepository : IEnvioRepository
{
    private readonly string _connectionString;

    public EnvioRepository(string connectionString)
    {
        _connectionString = connectionString;
    }

    public async Task<List<Envio>> GetAllAsync()
    {
        var envios = new List<Envio>();

        using (var connection = new SqlConnection(_connectionString))
        {
            await connection.OpenAsync();

            string query = "SELECT Id, Empresa, FechaEnvio, Coste, Entregado, PedidoId FROM Envios";
            using (var command = new SqlCommand(query, connection))
            {
                using (var reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        var envio = new Envio
                        {
                            Id = reader.GetInt32(0),
                            Empresa = reader.GetString(1),
                            FechaEnvio = reader.GetDateTime(2),
                            Coste = reader.GetDecimal(3),
                            Entregado = reader.GetBoolean(4),
                            PedidoId = reader.GetInt32(5)
                        };

                        envios.Add(envio);
                    }
                }
            }
        }
        return envios;
    }

    public async Task<Envio?> GetByIdAsync(int id)
    {
        Envio? envio = null;

        using (var connection = new SqlConnection(_connectionString))
        {
            await connection.OpenAsync();

            string query = "SELECT Id, Empresa, FechaEnvio, Coste, Entregado, PedidoId FROM Envios WHERE Id = @Id";
            using (var command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Id", id);

                using (var reader = await command.ExecuteReaderAsync())
                {
                    if (await reader.ReadAsync())
                    {
                        envio = new Envio
                        {
                            Id = reader.GetInt32(0),
                            Empresa = reader.GetString(1),
                            FechaEnvio = reader.GetDateTime(2),
                            Coste = reader.GetDecimal(3),
                            Entregado = reader.GetBoolean(4),
                            PedidoId = reader.GetInt32(5)
                        };
                    }
                }
            }
        }
        return envio;
    }

    public async Task<List<Envio>> GetByPedidoIdAsync(int pedidoId)
    {
        var envios = new List<Envio>();

        using (var connection = new SqlConnection(_connectionString))
        {
            await connection.OpenAsync();

            string query = "SELECT Id, Empresa, FechaEnvio, Coste, Entregado, PedidoId FROM Envios WHERE PedidoId = @PedidoId";
            using (var command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@PedidoId", pedidoId);

                using (var reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        var envio = new Envio
                        {
                            Id = reader.GetInt32(0),
                            Empresa = reader.GetString(1),
                            FechaEnvio = reader.GetDateTime(2),
                            Coste = reader.GetDecimal(3),
                            Entregado = reader.GetBoolean(4),
                            PedidoId = reader.GetInt32(5)
                        };

                        envios.Add(envio);
                    }
                }
            }
        }
        return envios;
    }

    public async Task AddAsync(Envio envio)
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            await connection.OpenAsync();

            string query = "INSERT INTO Envios (Empresa, FechaEnvio, Coste, Entregado, PedidoId) VALUES (@Empresa, @FechaEnvio, @Coste, @Entregado, @PedidoId)";
            using (var command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Empresa", envio.Empresa);
                command.Parameters.AddWithValue("@FechaEnvio", envio.FechaEnvio);
                command.Parameters.AddWithValue("@Coste", envio.Coste);
                command.Parameters.AddWithValue("@Entregado", envio.Entregado);
                command.Parameters.AddWithValue("@PedidoId", envio.PedidoId);

                await command.ExecuteNonQueryAsync();
            }
        }
    }

    public async Task UpdateAsync(Envio envio)
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            await connection.OpenAsync();

            string query = "UPDATE Envios SET Empresa = @Empresa, FechaEnvio = @FechaEnvio, Coste = @Coste, Entregado = @Entregado, PedidoId = @PedidoId WHERE Id = @Id";
            using (var command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Id", envio.Id);
                command.Parameters.AddWithValue("@Empresa", envio.Empresa);
                command.Parameters.AddWithValue("@FechaEnvio", envio.FechaEnvio);
                command.Parameters.AddWithValue("@Coste", envio.Coste);
                command.Parameters.AddWithValue("@Entregado", envio.Entregado);
                command.Parameters.AddWithValue("@PedidoId", envio.PedidoId);

                await command.ExecuteNonQueryAsync();
            }
        }
    }

    public async Task DeleteAsync(int id)
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            await connection.OpenAsync();

            string query = "DELETE FROM Envios WHERE Id = @Id";
            using (var command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Id", id);

                await command.ExecuteNonQueryAsync();
            }
        }
    }
}
