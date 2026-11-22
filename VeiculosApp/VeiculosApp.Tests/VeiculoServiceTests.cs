using System;
using System.Collections.Generic;
using System.Text;
using VeiculosApp.Core.Entidades;
using VeiculosApp.Core.Exceptions;
using VeiculosApp.Core.Services;

namespace VeiculosApp.Tests
{
    public class VeiculoServiceTests
    {
        [Fact]
        public async Task CriarVeiculo_AnoInvalido_DeveLancarRegraNegocioException()
        {
            //Arrange
            var repo = new VeiculoRepositorioFalso();
            var service = new VeiculoService(repo);
            Marca marca = new Marca(2, "Honda");
            Carro carro = new Carro(1, "AGH23F", 1945, "Civic", marca, true);

            //Act e Assert
            var ex = await Assert.ThrowsAsync<RegraNegocioException>(() => service.CriarAsync(carro));
            Assert.Equal("Ano não pode ser menor que 1950", ex.Message);
        }

        [Fact]
        public async Task CriarVeiculo_ModeloVazio_DeveLancarRegraNegocioException()
        {
            //Arrange
            var repo = new VeiculoRepositorioFalso();
            var service = new VeiculoService(repo);
            Marca marca = new Marca(2, "Honda");
            Carro carro = new Carro(1, "AGH23F", 2009, "", marca, true);

            //Act e Assert
            var ex = await Assert.ThrowsAsync<RegraNegocioException>(() => service.CriarAsync(carro));
            Assert.Equal("Informe o modelo", ex.Message);
        }
    }
}
