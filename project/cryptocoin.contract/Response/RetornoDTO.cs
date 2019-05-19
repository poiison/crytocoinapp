using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cryptocoin.contract.Response
{
    public class RetornoDTO<T>
    {
        public T Retorno { get; set; }
        public string Identificador { get; set; }
        public bool Sucesso { get; set; }
        public List<Exception> Exception { get; set; }
    }
}
