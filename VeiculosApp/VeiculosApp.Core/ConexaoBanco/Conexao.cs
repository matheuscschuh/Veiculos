using Npgsql;
using System;
using System.Collections.Generic;
using System.Text;

namespace VeiculosApp.Core.ConexaoBanco
{
    public class Conexao
    {
        private readonly string _connectionString;

        public Conexao(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<NpgsqlConnection> ConectarAsync()
        {
            var conn = new NpgsqlConnection(_connectionString);
            await conn.OpenAsync();
            return conn;
        }
    }
}
