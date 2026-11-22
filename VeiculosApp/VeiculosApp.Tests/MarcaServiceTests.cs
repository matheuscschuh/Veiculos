using System;
using System.Collections.Generic;
using System.Text;
using VeiculosApp.Core.Exceptions;
using VeiculosApp.Core.Services;

namespace VeiculosApp.Tests
{
    public class MarcaServiceTests
    {
        [Fact]
        public async Task CriarMarca_NomeVazio_DeveLancarRegraNegocioException()
        {
            //Arrange
            var repo = new MarcaRepositorioFalso();
            var service = new MarcaService(repo);

            //Act e Assert
            var ex = await Assert.ThrowsAsync<RegraNegocioException>(() => service.CriarAsync(""));
            Assert.Equal("Informe o nome da marca", ex.Message);
            
        }
     }
}
