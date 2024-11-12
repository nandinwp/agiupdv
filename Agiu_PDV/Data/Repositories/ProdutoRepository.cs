using Agiu_PDV.Models;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agiu_PDV.Data.Repositories
{
    public class ProdutoRepository : BaseRepository
    {
        public ProdutoRepository(string connectionString) : base(connectionString) { }

        public async Task<(bool Success, IEnumerable<Produto> Produtos)> GetAllAsync()
        {
            var produtos = new List<Produto>();

            using (var connection = GetConnection())
            {
                connection.Open();

                using (var command = new NpgsqlCommand("SELECT * FROM produtos", connection))
                {
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            produtos.Add(new Produto
                            {
                                ProdutoId = reader.GetInt32(0),
                                Nome = reader.GetString(1),
                                Descricao = reader.IsDBNull(2) ? null : reader.GetString(2),
                                Preco = reader.GetDecimal(3),
                                Estoque = reader.GetInt32(4)
                            });
                        }
                    }
                }
            }

            bool success = produtos.Any();
            return (success, produtos);
        }

        public async Task<bool> AddAsync(Produto produto)
        {
            using (var connection = GetConnection())
            {
                connection.Open();

                using (var command = new NpgsqlCommand("INSERT INTO produtos (nome, descricao, preco, estoque) VALUES (@nome, @descricao, @preco, @estoque)", connection))
                {
                    command.Parameters.AddWithValue("@nome", produto.Nome);
                    command.Parameters.AddWithValue("@descricao", produto.Descricao ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@preco", produto.Preco);
                    command.Parameters.AddWithValue("@estoque", produto.Estoque);

                    int rowsAffected = await command.ExecuteNonQueryAsync();
                    return rowsAffected > 0;
                }
            }
        }

        public async Task<bool> UpdateAsync(Produto produto)
        {
            using (var connection = GetConnection())
            {
                connection.Open();

                using (var command = new NpgsqlCommand("UPDATE produtos SET nome = @nome, descricao = @descricao, preco = @preco, estoque = @estoque WHERE produto_id = @produtoId", connection))
                {
                    command.Parameters.AddWithValue("@nome", produto.Nome);
                    command.Parameters.AddWithValue("@descricao", produto.Descricao ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@preco", produto.Preco);
                    command.Parameters.AddWithValue("@estoque", produto.Estoque);
                    command.Parameters.AddWithValue("@produtoId", produto.ProdutoId);

                    int rowsAffected = await command.ExecuteNonQueryAsync();
                    return rowsAffected > 0;
                }
            }
        }

        public async Task<bool> DeleteAsync(int produtoId)
        {
            using (var connection = GetConnection())
            {
                connection.Open();

                using (var command = new NpgsqlCommand("DELETE FROM produtos WHERE produto_id = @produtoId", connection))
                {
                    command.Parameters.AddWithValue("@produtoId", produtoId);

                    int rowsAffected = await command.ExecuteNonQueryAsync();
                    return rowsAffected > 0;
                }
            }
        }


    }
}
