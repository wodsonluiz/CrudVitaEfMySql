using System.ComponentModel.DataAnnotations;

namespace CrudProjectVita.Models
{
    public class Pessoa
    {
        [Required(ErrorMessage = "Preencher CEP")]
        public string CEP { get; set; }
        [Required(ErrorMessage = "Preencher Logradouro")]
        public string Logradouro { get; set; }
        [Required(ErrorMessage = "Preencher Numero")]
        public string Numero { get; set; }
        public string Complemento { get; set; }
        [Required(ErrorMessage = "Preencher Bairro")]
        public string Bairro { get; set; }
        [Required(ErrorMessage = "Preencher Cidade")]
        public string Cidade { get; set; }
        [Required(ErrorMessage = "Preencher UF")]
        public string Uf { get; set; }
    }
}