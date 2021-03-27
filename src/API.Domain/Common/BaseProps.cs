using System;
using System.Collections.Generic;
using System.Text;

namespace API.Domain.Common
{
    public abstract class BaseProps
    {
        public int ID { get; set; }
        public Guid Ticket { get; set; }
        public DateTime CriadoEm { get; set; }
        public DateTime AtualizadoEm { get; set; }
    }
}
