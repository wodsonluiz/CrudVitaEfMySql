using CrudProjectVita.Models;
using CrudVitaEfMySql;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Linq;
using System.Threading.Tasks;

public class PessoaFisicaService : IPessoaFisica
{
    private readonly AppDbContext _context;
    public PessoaFisicaService(AppDbContext context)
    {
        _context = context;
    }
    public async Task<ResponseOperation> Delete(int id)
    {
        try
        {
            var pessoaFisica = await _context.PessoaFisicas.FindAsync(id);

            if (pessoaFisica != null)
            {
                _context.Remove(pessoaFisica);
                await _context.SaveChangesAsync();


            }
            return new ResponseOperation() { Msg = "", Result = ResultEnum.Success };
        }
        catch (Exception ex)
        {
            return new ResponseOperation() { Msg = ex.Message, Result = ResultEnum.Fail };
        }
    }
    public async Task<ResponseOperation> Edit(int id, PessoaFisica pessoa)
    {
        try
        {
            if (id != pessoa.PessoaFisicaId)
            {
                return new ResponseOperation() { Msg = "", Result = ResultEnum.NotFund };
            }

            _context.Update(pessoa);
            await _context.SaveChangesAsync();
        }
        catch (Exception dbex)
        {
            if (!PessoaFisicaExists(pessoa.PessoaFisicaId))
            {
                return new ResponseOperation() { Msg = dbex.Message, Result = ResultEnum.NotFund };
            }
        }

        return new ResponseOperation() { Msg = "", Result = ResultEnum.Success };
    }
    public async Task<ResponseOperation> Include(PessoaFisica pessoa)
    {
        try
        {
            await _context.AddAsync(pessoa);
            await _context.SaveChangesAsync();

            return new ResponseOperation() { Msg = "", Result = ResultEnum.Success };
        }
        catch (Exception ex)
        {
            return new ResponseOperation() { Msg = ex.Message, Result = ResultEnum.Fail };
        }
    }
    public async Task<IEnumerable> List()
    {
        return await _context.PessoaFisicas.ToListAsync();
    }
    private bool PessoaFisicaExists(int id)
    {
        return _context.PessoaFisicas.Any(e => e.PessoaFisicaId == id);
    }
    public async Task<PessoaFisica> FindPessoaFisica(int? id)
    {
        return await _context.PessoaFisicas.FirstOrDefaultAsync(p => p.PessoaFisicaId == id);
    }
}