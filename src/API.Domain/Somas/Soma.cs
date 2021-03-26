using System;
using System.Collections.Generic;
using System.Text;

namespace API.Domain.Somas
{
    public class Soma
    {
        private Soma()
        {

        }

        internal static int Somar(List<int> numeros)
        {
            int resultado = 0;

            foreach(int numero in numeros)
            {
                resultado += numero;
            }

            return resultado;
        }
    }
}
