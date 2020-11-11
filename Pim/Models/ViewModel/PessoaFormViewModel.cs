using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;

namespace Pim.Models.ViewModel
{
    public class PessoaFormViewModel
    {
        public Pessoa Pessoa { get; set; }
        public Endereco Endereco { get; set; }
        public Telefone Telefone { get; set; }
        public TipoTelefone TipoTelefone { get; set; }
    }
}
