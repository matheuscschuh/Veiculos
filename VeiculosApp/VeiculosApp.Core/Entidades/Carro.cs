using System;
using System.Collections.Generic;
using System.Text;

namespace VeiculosApp.Core.Entidades
{
    public class Carro : Veiculo
    {
        public bool PossuiArCondicionado { get; private set; }

        public Carro(int codigo, string placa, int ano, string modelo, Marca marca, bool possuiArCondicionado)
            : base(codigo, placa, ano, modelo, marca) 
        {
            PossuiArCondicionado = possuiArCondicionado;
        }

        public override string Descricao()
        {
            return PossuiArCondicionado ? "Com ar condicionado" : "Sem ar condicionado";
        }
    }
}
