using System;
using System.Collections.Generic;
using System.Text;
using VeiculosApp.Core.Entidades;
using VeiculosApp.Core.Interfaces;

namespace VeiculosApp.Tests
{
    public class MarcaRepositorioFalso : IMarcaRepository
    {
        public Task AtualizarAsync(Marca marca)
        {
            return Task.CompletedTask;
        }

        public Task DeletarAsync(int codigo)
        {
            return Task.CompletedTask;
        }

        public Task InserirAsync(Marca marca)
        {
            return Task.CompletedTask;
        }

        public Task<List<Marca>> ListarAsync()
        {
            return Task.FromResult(new List<Marca>());
        }
    }
}
