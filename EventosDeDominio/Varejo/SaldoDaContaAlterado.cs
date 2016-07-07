namespace EventosDeDominio.Varejo
{
    public class SaldoDaContaAlterado : IDomainEvent
    {
        public SaldoDaContaAlterado(
            string nomeDoCliente, decimal saldoAnterior, decimal saldoAtual)
        {
            this.NomeDoCliente = nomeDoCliente;
            this.SaldoAnterior = saldoAnterior;
            this.SaldoAtual = saldoAtual;
        }

        public string NomeDoCliente { get; private set; }

        public decimal SaldoAnterior { get; private set; }

        public decimal SaldoAtual { get; private set; }
    }
}