using System;
using System.Collections.Generic;
using System.Text;
using VeiculosApp.Core.Entidades;

namespace VeiculosApp.Core.Interfaces
{
    public interface IVeiculoRepository
    {
        Task InserirAsync(Veiculo veiculo);
        Task<List<Veiculo>> ListarAsync();
        
        Task AtualizarAsync(Veiculo veiculo);
        Task DeletarAsync(int codigo);
    }
}
