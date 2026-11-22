using System;
using System.Collections.Generic;
using System.Text;
using VeiculosApp.Core.Entidades;
using VeiculosApp.Core.Interfaces;

namespace VeiculosApp.Tests
{
    public class VeiculoRepositorioFalso : IVeiculoRepository
    {
        public Task AtualizarAsync(Veiculo veiculo)
        {
            return Task.CompletedTask;
        }

        public Task DeletarAsync(int codigo)
        {
            return Task.CompletedTask;
        }

        public Task InserirAsync(Veiculo veiculo)
        {
            return Task.CompletedTask;
        }

        public Task<List<Veiculo>> ListarAsync()
        {
            return Task.FromResult(new List<Veiculo>());
        }
    }
}
