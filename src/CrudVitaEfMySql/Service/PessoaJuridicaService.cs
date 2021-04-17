using CrudProjectVita.Models;
using CrudVitaEfMySql.Abstrations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Linq;
using System.Threading.Tasks;

namespace CrudVitaEfMySql.Service
{
    public class PessoaJuridicaService : IPessoaJuridica
    {
        private readonly AppDbContext _context;

        public PessoaJuridicaService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseOperation> Delete(int id)
        {
            try
            {
                var pessoaJuridica = await _context.PessoaJuridicas.FindAsync(id);

                if (pessoaJuridica != null)
                {
                    _context.Remove(pessoaJuridica);
                    await _context.SaveChangesAsync();
                }
                return new ResponseOperation() { Msg = "", Result = ResultEnum.Success };
            }
            catch (Exception ex)
            {
                return new ResponseOperation() { Msg = ex.Message, Result = ResultEnum.Fail };
            }
        }

        public async Task<ResponseOperation> Edit(int id, PessoaJuridica pessoaJuridica)
        {
            try
            {
                if (id != pessoaJuridica.PessoaJuridicaId)
                {
                    return new ResponseOperation() { Msg = "", Result = ResultEnum.NotFund };
                }

                _context.Update(pessoaJuridica);
                await _context.SaveChangesAsync();
            }
            catch (Exception dbex)
            {
                if (!PessoaJuridicaExists(pessoaJuridica.PessoaJuridicaId))
                {
                    return new ResponseOperation() { Msg = dbex.Message, Result = ResultEnum.NotFund };
                }
            }

            return new ResponseOperation() { Msg = "", Result = ResultEnum.Success };
        }

        public async Task<PessoaJuridica> FindPessoaJuridica(int? id)
        {
            return await _context.PessoaJuridicas.FirstOrDefaultAsync(p => p.PessoaJuridicaId == id);
        }

        public async Task<ResponseOperation> Include(PessoaJuridica pessoaJuridica)
        {
            try
            {
                await _context.AddAsync(pessoaJuridica);
                await _context.SaveChangesAsync();

                return new ResponseOperation() { Msg = "", Result = ResultEnum.Success };
            }
            catch (Exception ex)
            {
                return new ResponseOperation() { Msg = ex.Message, Result = ResultEnum.Success };
            }
        }

        public async Task<IEnumerable> List()
        {
            return await _context.PessoaJuridicas.ToListAsync();
        }

        private bool PessoaJuridicaExists(int id)
        {
            return _context.PessoaJuridicas.Any(p => p.PessoaJuridicaId == id);
        }
    }
}
