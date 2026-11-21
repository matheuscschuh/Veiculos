using System;
using System.Collections.Generic;
using System.Text;
using VeiculosApp.Core.Entidades;

namespace VeiculosApp.Core.Interfaces
{
    public interface IMarcaRepository
    {
        Task InserirAsync(Marca marca);
        Task<List<Marca>> ListarAsync();
        Task AtualizarAsync(Marca marca);
        Task DeletarAsync(int codigo);
    }
}
