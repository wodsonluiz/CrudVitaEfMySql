using System.Threading.Tasks;
using CrudProjectVita.Models;

public interface IPessoaFisica
{
     Task<bool> Include(PessoaFisica pessoa);
     Task<bool> Delete(int id);
     Task<bool> List();
     Task<bool> Edit(int id, PessoaFisica pessoa);
     
}