using System;
using System.Collections.Generic;
using System.Text;

namespace VeiculosApp.Core.Entidades
{
    public abstract class Veiculo
    {
        public int Codigo { get; private set; }
        public string? Placa { get; private set; }
        public int Ano { get; private set; }
        public string? Modelo { get; private set; }
        public Marca Marca { get; private set; }
        public abstract string Tipo { get; }
        public abstract string Descricao { get; }

        protected Veiculo(int codigo, string placa, int ano, string modelo, Marca marca)
        {
            Codigo = codigo;
            Placa = placa?.Trim().ToUpper();
            Ano = ano;
            Modelo = modelo?.Trim();
            Marca = marca;
        }
    }
}
