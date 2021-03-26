using System;
using System.Collections.Generic;
using System.Text;

namespace API.Domain.Somas
{
    public class SomaService
    {

        public SomaService()
        {

        }

        public int SomarValores(List<int> numeros)
        {
            var result = Soma.Somar(numeros);
            return result;
        }
    }
}
