namespace Repositories;

using Models;
using Microsoft.Data.SqlClient;

public class ClienteRepository : IClienteRepository
{
    private readonly string _connectionString;

    public ClienteRepository(string connectionString)
    {
        _connectionString = connectionString;
    }

    public async Task<List<Cliente>> GetAllAsync()
    {
        var clientes = new List<Cliente>();

        using (var connection = new SqlConnection(_connectionString))
        {
            await connection.OpenAsync();

            string query = "SELECT Id, Nombre, Email, EsSocioClub FROM Clientes";
            using (var command = new SqlCommand(query, connection))
            {
                using (var reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        var cliente = new Cliente
                        {
                            Id = reader.GetInt32(0),
                            Nombre = reader.GetString(1),
                            Email = reader.GetString(2),
                            EsSocioClub = reader.GetBoolean(3)
                        };

                        clientes.Add(cliente);
                    }
                }
            }
        }
        return clientes;
    }

    public async Task<Cliente?> GetByIdAsync(int id)
    {
        Cliente? cliente = null;

        using (var connection = new SqlConnection(_connectionString))
        {
            await connection.OpenAsync();

            string query = "SELECT Id, Nombre, Email, EsSocioClub FROM Clientes WHERE Id = @Id";
            using (var command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Id", id);

                using (var reader = await command.ExecuteReaderAsync())
                {
                    if (await reader.ReadAsync())
                    {
                        cliente = new Cliente
                        {
                            Id = reader.GetInt32(0),
                            Nombre = reader.GetString(1),
                            Email = reader.GetString(2),
                            EsSocioClub = reader.GetBoolean(3)
                        };
                    }
                }
            }
        }
        return cliente;
    }

    public async Task AddAsync(Cliente cliente)
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            await connection.OpenAsync();

            string query = "INSERT INTO Clientes (Nombre, Email, EsSocioClub) VALUES (@Nombre, @Email, @EsSocioClub)";
            using (var command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Nombre", cliente.Nombre);
                command.Parameters.AddWithValue("@Email", cliente.Email);
                command.Parameters.AddWithValue("@EsSocioClub", cliente.EsSocioClub);

                await command.ExecuteNonQueryAsync();
            }
        }
    }

    public async Task UpdateAsync(Cliente cliente)
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            await connection.OpenAsync();

            string query = "UPDATE Clientes SET Nombre = @Nombre, Email = @Email, EsSocioClub = @EsSocioClub WHERE Id = @Id";
            using (var command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Id", cliente.Id);
                command.Parameters.AddWithValue("@Nombre", cliente.Nombre);
                command.Parameters.AddWithValue("@Email", cliente.Email);
                command.Parameters.AddWithValue("@EsSocioClub", cliente.EsSocioClub);

                await command.ExecuteNonQueryAsync();
            }
        }
    }

    public async Task DeleteAsync(int id)
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            await connection.OpenAsync();

            string query = "DELETE FROM Clientes WHERE Id = @Id";
            using (var command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Id", id);

                await command.ExecuteNonQueryAsync();
            }
        }
    }
}
