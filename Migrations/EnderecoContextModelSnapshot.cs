﻿// <auto-generated />
using GerenciadorDeEnderecos.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GerenciadorDeEnderecos.Migrations;

[DbContext(typeof(EnderecoContext))]
partial class EnderecoContextModelSnapshot : ModelSnapshot
{
    protected override void BuildModel(ModelBuilder modelBuilder)
    {
#pragma warning disable 612, 618
        modelBuilder
            .HasAnnotation("ProductVersion", "8.0.5")
            .HasAnnotation("Relational:MaxIdentifierLength", 64);

        MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

        modelBuilder.Entity("GerenciadorDeEnderecos.Models.Endereco", b =>
            {
                b.Property<int>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("int");

                MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                b.Property<string>("Bairro")
                    .IsRequired()
                    .HasColumnType("longtext");

                b.Property<string>("Cep")
                    .IsRequired()
                    .HasMaxLength(8)
                    .HasColumnType("varchar(8)");

                b.Property<string>("Cidade")
                    .IsRequired()
                    .HasColumnType("longtext");

                b.Property<string>("Complemento")
                    .IsRequired()
                    .HasColumnType("longtext");

                b.Property<string>("Logradouro")
                    .IsRequired()
                    .HasColumnType("longtext");

                b.Property<int>("Numero")
                    .HasColumnType("int");

                b.Property<string>("Uf")
                    .IsRequired()
                    .HasColumnType("longtext");

                b.HasKey("Id");

                b.ToTable("Enderecos");
            });
#pragma warning restore 612, 618
    }
}
