using EventosDeDominio.Varejo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventosDeDominio
{
    public interface IRepositorio<T> where T : Entidade
    {
        void Adicionar(T entidade);

        void Atualizar(T entidade);

        void Remover(T entidade);

        T BuscarPorId(int id);
    }

    public class RepositorioDeContas : IRepositorio<ContaCorrente>
    {
        private readonly IList<ContaCorrente> contas = new List<ContaCorrente>();

        public void Adicionar(ContaCorrente entidade)
        {
            contas.Add(entidade);
            DispararEventos(entidade);
        }

        public void Atualizar(ContaCorrente entidade)
        {
            //Atualizar na Base de Dados

            DispararEventos(entidade);
        }

        public void Remover(ContaCorrente entidade)
        {
            this.contas.Remove(entidade);
            DispararEventos(entidade);
        }

        public ContaCorrente BuscarPorId(int id)
        {
            return this.contas.SingleOrDefault(c => c.Id == id);
        }

        private static void DispararEventos(Entidade entidade)
        {
            foreach (var evento in entidade.Eventos)
                DomainEvents.Dispatch(evento);

            entidade.RemoverEventos();
        }
    }
}