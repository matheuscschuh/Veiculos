using Npgsql;
using System;
using System.Collections.Generic;
using System.Text;
using VeiculosApp.Core.Entidades;
using VeiculosApp.Core.Exceptions;
using VeiculosApp.Core.Interfaces;

namespace VeiculosApp.Core.Services
{
    public class VeiculoService
    {
        private readonly IVeiculoRepository _repo;

        public VeiculoService(IVeiculoRepository repo)
        {
            _repo = repo;
        }

        private void Validar(Veiculo veiculo)
        {
            if (string.IsNullOrWhiteSpace(veiculo.Placa))
            {
                throw new RegraNegocioException("Informe a placa");
            }
            if (veiculo.Placa.Length > 15)
            {
                throw new RegraNegocioException("Placa não pode ter mais que 15 caracteres");
            }
            if (string.IsNullOrWhiteSpace(veiculo.Modelo))
            {
                throw new RegraNegocioException("Informe o modelo");
            }
            if (veiculo.Modelo.Length > 30)
            {
                throw new RegraNegocioException("Modelo não pode ter mais que 30 caracteres");
            }
            if (veiculo.Ano < 1950)
            {
                throw new RegraNegocioException("Ano não pode ser menor que 1950");
            }
            if (veiculo.Ano > DateTime.Now.Year)
            {
                throw new RegraNegocioException("Ano não pode ser maior que o ano atual");
            }
            if (veiculo.Marca == null)
            {
                throw new RegraNegocioException("Selecione a marca do veículo.");
            }
            if (veiculo.Marca.Codigo <= 0)
            {
                throw new RegraNegocioException("Marca inválida");
            }
        }

        public async Task CriarAsync(Veiculo veiculo)
        {
            Validar(veiculo);

            try
            {
                await _repo.InserirAsync(veiculo);
            }
            catch (PostgresException ex) when (ex.SqlState == PostgresErrorCodes.UniqueViolation)
            {
                throw new RegraNegocioException("Já existe um veículo cadastrado com esta placa.");
            }
        }

        public async Task<List<Veiculo>> ListarAsync()
        {
            return await _repo.ListarAsync();
        }

        public async Task AtualizarAsync(Veiculo veiculo)
        { 
            if (veiculo.Codigo <= 0)
            {
                throw new RegraNegocioException("Código inválido");
            }
            Validar(veiculo);

            try
            {
                await _repo.AtualizarAsync(veiculo);
            }
            catch (PostgresException ex) when (ex.SqlState == PostgresErrorCodes.UniqueViolation)
            {
                throw new RegraNegocioException("Já existe um veículo cadastrado com esta placa.");
            }
        }

        public async Task DeletarAsync(int codigo)
        {
            if (codigo <= 0)
            {
                throw new RegraNegocioException("Código inválido");
            }
            
             await _repo.DeletarAsync(codigo);
            
        }
    }
}
