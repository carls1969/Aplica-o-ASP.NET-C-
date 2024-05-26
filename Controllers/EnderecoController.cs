using GerenciadorDeEnderecos.Data;
using GerenciadorDeEnderecos.Models;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorDeEnderecos.Controllers;

[ApiController]
[Route("[Controller]")]
public class EnderecoController : ControllerBase
{

    private EnderecoContext _context;

    public EnderecoController(EnderecoContext context)
    {
        _context = context;
    }

    [HttpPost]
    public IActionResult AdicionaEndereco ([FromBody] Endereco endereco)
    {
        _context.Enderecos.Add(endereco);
        _context.SaveChanges();
        return CreatedAtAction(nameof(ProcuraEnderecoPorId), new { id = endereco.Id }, endereco);
    }

    [HttpGet]
    public IEnumerable<Endereco> LeEndereco([FromQuery] int skip = 0, [FromQuery] int take = 10)
    {
        return _context.Enderecos.Skip(skip).Take(take);
    }

    [HttpGet("{id}")]
    public IActionResult ProcuraEnderecoPorId(int id)
    {
        var endereco = _context.Enderecos.FirstOrDefault(endereco => endereco.Id == id);
        if (endereco == null) return NotFound();
        return Ok(endereco);

    }
}
