using Microsoft.EntityFrameworkCore;
using Teste_Codificar.Data;
using Teste_Codificar.Models;

namespace Teste_Codificar.Services
{
    public class DistribuicaoAutomaticaService
    {
        private readonly AppDbContext _context;

        public DistribuicaoAutomaticaService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Responsavel?> ObterResponsavelComMenosChamadosAsync()
        {
            return await _context.Responsaveis
                .OrderBy(r => _context.Chamados.Count(c =>
                    c.ResponsavelId == r.Id &&
                    (c.Status == StatusChamado.Aberto ||
                     c.Status == StatusChamado.EmAndamento)))
                .ThenBy(r => r.Nome)
                .FirstOrDefaultAsync();
        }
    }
}