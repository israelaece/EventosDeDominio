using EventosDeDominio.Varejo;
using System;
using System.Collections.Generic;

namespace EventosDeDominio.CentralDeRisco
{
    public class MonitorDeClientes : IHandler<SaldoDaContaAlterado>
    {
        public readonly List<string> ClientesMonitorados = new List<string>();

        public void Handle(SaldoDaContaAlterado @event)
        {
            if (@event.SaldoAtual < @event.SaldoAnterior)
                this.ClientesMonitorados.Add(@event.NomeDoCliente);
        }
    }
}