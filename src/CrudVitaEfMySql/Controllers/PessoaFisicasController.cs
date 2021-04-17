using CrudProjectVita.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CrudVitaEfMySql.Controllers
{
    public class PessoaFisicasController : Controller
    {
        private readonly IPessoaFisica _service;

        public PessoaFisicasController(IPessoaFisica service)
        {
            _service = service;
        }

        // GET: PessoaFisicas
        public async Task<IActionResult> Index()
        {
            return View(await _service.List());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pessoaFisica = await _service.FindPessoaFisica(id);

            if (pessoaFisica == null)
            {
                return NotFound();
            }

            return View(pessoaFisica);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PessoaFisicaId,Cpf,DataNascimento,Nome,SobreNome,CEP,Logradouro,Numero,Complemento,Bairro,Cidade,Uf")] PessoaFisica pessoaFisica)
        {
            if (ModelState.IsValid)
            {
                await _service.Include(pessoaFisica);
                return RedirectToAction(nameof(Index));
            }
            return View(pessoaFisica);
        }

        // GET: PessoaFisicas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pessoaFisica = await _service.FindPessoaFisica(id);
            if (pessoaFisica == null)
            {
                return NotFound();
            }
            return View(pessoaFisica);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PessoaFisicaId,Cpf,DataNascimento,Nome,SobreNome,CEP,Logradouro,Numero,Complemento,Bairro,Cidade,Uf")] PessoaFisica pessoaFisica)
        {
            if (id != pessoaFisica.PessoaFisicaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var result = await _service.Edit(id, pessoaFisica);

                if (result.Result != ResultEnum.Success)
                {
                    return BadRequest();
                }

                return RedirectToAction(nameof(Index));
            }
            return View(pessoaFisica);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pessoaFisica = await _service.FindPessoaFisica(id);

            if (pessoaFisica == null)
            {
                return NotFound();
            }

            return View(pessoaFisica);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _service.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
