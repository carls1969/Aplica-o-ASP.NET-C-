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
    public void AdicionaEndereco ([FromBody] Endereco endereco)
    {
        endereco.Id = id++;
        enderecos.Add(endereco);
        Console.WriteLine(endereco.Cep);
        
    }

    [HttpGet]
    public IEnumerable<Endereco> LeEndereco()
    {
        return enderecos;
    }

    [HttpGet("{id}")]
    public Endereco? ProcuraEnderecoPorId(int id)
    {
        return enderecos.FirstOrDefault(endereco => endereco.Id == id);
    }
}
