using System;
using System.Collections.Generic;
using System.Text;

namespace VeiculosApp.UI.Utils
{
    public static class Logger
    {
        public static void Registrar(Exception ex)
        {
            try
            {
               
                string pasta = Path.Combine(AppContext.BaseDirectory, "logs");
                Directory.CreateDirectory(pasta);   
                string arquivo = Path.Combine(pasta, "erros.log");

                
                string texto = $"{DateTime.Now:dd/MM/yyyy HH:mm:ss} {ex.GetType().Name} {Environment.NewLine}Mensagem: {ex.Message} {Environment.NewLine}Local: {ex.StackTrace} {Environment.NewLine}---------------------------------------------------{Environment.NewLine}";

                
                File.AppendAllText(arquivo, texto);
            }
            catch
            {
                
            }
        }
    }
}
