using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pim.Models
{
    public class Telefone
    {
        public int Id { get; set; }
        public int Ddd { get; set; }
        public int Numero { get; set; }
        public TipoTelefone TipoTelefone { get; set; }
        public int TipoTelefoneId { get; set; }
        public ICollection<PessoaTelefone> PessoasTelefones { get; set; }
    }
}
