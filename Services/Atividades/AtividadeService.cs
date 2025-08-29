using Kanban.data;
using Kanban.Dto;
using Kanban.Models;
using Microsoft.EntityFrameworkCore;

namespace Kanban.Services.Atividades
{
    // sempre que uso o async devo encapsular minha função com o Task<>
    // até mesmo se n for retorar nada
    /**
    *
        Task<T>: representa a operação que ainda não terminou.
        await Task<T>: espera a operação terminar e retorna o valor de T.
        Portanto, se você já usou await, não precisa declarar a variável como Task<List<Atividade>>, só List<Atividade> mesmo.
        o await faz o "unwrapping" do Task<T> para T.
    *
    **/
    public class AtividadeService : IAtividadeService
    {
        private readonly AppDbContext _context;

        // dependency injection
        public AtividadeService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Atividade>> BuscarAtividades()
        {
            try
            {
                // Returns: A List<T> that contains elements from the input sequence.
                // to fullfill the Status property we need to use include.
                List<Atividade> atividades = await _context.Atividades.Include(x => x.Status).ToListAsync();
                return atividades;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao buscar atividades: " + ex.Message);
            }
        }

        public async Task<List<Status>> BuscarStatus()
        {
            try
            {
                List<Status> status = await _context.Status.ToListAsync();
                return status;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao buscar status: " + ex.Message);
            }
        }

        public async Task<Atividade> CadastrarAtividade(AtividadeDto atividadeDto)
        {
            try
            {
                Random rand = new Random();

                Atividade currActivity = new Atividade
                {
                    Matricula = rand.Next(1000, 1000000),
                    Titulo = atividadeDto.Titulo,
                    Descricao = atividadeDto.Descricao,
                    StatusId = atividadeDto.StatusId
                };

                _context.Atividades.Add(currActivity);
                await _context.SaveChangesAsync();

                return currActivity;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao cadastrar atividade: " + ex.Message);
            }
        }
    }
}