﻿using System.ComponentModel.DataAnnotations;

namespace GerenciadorDeEnderecos.Models;

public class Endereco
{

    [Key]
    [Required]
    public int Id { get; set; }

    [Required(ErrorMessage = "O campo cep não pode ficar em branco")]
    [MaxLength(8, ErrorMessage = "O Cep deve conter 8 caracteres")]
    public string Cep { get; set; }
    [Required(ErrorMessage = "O campo Logradouro não pode ficar em branco")]
    public string Logradouro { get; set; }
    public string Complemento { get; set; }
    [Required(ErrorMessage = "O campo Bairro não pode ficar em branco")]
    public string Bairro { get; set; }
    [Required(ErrorMessage = "O campo Cidade não pode ficar em branco")]
    public string Cidade { get; set; }
    [Required(ErrorMessage = "O campo UF deve não pode ficar em branco")]
    public string Uf { get; set; }
    [Required(ErrorMessage = "O campo Numero deve não pode ficar em branco")]
    public int Numero { get; set; }
}
