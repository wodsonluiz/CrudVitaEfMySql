using System.ComponentModel.DataAnnotations;

namespace CrudProjectVita.Core.Models
{
    public class PessoaJuridica : Pessoa
    {
        public PessoaJuridica()
        {

        }
        public int PessoaJuridicaId { get; set; }
        [Required(ErrorMessage = "Preencher CNPJ")]
        public string Cnpj { get; set; }
        [Required(ErrorMessage = "Preencher Razão Social")]
        public string RazaoSocial { get; set; }
        [Required(ErrorMessage = "Preencher Nome Fantasia")]
        public string NomeFantasia { get; set; }
    }
}