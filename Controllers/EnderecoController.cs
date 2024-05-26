using AutoMapper;
using GerenciadorDeEnderecos.Data;
using GerenciadorDeEnderecos.Data.DTOs;
using GerenciadorDeEnderecos.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;


namespace GerenciadorDeEnderecos.Controllers;

[ApiController]
[Route("[Controller]")]
public class EnderecoController : ControllerBase
{

    private EnderecoContext _context;
    private IMapper _mapper;

    public EnderecoController(EnderecoContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpPost]
    public IActionResult AdicionaEndereco([FromBody] CreateEnderecoDto enderecoDto)
    {

        Endereco endereco = _mapper.Map<Endereco>(enderecoDto);
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

    [HttpPut("{id}")]
    public IActionResult AtualizaEndereco(int id, [FromBody] UpdateEnderecoDto enderecoDto)
    {
        var endereco = _context.Enderecos.FirstOrDefault(endereco => endereco.Id == id);
        if (endereco == null) return NotFound();
        _mapper.Map(enderecoDto, endereco);
        _context.SaveChanges();
        return NoContent();
    }

    [HttpPatch("{id}")]
    public IActionResult AtualizaEnderecoParcialmente(int id, JsonPatchDocument<UpdateEnderecoDto> patch)
    {
        var endereco = _context.Enderecos.FirstOrDefault(endereco => endereco.Id == id);
        if (endereco == null)
        {
            return NotFound();
        }
        else
        {
            var enderecoAtualizado = _mapper.Map<UpdateEnderecoDto>(endereco);
            patch.ApplyTo(enderecoAtualizado, ModelState);
            if(!TryValidateModel(enderecoAtualizado))
            {
                return ValidationProblem(ModelState);
            }else
            {
                _mapper.Map(enderecoAtualizado, endereco);
                _context.SaveChanges();
                return NoContent();
            }

        }
    }

    [HttpDelete("{id}")]
    public IActionResult DeletaEndereco(int id)
    {
        var endereco = _context.Enderecos.FirstOrDefault(endereco => endereco.Id == id);
        if (endereco == null) return NotFound();
        _context.Remove(endereco);
        _context.SaveChanges();
        return NoContent();
    }
  }
