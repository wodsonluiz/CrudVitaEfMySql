using System;

namespace CrudProjectVita.Models
{
    public class PessoaFisica : Pessoa
    {
        public PessoaFisica()
        {
            
        }
        public PessoaFisica(string cpf, 
            DateTime dataNascimento, 
            string nome, 
            string sobreNome, 
            string cep, 
            string logradouro, 
            string numero, 
            string complemento, 
            string bairro, 
            string cidade, 
            string uf
            )
        {
            Cpf = cpf;
            DataNascimento = dataNascimento;
            Nome = nome;
            SobreNome = sobreNome;
            CEP = cep;
            Logradouro = logradouro;
            Numero = numero;
            Complemento = complemento;
            Bairro = bairro;
            Cidade = cidade;
            Uf = uf;
        }
        public int PessoaFisicaId { get; set; }
        public string Cpf {set; get;}
        public DateTime DataNascimento { get; set; }
        public string Nome { get; set; }
        public string SobreNome  { get; set; }
    }
}