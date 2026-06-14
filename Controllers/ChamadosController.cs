using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Teste_Codificar.Data;
using Teste_Codificar.Models;
using Teste_Codificar.Services;

namespace Teste_Codificar.Controllers
{
    public class ChamadosController : Controller
    {
        private readonly AppDbContext _context;
        private readonly DistribuicaoAutomaticaService _distribuicaoService;

    public ChamadosController(
        AppDbContext context,
        DistribuicaoAutomaticaService distribuicaoService)
        {
            _context = context;
            _distribuicaoService = distribuicaoService;
        }

        // GET: Chamados
        public async Task<IActionResult> Index()
        {
            var chamados = await _context.Chamados
                .Include(c => c.Responsavel)
                .OrderByDescending(c => c.DataAbertura)
                .ToListAsync();

            return View(chamados);
        }

        // GET: Chamados/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return NotFound();

            var chamado = await _context.Chamados
                .Include(c => c.Responsavel)
                .FirstOrDefaultAsync(c => c.Id == id);

            if (chamado == null)
                return NotFound();

            return View(chamado);
        }

        // GET: Chamados/Create
        public IActionResult Create()
        {
            CarregarResponsaveis();

            return View(new Chamado
            {
                DataAbertura = DateTime.Now,
                Status = StatusChamado.Aberto
            });
        }

        // POST: Chamados/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(
            Chamado chamado,
            bool distribuicaoAutomatica)
        {
            if (distribuicaoAutomatica)
            {
                var responsavel =
                    await _distribuicaoService
                        .ObterResponsavelComMenosChamadosAsync();

                if (responsavel != null)
                {
                    chamado.ResponsavelId = responsavel.Id;
                }
            }

            if (ModelState.IsValid)
            {
                _context.Add(chamado);

                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            CarregarResponsaveis(chamado.ResponsavelId);

            return View(chamado);
        }

        // GET: Chamados/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();

            var chamado = await _context.Chamados.FindAsync(id);

            if (chamado == null)
                return NotFound();

            CarregarResponsaveis(chamado.ResponsavelId);

            return View(chamado);
        }

        // POST: Chamados/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(
            int id,
            Chamado chamado)
        {
            if (id != chamado.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(chamado);

                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ChamadoExists(chamado.Id))
                        return NotFound();

                    throw;
                }

                return RedirectToAction(nameof(Index));
            }

            CarregarResponsaveis(chamado.ResponsavelId);

            return View(chamado);
        }

        // GET: Chamados/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var chamado = await _context.Chamados
                .Include(c => c.Responsavel)
                .FirstOrDefaultAsync(c => c.Id == id);

            if (chamado == null)
                return NotFound();

            return View(chamado);
        }

        // POST: Chamados/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var chamado = await _context.Chamados.FindAsync(id);

            if (chamado != null)
            {
                _context.Chamados.Remove(chamado);
            }

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        private bool ChamadoExists(int id)
        {
            return _context.Chamados.Any(e => e.Id == id);
        }

        private void CarregarResponsaveis(int? responsavelSelecionado = null)
        {
            ViewBag.Responsaveis = new SelectList(
                _context.Responsaveis.OrderBy(r => r.Nome),
                "Id",
                "Nome",
                responsavelSelecionado);
        }
    }
}
