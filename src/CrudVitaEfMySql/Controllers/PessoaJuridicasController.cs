using CrudProjectVita.Models;
using CrudVitaEfMySql.Abstrations;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CrudVitaEfMySql.Controllers
{
    public class PessoaJuridicasController : Controller
    {
        private readonly IPessoaJuridica _service;
        public PessoaJuridicasController(IPessoaJuridica service)
        {
            _service = service;
        }

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

            var pessoaJuridica = await _service.FindPessoaJuridica(id);

            if (pessoaJuridica == null)
            {
                return NotFound();
            }

            return View(pessoaJuridica);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PessoaJuridicaId,Cnpj,RazaoSocial,NomeFantasia,CEP,Logradouro,Numero,Complemento,Bairro,Cidade,Uf")] PessoaJuridica pessoaJuridica)
        {
            if (ModelState.IsValid)
            {
                await _service.Include(pessoaJuridica);
                return RedirectToAction(nameof(Index));
            }
            return View(pessoaJuridica);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pessoaJuridica = await _service.FindPessoaJuridica(id);
            if (pessoaJuridica == null)
            {
                return NotFound();
            }
            return View(pessoaJuridica);
        }

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

                var result = await _service.Edit(id, pessoaJuridica);

                if (result.Result != ResultEnum.Success)
                {
                    return BadRequest();
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

            var pessoaJuridica = await _service.FindPessoaJuridica(id);

            if (pessoaJuridica == null)
            {
                return NotFound();
            }

            return View(pessoaJuridica);
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
