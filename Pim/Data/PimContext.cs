using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Pim.Models;

namespace Pim.Data
{
    public class PimContext : DbContext
    {
        public PimContext (DbContextOptions<PimContext> options)
            : base(options)
        {
        }

        public DbSet<Endereco> Endereco { get; set; }
        public DbSet<Pessoa> Pessoa { get; set; }
        public DbSet<Telefone> Telefone { get; set; }
        public DbSet<TipoTelefone> TipoTelefone { get; set; }
        public DbSet<PessoaTelefone> PessoaTelefone { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PessoaTelefone>(entity => 
            {
                entity.HasKey(e => new { e.PessoaId, e.TelefoneId });
            });
        }
    }
}
