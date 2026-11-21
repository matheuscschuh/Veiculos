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
    public class VeiculoRepository : IVeiculoRepository
    {
        private readonly Conexao _conexao;

        public VeiculoRepository(Conexao conexao)
        {
            _conexao = conexao;
        }

        public async Task InserirAsync(Veiculo veiculo)
        {
            await using var conn = await _conexao.ConectarAsync();

            string sql = "INSERT INTO veiculos (placa, modelo, ano, codigo_marca, tipo, possui_ar_condicionado, possui_bau) " +
                "VALUES (@placa, @modelo, @ano, @codigo_marca, @tipo, @possui_ar_condicionado, @possui_bau)";

            await using var cmd = new NpgsqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@placa", NpgsqlDbType.Varchar, veiculo.Placa);
            cmd.Parameters.AddWithValue("@modelo", NpgsqlDbType.Varchar, veiculo.Modelo);
            cmd.Parameters.AddWithValue("@ano", NpgsqlDbType.Integer, veiculo.Ano);
            cmd.Parameters.AddWithValue("@codigo_marca", NpgsqlDbType.Integer, veiculo.Marca.Codigo);
            
            if (veiculo is Carro carro)
            {
                cmd.Parameters.AddWithValue("@tipo", NpgsqlDbType.Varchar, "Carro");
                cmd.Parameters.AddWithValue("@possui_ar_condicionado", NpgsqlDbType.Boolean, carro.PossuiArCondicionado);
                cmd.Parameters.AddWithValue("@possui_bau", NpgsqlDbType.Boolean, DBNull.Value);
            }
            else if (veiculo is Moto moto)
            {
                cmd.Parameters.AddWithValue("@tipo", NpgsqlDbType.Varchar, "Moto");
                cmd.Parameters.AddWithValue("@possui_bau", NpgsqlDbType.Boolean, moto.PossuiBau);
                cmd.Parameters.AddWithValue("@possui_ar_condicionado", NpgsqlDbType.Boolean, DBNull.Value);
            }
            else
            {
                throw new NotSupportedException("Tipo de veículo inválido");
            }


            await cmd.ExecuteNonQueryAsync();
        }

        public async Task<List<Veiculo>> ListarAsync()
        {
            var lista = new List<Veiculo>();

            await using var conn = await _conexao.ConectarAsync();

            string sql = "SELECT v.codigo, v.placa, v.ano, v.modelo, m.codigo, m.nome, v.tipo, v.possui_ar_condicionado, v.possui_bau " +
                "FROM veiculos v INNER JOIN marcas m ON v.codigo_marca = m.codigo ORDER BY m.nome";
            await using var cmd = new NpgsqlCommand(sql, conn);


            await using var reader = await cmd.ExecuteReaderAsync();


            while (await reader.ReadAsync())
            {
                string tipo = reader.GetString(6);
                var marca = new Marca(reader.GetInt32(4), reader.GetString(5));

                if (tipo == "Carro")
                {
                    var carro = new Carro(reader.GetInt32(0), reader.GetString(1), reader.GetInt32(2), reader.GetString(3),
                        marca, reader.GetBoolean(7));
                    lista.Add(carro);
                }
                else if (tipo == "Moto")
                {
                    var moto = new Moto(reader.GetInt32(0), reader.GetString(1), reader.GetInt32(2), reader.GetString(3),
                        marca, reader.GetBoolean(8));
                    lista.Add(moto);
                }
                else
                {
                    throw new NotSupportedException("Tipo de veículo inválido");
                }
               
            }

            return lista;
        }

        public async Task AtualizarAsync(Veiculo veiculo)
        {
            await using var conn = await _conexao.ConectarAsync();

            string sql = "UPDATE veiculos SET placa = @placa, ano = @ano, modelo = @modelo, codigo_marca = @codigo_marca, " +
                "possui_ar_condicionado = @possui_ar_condicionado, possui_bau = @possui_bau WHERE codigo = @codigo";

            await using var cmd = new NpgsqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@codigo", NpgsqlDbType.Integer, veiculo.Codigo);
            cmd.Parameters.AddWithValue("@placa", NpgsqlDbType.Varchar, veiculo.Placa);
            cmd.Parameters.AddWithValue("@ano", NpgsqlDbType.Integer, veiculo.Ano);
            cmd.Parameters.AddWithValue("@modelo", NpgsqlDbType.Varchar, veiculo.Modelo);
            cmd.Parameters.AddWithValue("@codigo_marca", NpgsqlDbType.Integer, veiculo.Marca.Codigo);
            if (veiculo is Carro carro)
            {
                cmd.Parameters.AddWithValue("@possui_ar_condicionado", NpgsqlDbType.Boolean, carro.PossuiArCondicionado);
                cmd.Parameters.AddWithValue("@possui_bau", NpgsqlDbType.Boolean, DBNull.Value);
            } else if (veiculo is Moto moto)
            {
                cmd.Parameters.AddWithValue("@possui_bau", NpgsqlDbType.Boolean, moto.PossuiBau);
                cmd.Parameters.AddWithValue("@possui_ar_condicionado", NpgsqlDbType.Boolean, DBNull.Value);
            } else
            {
                throw new NotSupportedException("Tipo de veículo inválido");
            }


            await cmd.ExecuteNonQueryAsync();
        }

        public async Task DeletarAsync(int codigo)
        {
            await using var conn = await _conexao.ConectarAsync();

            string sql = "DELETE FROM veiculos WHERE codigo = @codigo";

            await using var cmd = new NpgsqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@codigo", NpgsqlDbType.Integer, codigo);

            await cmd.ExecuteNonQueryAsync();
        }
    }
}
