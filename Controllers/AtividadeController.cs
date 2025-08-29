using Kanban.Services.Atividades;
using Microsoft.AspNetCore.Mvc;

namespace Kanban.Controllers
{
    public class AtividadeController : Controller
    {
        public readonly IAtividadeService _atividadeService;

        public AtividadeController(IAtividadeService atividadeService)
        {
            _atividadeService = atividadeService;
        }

        public async Task<IActionResult> Index()
        {
            var atividades = await _atividadeService.BuscarAtividades();
            return View(atividades);
        }
    }
}