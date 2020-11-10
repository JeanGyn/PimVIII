using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pim.Models
{
    public class Endereco
    {
        public int Id { get; set; }
        public int Cep { get; set; }
        public string Logradouro { get; set; }
        public int Numero { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public IEnumerable<Pessoa> Pessoas { get; set; } = new List<Pessoa>();
    }
}
