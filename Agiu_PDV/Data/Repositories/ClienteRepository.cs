using Agiu_PDV.Models;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agiu_PDV.Data.Repositories
{
    public class ClienteRepository : BaseRepository
    {
        public ClienteRepository(string connectionString) : base(connectionString) { }

        public async Task<IEnumerable<Cliente>> GetAllAsync()
        {
            var clientes = new List<Cliente>();

            using (var connection = GetConnection())
            {
                connection.Open();

                using (var command = new NpgsqlCommand("SELECT * FROM clientes", connection))
                {
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            clientes.Add(new Cliente
                            {
                                ClienteId = reader.GetInt32(0),
                                Nome = reader.GetString(1),
                                Endereco = reader.IsDBNull(2) ? null : reader.GetString(2),
                                Telefone = reader.IsDBNull(3) ? null : reader.GetString(3),
                                Email = reader.IsDBNull(4) ? null : reader.GetString(4)
                            });
                        }
                    }
                }
            }
            return clientes;
        }

        public async Task<bool> AddAsync(Cliente cliente)
        {
            using (var connection = GetConnection())
            {
                connection.Open();

                using (var command = new NpgsqlCommand("INSERT INTO clientes (nome, endereco, telefone, email) VALUES (@nome, @endereco, @telefone, @email)", connection))
                {
                    command.Parameters.AddWithValue("@nome", cliente.Nome);
                    command.Parameters.AddWithValue("@endereco", cliente.Endereco ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@telefone", cliente.Telefone ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@email", cliente.Email ?? (object)DBNull.Value);

                    var rowsAffected = await command.ExecuteNonQueryAsync();

                    return rowsAffected > 0;
                }
            }
        }

        public async Task<bool> UpdateAsync(Cliente cliente)
        {
            using (var connection = GetConnection())
            {
                connection.Open();

                using (var command = new NpgsqlCommand("UPDATE clientes SET nome = @nome, endereco = @endereco, telefone = @telefone, email = @email WHERE cliente_id = @clienteId", connection))
                {
                    command.Parameters.AddWithValue("@nome", cliente.Nome);
                    command.Parameters.AddWithValue("@endereco", cliente.Endereco ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@telefone", cliente.Telefone ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@email", cliente.Email ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@clienteId", cliente.ClienteId);

                    var rowsAffected = await command.ExecuteNonQueryAsync();

                    return rowsAffected > 0;
                }
            }
        }
        public async Task<bool> DeleteAsync(int clienteId)
        {
            using (var connection = GetConnection())
            {
                connection.Open();

                using (var command = new NpgsqlCommand("DELETE FROM clientes WHERE cliente_id = @clienteId", connection))
                {
                    command.Parameters.AddWithValue("@clienteId", clienteId);

                    int rowsAffected = await command.ExecuteNonQueryAsync();
                    return rowsAffected > 0;
                }
            }
        }

        public async Task<Cliente> GetByIdAsync(int clienteId)
        {
            Cliente cliente = null;

            using (var connection = GetConnection())
            {
                connection.Open();

                using (var command = new NpgsqlCommand("SELECT cliente_id, nome, endereco, telefone, email FROM clientes WHERE cliente_id = @clienteId", connection))
                {
                    command.Parameters.AddWithValue("@clienteId", clienteId);

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            cliente = new Cliente
                            {
                                ClienteId = reader.GetInt32(0),
                                Nome = reader.GetString(1),
                                Endereco = reader.IsDBNull(2) ? null : reader.GetString(2),
                                Telefone = reader.IsDBNull(3) ? null : reader.GetString(3),
                                Email = reader.IsDBNull(4) ? null : reader.GetString(4)
                            };
                        }
                    }
                }
            }

            return cliente;
        }

        public async Task<Cliente> GetByNameAsync(string nome)
        {
            Cliente cliente = null;

            using (var connection = GetConnection())
            {
                await connection.OpenAsync();

                using (var command = new NpgsqlCommand("SELECT cliente_id, nome, endereco, telefone, email FROM clientes WHERE nome = @nome", connection))
                {
                    command.Parameters.AddWithValue("@nome", nome);

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            cliente = new Cliente
                            {
                                ClienteId = reader.GetInt32(0),
                                Nome = reader.GetString(1),
                                Endereco = reader.IsDBNull(2) ? null : reader.GetString(2),
                                Telefone = reader.IsDBNull(3) ? null : reader.GetString(3),
                                Email = reader.IsDBNull(4) ? null : reader.GetString(4)
                            };
                        }
                    }
                }
            }

            return cliente;
        }



    }
}
