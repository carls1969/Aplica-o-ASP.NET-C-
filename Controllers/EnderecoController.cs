﻿using GerenciadorDeEnderecos.Models;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorDeEnderecos.Controllers;

[ApiController]
[Route("[Controller]")]
public class EnderecoController : ControllerBase
{
    private static List<Endereco> enderecos = new List<Endereco>();
    private static int id = 0;

    [HttpPost]
    public IActionResult AdicionaEndereco ([FromBody] Endereco endereco)
    {
        endereco.Id = id++;
        enderecos.Add(endereco);
        return CreatedAtAction(nameof(ProcuraEnderecoPorId), new { id = endereco.Id }, endereco);
    }

    [HttpGet]
    public IEnumerable<Endereco> LeEndereco([FromQuery] int skip = 0, [FromQuery] int take = 10)
    {
        return enderecos.Skip(skip).Take(take);
    }

    [HttpGet("{id}")]
    public IActionResult ProcuraEnderecoPorId(int id)
    {
        var endereco = enderecos.FirstOrDefault(endereco => endereco.Id == id);
        if (endereco == null) return NotFound();
        return Ok(endereco);

    }
}