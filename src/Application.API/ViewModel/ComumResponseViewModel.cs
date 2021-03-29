using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace application.API.ViewModel
{
    public class ComumResponseViewModel
    {
        public ComumResponseViewModel(bool sucesso, string messagem = null)
        {
            Sucesso = sucesso;
            Messagem = messagem;
        }

        public bool Sucesso { get; set; }

        public string Messagem { get; set; }
    }
}
