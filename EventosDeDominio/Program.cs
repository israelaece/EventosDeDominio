using EventosDeDominio.CentralDeRisco;
using EventosDeDominio.Varejo;
using System;

namespace EventosDeDominio
{
    class Program
    {
        static void Main(string[] args)
        {
            //var monitor = new MonitorDeClientes();
            //DomainEvents.Register<SaldoDaContaAlterado>(monitor.Handle);
            var repositorio = new RepositorioDeContas();

            var cc = new ContaCorrente("Israel Aece");
            cc.Lancar(new ContaCorrente.Lancamento("Pagto de Energia", -1000));

            repositorio.Atualizar(cc);

            //Console.WriteLine(monitor.ClientesMonitorados.Count);
        }
    }
}