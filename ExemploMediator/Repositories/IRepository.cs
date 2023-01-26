using System.Collections.Generic;
using System.Threading.Tasks;

namespace ExemploMediator.Repositories
{
    public interface IRepository<T>
    {
        Task<IEnumerable<T>> RetornarTodos();
        Task<T> Retornar(int id);
        Task<T> Adicionar(T item);
        Task Editar(T item);
        Task Excluir(int id);
    }
}
