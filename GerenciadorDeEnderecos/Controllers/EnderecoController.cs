using GerenciadorDeEnderecos.Models;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorDeEnderecos.Controllers;

[ApiController]
[Route("[Controller]")]
public class EnderecoController : ControllerBase
{
    private static List<Endereco> enderecos = new List<Endereco>();

    [HttpPost]
    public void AdicionaEndereco ([FromBody] Endereco endereco)
    {

         enderecos.Add(endereco);
         Console.WriteLine(endereco.Cep);
        
    }
}
