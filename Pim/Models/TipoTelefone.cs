using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pim.Models
{
    public class TipoTelefone
    {
        public int Id { get; set; }
        public string Tipo { get; set; }
        public ICollection<Telefone> Telefones { get; set; } = new List<Telefone>();
    }
}
