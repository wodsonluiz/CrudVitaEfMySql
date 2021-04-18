using System;
using System.ComponentModel.DataAnnotations;

namespace CrudProjectVita.Models
{
    public class PessoaFisica : Pessoa
    {
        public PessoaFisica()
        {

        }
        public int PessoaFisicaId { get; set; }

        [Required(ErrorMessage = "Preencher CPF")]
        public string Cpf { set; get; }
        [Required(ErrorMessage = "Preencher Data Nascimento")]
        public DateTime DataNascimento { get; set; }
        [Required(ErrorMessage = "Preencher Nome")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Preencher Sobrenome")]
        public string SobreNome { get; set; }
    }
}