using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pim.Models
{
    public class Pessoa
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public long Cpf { get; set; }
        public Endereco Endereco { get; set; }
        public int EnderecoId { get; set; }
        public ICollection<PessoaTelefone> PessoasTelefones { get; set; }
    }
}
