using TrilhaApiDesafio.Context;
using TrilhaApiDesafio.Models;

namespace TrilhaApiDesafio.Repositories
{
    public interface ITarefaRepository
    {



        Task<Tarefa> ObterPorId(int id);
        Task<Tarefa> Criar(Tarefa tarefa);
        Task<Tarefa> Atualizar(Tarefa tarefa);
        Task<bool> Deletar(int id);
        Task<List<Tarefa>> ObterTodos();
        Task<List<Tarefa>> ObterPorTitulo(string titulo);
        Task<List<Tarefa>> ObterPorData(DateTime data);
        Task<List<Tarefa>> ObterPorStatus(EnumStatusTarefa status);


    }
}
