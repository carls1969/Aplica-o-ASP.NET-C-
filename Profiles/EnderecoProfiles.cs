using AutoMapper;
using GerenciadorDeEnderecos.Data.DTOs;
using GerenciadorDeEnderecos.Models;

namespace GerenciadorDeEnderecos.Profiles;

public class EnderecoProfile : Profile
{
    public EnderecoProfile()
    {
        CreateMap<CreateEnderecoDto, Endereco>();
        CreateMap<UpdateEnderecoDto, Endereco>();
        CreateMap<Endereco, UpdateEnderecoDto>();

    }
}
