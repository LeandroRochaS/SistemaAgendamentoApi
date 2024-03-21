using Microsoft.EntityFrameworkCore;
using TrilhaApiDesafio.Context;
using TrilhaApiDesafio.Models;

namespace TrilhaApiDesafio.Repositories
{
    public class TarefaRepository : ITarefaRepository
    {
        private readonly OrganizadorContext _context;

        public TarefaRepository(OrganizadorContext context)
        {
            _context = context;
        }

        public async Task<Tarefa> Atualizar(Tarefa tarefa)
        {
            Tarefa tarefaObj = await ObterPorId(tarefa.Id);
            if (tarefa == null)
            {
                return null;
            }

            tarefaObj.Id = tarefa.Id;
            tarefaObj.Titulo = tarefa.Titulo;
            tarefaObj.Descricao = tarefa.Descricao;
            tarefaObj.Data = tarefa.Data;
            tarefaObj.Status = tarefa.Status;

            _context.Tarefas.Update(tarefaObj);
            await _context.SaveChangesAsync();

            return tarefaObj;

        }

        public async Task<Tarefa> Criar(Tarefa tarefa)
        {
            _context.Tarefas.Add(tarefa);
            await _context.SaveChangesAsync();
            return tarefa;
        }

        public async Task<bool> Deletar(int id)
        {
            Tarefa tarefaObj = await ObterPorId(id);
            if (tarefaObj == null)
            {
                return false;
            }

            _context.Tarefas.Remove(tarefaObj);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<List<Tarefa>> ObterPorData(DateTime data)
        {
            var listTarefas = await _context.Tarefas.Where(x => x.Data == data).ToListAsync();
            return listTarefas;
        }

        public async  Task<Tarefa> ObterPorId(int id)
        {
            var tarefa = await _context.Tarefas.FirstOrDefaultAsync(x => x.Id == id);

            return tarefa;
        }

        public async Task<List<Tarefa>> ObterPorStatus(EnumStatusTarefa status)
        {
            var listTarefas = await _context.Tarefas.Where(x => x.Status == status).ToListAsync();

            return listTarefas;
        }

        public async Task<List<Tarefa>> ObterPorTitulo(string titulo)
        {
            var listTarefas = await _context.Tarefas.Where(x => x.Titulo == titulo).ToListAsync();
            return listTarefas;
        }

        public async Task<List<Tarefa>> ObterTodos()
        {
            var listTarefas = await _context.Tarefas.ToListAsync();
            return listTarefas;
        }
    }
}
