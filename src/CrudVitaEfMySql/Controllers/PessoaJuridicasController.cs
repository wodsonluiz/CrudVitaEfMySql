using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CrudProjectVita.Models;
using CrudVitaEfMySql;

namespace CrudVitaEfMySql.Controllers
{
    public class PessoaJuridicasController : Controller
    {
        private readonly AppDbContext _context;

        public PessoaJuridicasController(AppDbContext context)
        {
            _context = context;
        }

        // GET: PessoaJuridicas
        public async Task<IActionResult> Index()
        {
            return View(await _context.PessoaJuridicas.ToListAsync());
        }

        // GET: PessoaJuridicas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pessoaJuridica = await _context.PessoaJuridicas
                .FirstOrDefaultAsync(m => m.PessoaJuridicaId == id);
            if (pessoaJuridica == null)
            {
                return NotFound();
            }

            return View(pessoaJuridica);
        }

        // GET: PessoaJuridicas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PessoaJuridicas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PessoaJuridicaId,Cnpj,CompanyName,FantansyName,CEP,Logradouro,Numero,Complemento,Bairro,Cidade,Uf")] PessoaJuridica pessoaJuridica)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pessoaJuridica);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pessoaJuridica);
        }

        // GET: PessoaJuridicas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pessoaJuridica = await _context.PessoaJuridicas.FindAsync(id);
            if (pessoaJuridica == null)
            {
                return NotFound();
            }
            return View(pessoaJuridica);
        }

        // POST: PessoaJuridicas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PessoaJuridicaId,Cnpj,CompanyName,FantansyName,CEP,Logradouro,Numero,Complemento,Bairro,Cidade,Uf")] PessoaJuridica pessoaJuridica)
        {
            if (id != pessoaJuridica.PessoaJuridicaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pessoaJuridica);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PessoaJuridicaExists(pessoaJuridica.PessoaJuridicaId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(pessoaJuridica);
        }

        // GET: PessoaJuridicas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pessoaJuridica = await _context.PessoaJuridicas
                .FirstOrDefaultAsync(m => m.PessoaJuridicaId == id);
            if (pessoaJuridica == null)
            {
                return NotFound();
            }

            return View(pessoaJuridica);
        }

        // POST: PessoaJuridicas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pessoaJuridica = await _context.PessoaJuridicas.FindAsync(id);
            _context.PessoaJuridicas.Remove(pessoaJuridica);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PessoaJuridicaExists(int id)
        {
            return _context.PessoaJuridicas.Any(e => e.PessoaJuridicaId == id);
        }
    }
}
