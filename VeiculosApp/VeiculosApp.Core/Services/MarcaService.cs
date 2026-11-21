using Npgsql;
using System;
using System.Collections.Generic;
using System.Text;
using VeiculosApp.Core.Entidades;
using VeiculosApp.Core.Exceptions;
using VeiculosApp.Core.Interfaces;

namespace VeiculosApp.Core.Services
{
    public class MarcaService 
    {
        private readonly IMarcaRepository _repo;

        public MarcaService(IMarcaRepository repo)
        {
            _repo = repo;
        }

        public async Task CriarAsync(string nome)
        {
            if (string.IsNullOrWhiteSpace(nome))
            {
                throw new RegraNegocioException("Informe o nome da marca");
            }
            if (nome.Length > 50) {
                throw new RegraNegocioException("Nome não pode ter mais que 50 caracteres");
            }

            try
            {
                Marca marca = new Marca(0, nome);
                await _repo.InserirAsync(marca);
            }
            catch (PostgresException ex) when (ex.SqlState == PostgresErrorCodes.UniqueViolation)
            {
                throw new RegraNegocioException("Já existe uma marca com este nome.");
            }
        }

        public async Task<List<Marca>> ListarAsync()
        {
            return await _repo.ListarAsync();
        }

        public async Task AtualizarAsync(Marca marca)
        {
            if (string.IsNullOrWhiteSpace(marca.Nome))
            {
                throw new RegraNegocioException("Informe o nome da marca");
            }
            if (marca.Nome.Length > 50)
            {
                throw new RegraNegocioException("Nome não pode ter mais que 50 caracteres");
            }
            if (marca.Codigo <= 0)
            {
                throw new RegraNegocioException("Código inválido");
            }
            try
            {
                await _repo.AtualizarAsync(marca);
            }
            catch (PostgresException ex) when (ex.SqlState == PostgresErrorCodes.UniqueViolation)
            {
                throw new RegraNegocioException("Já existe uma marca com este nome.");
            }
        }

        public async Task DeletarAsync(int codigo)
        {
            if (codigo <= 0)
            {
                throw new RegraNegocioException("Código inválido");
            }
            try
            {
                await _repo.DeletarAsync(codigo);
            }
            catch (PostgresException ex) when (ex.SqlState == PostgresErrorCodes.RestrictViolation)
            {
                throw new RegraNegocioException("Não é possível excluir esta marca porque existem veículos cadastrados com ela.");
            }

        }
    }
}
