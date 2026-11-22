using Microsoft.Extensions.Configuration;
using VeiculosApp.Core.ConexaoBanco;
using VeiculosApp.Core.Services;
using VeiculosApp.Core.Repositories;


namespace VeiculosApp.UI
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            
            var configuracao = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .AddUserSecrets<FormPrincipal>()
                .Build();

            
            string? connectionString = configuracao.GetConnectionString("VeiculosDb");

            if (string.IsNullOrWhiteSpace(connectionString))
            {
               
                MessageBox.Show("A conexão com o banco de dados não foi configurada. " +
                    "Verifique a chave ConnectionStrings:VeiculosDb no arquivo appsettings.json.");
                return;
            }

            
            var conexao = new Conexao(connectionString);

            
            var veiculoRepositorio = new VeiculoRepository(conexao);
            var marcaRepositorio = new MarcaRepository(conexao);
            
            var marcaService = new MarcaService(marcaRepositorio);
            var veiculoService = new VeiculoService(veiculoRepositorio);
            
            Application.Run(new FormPrincipal(marcaService, veiculoService));
        }
    }
}