﻿using MediatR;

namespace ExemploMediator.Application.Notifications
{
    public class PessoaAlteradaNotification : INotification
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int Idade { get; set; }
        public char Sexo { get; set; }
        public bool Efetivado { get; set; }
    }
}
