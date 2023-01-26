using ExemploMediator.Application.Commands;
using ExemploMediator.Application.Models;
using ExemploMediator.Application.Notifications;
using ExemploMediator.Repositories;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ExemploMediator.Application.Handlers
{
    public class ExcluiPessoaCommandHandler : IRequestHandler<ExcluiPessoaCommand, string>
    {
        private readonly IMediator _mediator;
        private readonly IRepository<Pessoa> _repository;

        public ExcluiPessoaCommandHandler(IMediator mediator, IRepository<Pessoa> repository)
        {
            this._mediator = mediator;
            this._repository = repository;
        }

        public async Task<string> Handle(ExcluiPessoaCommand request, CancellationToken cancellationToken)
        {
            try
            {
                await _repository.Excluir(request.Id);

                await _mediator.Publish(new PessoaExcluidaNotification { Id = request.Id, Efetivado = true });

                return await Task.FromResult("Pessoa excluída com sucesso");
            }
            catch (Exception ex)
            {
                await _mediator.Publish(new PessoaExcluidaNotification { Id = request.Id, Efetivado = false });
                await _mediator.Publish(new ErroNotification { Excecao = ex.Message, PilhaErro = ex.StackTrace });

                return await Task.FromResult("Ocorreu um erro no momento da exclusão");
            }
        }
    }
}
