using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace application.API.ViewModel
{
    public class ComumResponseViewModel<T> : ComumResponseViewModel
    {
        public ComumResponseViewModel(bool sucesso, T data, string messagem = null)
            : base(sucesso, messagem)
        {
            this.Data = data;
        }

        public T Data { get; set; }
    }
}
