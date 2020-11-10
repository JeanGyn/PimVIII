﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Pim.Data;

namespace Pim.Migrations
{
    [DbContext(typeof(PimContext))]
    partial class PimContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.14-servicing-32113")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Pim.Models.Endereco", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Bairro");

                    b.Property<int>("Cep");

                    b.Property<string>("Cidade");

                    b.Property<string>("Estado");

                    b.Property<string>("Logradouro");

                    b.Property<int>("Numero");

                    b.HasKey("Id");

                    b.ToTable("Endereco");
                });

            modelBuilder.Entity("Pim.Models.Pessoa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<long>("Cpf");

                    b.Property<int>("EnderecoId");

                    b.Property<string>("Nome");

                    b.HasKey("Id");

                    b.HasIndex("EnderecoId");

                    b.ToTable("Pessoa");
                });

            modelBuilder.Entity("Pim.Models.PessoaTelefone", b =>
                {
                    b.Property<int>("PessoaId");

                    b.Property<int>("TelefoneId");

                    b.HasKey("PessoaId", "TelefoneId");

                    b.HasIndex("TelefoneId");

                    b.ToTable("PessoaTelefone");
                });

            modelBuilder.Entity("Pim.Models.Telefone", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Ddd");

                    b.Property<int>("Numero");

                    b.Property<int>("TipoTelefoneId");

                    b.HasKey("Id");

                    b.HasIndex("TipoTelefoneId");

                    b.ToTable("Telefone");
                });

            modelBuilder.Entity("Pim.Models.TipoTelefone", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Tipo");

                    b.HasKey("Id");

                    b.ToTable("TipoTelefone");
                });

            modelBuilder.Entity("Pim.Models.Pessoa", b =>
                {
                    b.HasOne("Pim.Models.Endereco", "Endereco")
                        .WithMany("Pessoas")
                        .HasForeignKey("EnderecoId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Pim.Models.PessoaTelefone", b =>
                {
                    b.HasOne("Pim.Models.Pessoa", "Pessoa")
                        .WithMany("PessoasTelefones")
                        .HasForeignKey("PessoaId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Pim.Models.Telefone", "Telefone")
                        .WithMany("PessoasTelefones")
                        .HasForeignKey("TelefoneId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Pim.Models.Telefone", b =>
                {
                    b.HasOne("Pim.Models.TipoTelefone", "TipoTelefone")
                        .WithMany("Telefones")
                        .HasForeignKey("TipoTelefoneId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
