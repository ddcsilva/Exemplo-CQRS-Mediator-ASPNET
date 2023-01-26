using ExemploMediator.Application.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExemploMediator.Repositories
{
    public class PessoaRepository : IRepository<Pessoa>
    {
        private static Dictionary<int, Pessoa> pessoas = new Dictionary<int, Pessoa>();

        public async Task<IEnumerable<Pessoa>> RetornarTodos()
        {
            return await Task.Run(() => pessoas.Values.ToList());
        }

        public async Task<Pessoa> Retornar(int id)
        {
            return await Task.Run(() => pessoas.GetValueOrDefault(id));
        }

        public async Task<Pessoa> Adicionar(Pessoa pessoa)
        {
            return await Task.Run(() => {
                var id = pessoas.Count() + 1;
                pessoa.Id = id;
                pessoas.Add(id, pessoa);
                return pessoa;
            });
        }

        public async Task Editar(Pessoa pessoa)
        {
            await Task.Run(() =>
            {
                pessoas.Remove(pessoa.Id);
                pessoas.Add(pessoa.Id, pessoa);
            });
        }

        public async Task Excluir(int id)
        {
            await Task.Run(() => pessoas.Remove(id));
        }
    }
}
