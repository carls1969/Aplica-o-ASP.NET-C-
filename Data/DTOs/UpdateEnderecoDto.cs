using System.ComponentModel.DataAnnotations;

namespace GerenciadorDeEnderecos.Data.DTOs
{
    public class UpdateEnderecoDto
    {

        [StringLength(8, ErrorMessage = "O Cep deve conter 8 caracteres")]
        public string Cep { get; set; }
        public string Logradouro { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Uf { get; set; }
        public int Numero { get; set; }
    }
}
