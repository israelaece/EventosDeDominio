using System;
using System.Linq;
using System.Collections.Generic;
using System.Reflection;

namespace EventosDeDominio
{
    //public static class DomainEvents
    //{
    //    private static List<Type> handlers = new List<Type>();

    //    static DomainEvents()
    //    {
    //        handlers =
    //            (
    //                from t in Assembly.GetExecutingAssembly().GetTypes()
    //                from i in t.GetInterfaces()
    //                where
    //                    i.IsGenericType &&
    //                    i.GetGenericTypeDefinition() == typeof(IHandler<>)
    //                select t
    //            ).ToList();
    //    }

    //    public static void Raise<T>(T @event) where T : IDomainEvent
    //    {
    //        handlers.ForEach(h =>
    //        {
    //            if (typeof(IHandler<T>).IsAssignableFrom(h))
    //                ((IHandler<T>)Activator.CreateInstance(h)).Handle(@event);
    //        });
    //    }
    //}

    //public static class DomainEvents
    //{
    //    private static Dictionary<Type, List<Delegate>> handlers =
    //        new Dictionary<Type, List<Delegate>>();

    //    static DomainEvents()
    //    {
    //        handlers =
    //            (
    //                from t in Assembly.GetExecutingAssembly().GetTypes()
    //                where
    //                    !t.IsInterface &&
    //                    typeof(IDomainEvent).IsAssignableFrom(t)
    //                select t
    //            ).ToDictionary(t => t, t => new List<Delegate>());
    //    }

    //    public static void Register<T>(Action<T> handler) where T : IDomainEvent
    //    {
    //        handlers[typeof(T)].Add(handler);
    //    }

    //    public static void Raise<T>(T @event) where T : IDomainEvent
    //    {
    //        handlers[typeof(T)].ForEach(h => ((Action<T>)h)(@event));
    //    }
    //}

    public static class DomainEvents
    {
        private static List<Type> handlers = new List<Type>();

        static DomainEvents()
        {
            handlers =
                (
                    from t in Assembly.GetExecutingAssembly().GetTypes()
                    from i in t.GetInterfaces()
                    where
                        i.IsGenericType &&
                        i.GetGenericTypeDefinition() == typeof(IHandler<>)
                    select t
                ).ToList();
        }

        public static void Dispatch(IDomainEvent @event)
        {
            foreach (var handler in handlers)
                if (handler.GetInterfaces()
                            .Any(h => h.IsGenericType && h.GenericTypeArguments[0] == @event.GetType()))
                    ((dynamic)Activator.CreateInstance(handler)).Handle((dynamic)@event);
        }
    }
}