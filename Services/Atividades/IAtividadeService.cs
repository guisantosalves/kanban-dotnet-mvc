using Kanban.Dto;
using Kanban.Models;

namespace Kanban.Services.Atividades
{
    public interface IAtividadeService
    {
        Task<List<Atividade>> BuscarAtividades();
        Task<List<Status>> BuscarStatus();
        Task<Atividade> CadastrarAtividade(AtividadeDto atividadeDto);

    }
}