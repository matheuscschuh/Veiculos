using Npgsql;
using NpgsqlTypes;
using System;
using System.Collections.Generic;
using System.Text;
using VeiculosApp.Core.ConexaoBanco;
using VeiculosApp.Core.Entidades;
using VeiculosApp.Core.Interfaces;

namespace VeiculosApp.Core.Repositories
{
    public class MarcaRepository : IMarcaRepository
    {

        private readonly Conexao _conexao;

        public MarcaRepository(Conexao conexao)
        {
            _conexao = conexao;
        }

    
        public async Task InserirAsync(Marca marca)
        {
            await using var conn = await _conexao.ConectarAsync();

            string sql = "INSERT INTO marcas (nome) VALUES (@nome)";

            await using var cmd = new NpgsqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@nome", NpgsqlDbType.Varchar, marca.Nome);
            

            await cmd.ExecuteNonQueryAsync();
        }

        public async Task<List<Marca>> ListarAsync()
        {
            var lista = new List<Marca>();

            await using var conn = await _conexao.ConectarAsync();

            string sql = "SELECT codigo, nome FROM marcas ORDER BY nome";
            await using var cmd = new NpgsqlCommand(sql, conn);

            
            await using var reader = await cmd.ExecuteReaderAsync();

            
            while (await reader.ReadAsync())
            {
                var marca = new Marca(reader.GetInt32(0), reader.GetString(1));
                lista.Add(marca);
            }

            return lista;

        }

        public async Task AtualizarAsync(Marca marca)
        {
            await using var conn = await _conexao.ConectarAsync();

            string sql = "UPDATE marcas SET nome = @nome WHERE codigo = @codigo";

            await using var cmd = new NpgsqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@codigo", NpgsqlDbType.Integer, marca.Codigo);
            cmd.Parameters.AddWithValue("@nome", NpgsqlDbType.Varchar, marca.Nome);


            await cmd.ExecuteNonQueryAsync();
        }

        public async Task DeletarAsync(int codigo)
        {
            await using var conn = await _conexao.ConectarAsync();

            string sql = "DELETE FROM marcas WHERE codigo = @codigo";

            await using var cmd = new NpgsqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@codigo", NpgsqlDbType.Integer, codigo);
          
            await cmd.ExecuteNonQueryAsync();
        }
    }
}
