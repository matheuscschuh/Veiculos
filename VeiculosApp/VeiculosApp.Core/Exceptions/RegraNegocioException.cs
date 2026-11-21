using System;
using System.Collections.Generic;
using System.Text;

namespace VeiculosApp.Core.Exceptions
{
    public class RegraNegocioException : Exception
    {
        public RegraNegocioException(string mensagem) : base(mensagem)
        {
        }
    }
}
