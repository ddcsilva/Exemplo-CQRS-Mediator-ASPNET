using MediatR;

namespace ExemploMediator.Application.Notifications
{
    public class PessoaExcluidaNotification : INotification
    {
        public int Id { get; set; }
        public bool Efetivado { get; set; }
    }
}
