using GerenciadorDeEnderecos.Models;
using Microsoft.EntityFrameworkCore;
namespace GerenciadorDeEnderecos.Data;

public class EnderecoContext : DbContext
{
    public EnderecoContext(DbContextOptions<EnderecoContext> opts)
        : base(opts)
    {

    }

    public DbSet<Endereco> Enderecos { get; set; }
    
}
