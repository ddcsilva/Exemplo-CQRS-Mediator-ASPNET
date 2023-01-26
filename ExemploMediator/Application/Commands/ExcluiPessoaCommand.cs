using MediatR;

namespace ExemploMediator.Application.Commands
{
    public class ExcluiPessoaCommand : IRequest<string>
    {
        public int Id { get; set; }
    }
}
