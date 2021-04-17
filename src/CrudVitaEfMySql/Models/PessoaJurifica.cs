namespace CrudProjectVita.Models
{
    public class PessoaJuridica : Pessoa
    {
        public PessoaJuridica()
        {

        }
        public int PessoaJuridicaId { get; set; }
        public string Cnpj { get; set; }
        public string CompanyName { get; set; }
        public string FantansyName { get; set; }
    }
}