using System;
using System.Collections.Generic;
using System.Text;

namespace VeiculosApp.Core.Entidades
{
   public class Moto : Veiculo
   {
        public bool PossuiBau { get; private set; }
        public override string Tipo => "Moto";
        public override string Descricao => PossuiBau ? "Com baú" : "Sem baú";

        public Moto(int codigo, string placa, int ano, string modelo, Marca marca, bool possuiBau)
           : base(codigo, placa, ano, modelo, marca)
        {
            PossuiBau = possuiBau;
        }
    }
}
