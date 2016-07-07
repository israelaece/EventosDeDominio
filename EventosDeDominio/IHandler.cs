namespace EventosDeDominio
{
    public interface IHandler<T>
        where T : IDomainEvent
    {
        void Handle(T @event);
    }
}