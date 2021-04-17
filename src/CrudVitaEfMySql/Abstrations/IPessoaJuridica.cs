using CrudProjectVita.Models;
using System.Collections;
using System.Threading.Tasks;

namespace CrudVitaEfMySql.Abstrations
{
    public interface IPessoaJuridica
    {
        Task<ResponseOperation> Include(PessoaJuridica pessoaJuridica);
        Task<ResponseOperation> Delete(int id);
        Task<IEnumerable> List();
        Task<ResponseOperation> Edit(int id, PessoaJuridica pessoa);
        Task<PessoaJuridica> FindPessoaJuridica(int? id);
    }
}
