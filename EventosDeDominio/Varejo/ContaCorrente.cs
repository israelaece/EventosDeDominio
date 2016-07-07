using System;
using System.Collections.Generic;

namespace EventosDeDominio.Varejo
{
    public class ContaCorrente : Entidade
    {
        private readonly IList<Lancamento> lancamentos;

        public ContaCorrente(string nomeDoCliente)
        {
            this.NomeDoCliente = nomeDoCliente;
            this.lancamentos = new List<Lancamento>();
        }

        public void Lancar(Lancamento lancamento)
        {
            var saldoAnterior = this.Saldo;

            this.lancamentos.Add(lancamento);
            this.Saldo += lancamento.Valor;

            this.AdicionarEvento(
                new SaldoDaContaAlterado(this.NomeDoCliente, saldoAnterior, this.Saldo));
        }

        public string NomeDoCliente { get; private set; }

        public decimal Saldo { get; private set; }

        public class Lancamento
        {
            public Lancamento(string descricao, decimal valor)
            {
                this.Data = DateTime.Now;
                this.Descricao = descricao;
                this.Valor = valor;
            }

            public DateTime Data { get; private set; }

            public string Descricao { get; private set; }

            public decimal Valor { get; private set; }
        }

        public int Id { get; set; }
    }
}