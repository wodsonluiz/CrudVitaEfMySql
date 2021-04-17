using System.Threading.Tasks;
using CrudProjectVita.Models;
using CrudVitaEfMySql;

public class PessoaFisicaService : IPessoaFisica
{
    private readonly AppDbContext _context;
    public PessoaFisicaService(AppDbContext context)
    {
        _context = context;
    }
    public async Task<bool> Delete(int id)
    {
        try
        {
            var pessoaFisica = await _context.PessoaFisicas.FindAsync(id);

            if(pessoaFisica != null)
            {
                _context.Remove(pessoaFisica);
            }
            return true;
        }
        catch (System.Exception)
        {
            return false;
        }
    }


    public Task<bool> Edit(int id, PessoaFisica pessoa)
    {
        throw new System.NotImplementedException();
    }

    public Task<bool> Include(PessoaFisica pessoa)
    {
        throw new System.NotImplementedException();
    }

    public Task<bool> List()
    {
        throw new System.NotImplementedException();
    }
}