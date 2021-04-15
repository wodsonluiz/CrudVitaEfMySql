namespace CrudProjectVita.Models
{
    public class PessoaJuridica : Pessoa
    {
        public PessoaJuridica()
        {
            
        }
        public int PessoaJuridicaId { get; set; }
        public string Cnpj { get; set; }
        public int CompanyName { get; set; }
        public int FantansyName { get; set; }
    }
}