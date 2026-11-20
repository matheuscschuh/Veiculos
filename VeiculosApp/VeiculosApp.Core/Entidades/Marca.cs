using System;
using System.Collections.Generic;
using System.Text;

namespace VeiculosApp.Core.Entidades
{
    public class Marca
    {
        public int Codigo { get; private set; }
        public string Nome { get; private set; }

        public Marca(int codigo, string nome)
        {
            Codigo = codigo;
            Nome = nome;
        }

    }
}
