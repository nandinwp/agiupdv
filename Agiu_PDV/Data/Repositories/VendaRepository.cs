using Agiu_PDV.Models;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agiu_PDV.Data.Repositories
{
    public class VendaRepository : BaseRepository
    {
        public VendaRepository(string connectionString) : base(connectionString) { }

        public async Task<IEnumerable<Venda>> GetAllAsync()
        {
            var vendas = new List<Venda>();

            using (var connection = GetConnection())
            {
                connection.Open();

                using (var command = new NpgsqlCommand(@"
                    SELECT v.venda_id, v.cliente_id, v.data_venda, v.valor_total, 
                           c.cliente_id, c.nome, c.endereco, c.telefone, c.email
                    FROM vendas v
                    INNER JOIN clientes c ON v.cliente_id = c.cliente_id", connection))
                {
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            var venda = new Venda
                            {
                                VendaId = reader.GetInt32(0),
                                ClienteId = reader.GetInt32(1),
                                DataVenda = reader.GetDateTime(2),
                                ValorTotal = reader.GetDecimal(3),
                                Cliente = new Cliente
                                {
                                    ClienteId = reader.GetInt32(4),
                                    Nome = reader.GetString(5),
                                    Endereco = reader.GetString(6),
                                    Telefone = reader.GetString(7),
                                    Email = reader.GetString(8),
                                },
                                Itens = new List<VendaItem>()
                            };

                            vendas.Add(venda);
                        }
                    }
                }

                using (var itemCommand = new NpgsqlCommand(@"
                    SELECT vi.venda_item_id, vi.venda_id, vi.produto_id, vi.quantidade, vi.preco_unitario,
                           p.produto_id, p.nome, p.descricao, p.preco, p.estoque
                    FROM venda_itens vi
                    INNER JOIN produtos p ON vi.produto_id = p.produto_id", connection))
                {
                    using (var itemReader = await itemCommand.ExecuteReaderAsync())
                    {
                        while (await itemReader.ReadAsync())
                        {
                            var vendaId = itemReader.GetInt32(1);

                            // Localiza a venda correspondente para adicionar o item
                            var venda = vendas.FirstOrDefault(v => v.VendaId == vendaId);
                            if (venda != null)
                            {
                                var vendaItem = new VendaItem
                                {
                                    VendaItemId = itemReader.GetInt32(0),
                                    VendaId = vendaId,
                                    ProdutoId = itemReader.GetInt32(2),
                                    Quantidade = itemReader.GetInt32(3),
                                    PrecoUnitario = itemReader.GetDecimal(4),
                                    Produto = new Produto
                                    {
                                        ProdutoId = itemReader.GetInt32(5),
                                        Nome = itemReader.GetString(6),
                                        Descricao = itemReader.GetString(7),
                                        Preco = itemReader.GetDecimal(8),
                                        Estoque = itemReader.GetInt32(9),
                                    }
                                };

                                venda.Itens.Add(vendaItem);
                            }
                        }
                    }
                }
            }

            return vendas;
        }

        public async Task<bool> SaveAsync(Venda venda)
        {
            using (var connection = GetConnection())
            {
                connection.Open();

                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        // Inserir a venda
                        int vendaId;
                        using (var command = new NpgsqlCommand(@"
                        INSERT INTO vendas (cliente_id, data_venda, valor_total)
                        VALUES (@cliente_id, @data_venda, @valor_total)
                        RETURNING venda_id", connection))
                        {
                            command.Parameters.AddWithValue("@cliente_id", venda.ClienteId);
                            command.Parameters.AddWithValue("@data_venda", venda.DataVenda);
                            command.Parameters.AddWithValue("@valor_total", venda.ValorTotal);

                            vendaId = (int)await command.ExecuteScalarAsync();
                        }

                        foreach (var item in venda.Itens)
                        {
                            using (var itemCommand = new NpgsqlCommand(@"
                            INSERT INTO venda_itens (venda_id, produto_id, quantidade, preco_unitario)
                            VALUES (@venda_id, @produto_id, @quantidade, @preco_unitario)", connection))
                            {
                                itemCommand.Parameters.AddWithValue("@venda_id", vendaId);
                                itemCommand.Parameters.AddWithValue("@produto_id", item.ProdutoId);
                                itemCommand.Parameters.AddWithValue("@quantidade", item.Quantidade);
                                itemCommand.Parameters.AddWithValue("@preco_unitario", item.PrecoUnitario);

                                await itemCommand.ExecuteNonQueryAsync();
                            }
                        }

                        await transaction.CommitAsync();
                    }
                    catch
                    {
                        await transaction.RollbackAsync();
                        throw;
                    }
                }
            }
            return true;
        }

        public async Task<Venda> GetByIdAsync(int id)
        {
            Venda venda = null;

            using (var connection = GetConnection())
            {
                connection.Open();

                using (var command = new NpgsqlCommand(@"
                SELECT v.venda_id, v.cliente_id, v.data_venda, v.valor_total, 
                       c.cliente_id, c.nome, c.endereco, c.telefone, c.email
                FROM vendas v
                INNER JOIN clientes c ON v.cliente_id = c.cliente_id
                WHERE v.venda_id = @id", connection))
                {
                    command.Parameters.AddWithValue("@id", id);

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            venda = new Venda
                            {
                                VendaId = reader.GetInt32(0),
                                ClienteId = reader.GetInt32(1),
                                DataVenda = reader.GetDateTime(2),
                                ValorTotal = reader.GetDecimal(3),
                                Cliente = new Cliente
                                {
                                    ClienteId = reader.GetInt32(4),
                                    Nome = reader.GetString(5),
                                    Endereco = reader.GetString(6),
                                    Telefone = reader.GetString(7),
                                    Email = reader.GetString(8),
                                },
                                Itens = new List<VendaItem>()
                            };
                        }
                    }
                }

                if (venda != null)
                {
                    using (var itemCommand = new NpgsqlCommand(@"
                    SELECT vi.venda_item_id, vi.venda_id, vi.produto_id, vi.quantidade, vi.preco_unitario,
                           p.produto_id, p.nome, p.descricao, p.preco, p.estoque
                    FROM venda_itens vi
                    INNER JOIN produtos p ON vi.produto_id = p.produto_id
                    WHERE vi.venda_id = @id", connection))
                    {
                        itemCommand.Parameters.AddWithValue("@id", id);

                        using (var itemReader = await itemCommand.ExecuteReaderAsync())
                        {
                            while (await itemReader.ReadAsync())
                            {
                                var vendaItem = new VendaItem
                                {
                                    VendaItemId = itemReader.GetInt32(0),
                                    VendaId = itemReader.GetInt32(1),
                                    ProdutoId = itemReader.GetInt32(2),
                                    Quantidade = itemReader.GetInt32(3),
                                    PrecoUnitario = itemReader.GetDecimal(4),
                                    Produto = new Produto
                                    {
                                        ProdutoId = itemReader.GetInt32(5),
                                        Nome = itemReader.GetString(6),
                                        Descricao = itemReader.GetString(7),
                                        Preco = itemReader.GetDecimal(8),
                                        Estoque = itemReader.GetInt32(9),
                                    }
                                };

                                venda.Itens.Add(vendaItem);
                            }
                        }
                    }
                }
            }

            return venda;
        }

        public async Task<bool> UpdateAsync(Venda venda)
        {
            using (var connection = GetConnection())
            {
                connection.Open();

                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        // Atualizar a venda
                        using (var command = new NpgsqlCommand(@"
                        UPDATE vendas 
                        SET cliente_id = @cliente_id, data_venda = @data_venda, valor_total = @valor_total
                         WHERE venda_id = @venda_id", connection))
                        {
                            command.Parameters.AddWithValue("@cliente_id", venda.ClienteId);
                            command.Parameters.AddWithValue("@data_venda", venda.DataVenda);
                            command.Parameters.AddWithValue("@valor_total", venda.ValorTotal);
                            command.Parameters.AddWithValue("@venda_id", venda.VendaId);

                            await command.ExecuteNonQueryAsync();
                        }

                        var existingItemIds = new List<int>();
                        using (var selectCommand = new NpgsqlCommand(@"
                            SELECT venda_item_id FROM venda_itens WHERE venda_id = @venda_id", connection))
                        {
                            selectCommand.Parameters.AddWithValue("@venda_id", venda.VendaId);

                            using (var reader = await selectCommand.ExecuteReaderAsync())
                            {
                                while (await reader.ReadAsync())
                                {
                                    existingItemIds.Add(reader.GetInt32(0));
                                }
                            }
                        }

                        foreach (var item in venda.Itens)
                        {
                            if (existingItemIds.Contains(item.VendaItemId))
                            {
                                using (var updateItemCommand = new NpgsqlCommand(@"
                                    UPDATE venda_itens
                                    SET produto_id = @produto_id, quantidade = @quantidade, preco_unitario = @preco_unitario
                                    WHERE venda_item_id = @venda_item_id", connection))
                                {
                                    updateItemCommand.Parameters.AddWithValue("@produto_id", item.ProdutoId);
                                    updateItemCommand.Parameters.AddWithValue("@quantidade", item.Quantidade);
                                    updateItemCommand.Parameters.AddWithValue("@preco_unitario", item.PrecoUnitario);
                                    updateItemCommand.Parameters.AddWithValue("@venda_item_id", item.VendaItemId);

                                    await updateItemCommand.ExecuteNonQueryAsync();
                                }
                                existingItemIds.Remove(item.VendaItemId);
                            }
                            else
                            {
                                using (var insertItemCommand = new NpgsqlCommand(@"
                                    INSERT INTO venda_itens (venda_id, produto_id, quantidade, preco_unitario)
                                    VALUES (@venda_id, @produto_id, @quantidade, @preco_unitario)", connection))
                                {
                                    insertItemCommand.Parameters.AddWithValue("@venda_id", venda.VendaId);
                                    insertItemCommand.Parameters.AddWithValue("@produto_id", item.ProdutoId);
                                    insertItemCommand.Parameters.AddWithValue("@quantidade", item.Quantidade);
                                    insertItemCommand.Parameters.AddWithValue("@preco_unitario", item.PrecoUnitario);

                                    await insertItemCommand.ExecuteNonQueryAsync();
                                }
                            }
                        }

                        foreach (var itemId in existingItemIds)
                        {
                            using (var deleteItemCommand = new NpgsqlCommand(@"
                                DELETE FROM venda_itens WHERE venda_item_id = @venda_item_id", connection))
                            {
                                deleteItemCommand.Parameters.AddWithValue("@venda_item_id", itemId);
                                await deleteItemCommand.ExecuteNonQueryAsync();
                            }
                        }

                        await transaction.CommitAsync();
                    }
                    catch
                    {
                        await transaction.RollbackAsync();
                        throw;
                    }
                }
            }
            return true;
        }

        public async Task<bool> AddAsync(Venda venda)
        {
            using (var connection = GetConnection())
            {
                connection.Open();

                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        int vendaId;
                        using (var command = new NpgsqlCommand(@"
                        INSERT INTO vendas (cliente_id, data_venda, valor_total)
                        VALUES (@cliente_id, @data_venda, @valor_total)
                        RETURNING venda_id", connection))
                        {
                            command.Parameters.AddWithValue("@cliente_id", venda.ClienteId);
                            command.Parameters.AddWithValue("@data_venda", venda.DataVenda);
                            command.Parameters.AddWithValue("@valor_total", venda.ValorTotal);

                            vendaId = (int)await command.ExecuteScalarAsync();
                        }

                        foreach (var item in venda.Itens)
                        {
                            using (var itemCommand = new NpgsqlCommand(@"
                                INSERT INTO venda_itens (venda_id, produto_id, quantidade, preco_unitario)
                                VALUES (@venda_id, @produto_id, @quantidade, @preco_unitario)", connection))
                            {
                                itemCommand.Parameters.AddWithValue("@venda_id", vendaId);
                                itemCommand.Parameters.AddWithValue("@produto_id", item.ProdutoId);
                                itemCommand.Parameters.AddWithValue("@quantidade", item.Quantidade);
                                itemCommand.Parameters.AddWithValue("@preco_unitario", item.PrecoUnitario);

                                await itemCommand.ExecuteNonQueryAsync();
                            }
                        }

                        await transaction.CommitAsync();
                        return true;
                    }
                    catch
                    {
                        await transaction.RollbackAsync();
                        throw;
                    }
                }
            }
        }

        public async Task<bool> DeleteAsync(int vendaId)
        {
            using (var connection = GetConnection())
            {
                connection.Open();

                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        using (var itemCommand = new NpgsqlCommand("DELETE FROM venda_itens WHERE venda_id = @venda_id", connection))
                        {
                            itemCommand.Parameters.AddWithValue("@venda_id", vendaId);
                            await itemCommand.ExecuteNonQueryAsync();
                        }

                        using (var vendaCommand = new NpgsqlCommand("DELETE FROM vendas WHERE venda_id = @venda_id", connection))
                        {
                            vendaCommand.Parameters.AddWithValue("@venda_id", vendaId);
                            int rowsAffected = await vendaCommand.ExecuteNonQueryAsync();

                            if (rowsAffected > 0)
                            {
                                await transaction.CommitAsync();
                                return true;
                            }
                            else
                            {
                                await transaction.RollbackAsync();
                                return false;
                            }
                        }
                    }
                    catch
                    {
                        await transaction.RollbackAsync();
                        throw;
                    }
                }
            }
        }

    }
}
