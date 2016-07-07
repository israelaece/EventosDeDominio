using System.Collections.Generic;

namespace EventosDeDominio
{
    public abstract class Entidade
    {
        private readonly IList<IDomainEvent> eventos =
            new List<IDomainEvent>();

        protected void AdicionarEvento(IDomainEvent evento)
        {
            this.eventos.Add(evento);
        }

        public void RemoverEventos()
        {
            this.eventos.Clear();
        }

        public IEnumerable<IDomainEvent> Eventos
        {
            get
            {
                return this.eventos;
            }
        }
    }
}