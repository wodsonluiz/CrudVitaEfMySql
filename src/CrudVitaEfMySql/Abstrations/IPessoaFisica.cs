using CrudProjectVita.Models;
using CrudVitaEfMySql;
using System.Collections;
using System.Threading.Tasks;

public interface IPessoaFisica
{
    Task<ResponseOperation> Include(PessoaFisica pessoa);
    Task<ResponseOperation> Delete(int id);
    Task<IEnumerable> List();
    Task<ResponseOperation> Edit(int id, PessoaFisica pessoa);
    Task<PessoaFisica> FindPessoaFisica(int? id);
}