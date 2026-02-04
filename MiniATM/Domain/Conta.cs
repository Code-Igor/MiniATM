using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniATM.Domain
{
    internal class Conta
    {
        public int Id { get; private set; }
        public string Numero { get; private set; }
        public decimal Saldo { get; private set; }
        public ICollection<Transacao> Transacoes { get; private set; }

        private Conta() 
        {
            Numero = string.Empty;
            Transacoes = new List<Transacao>();
            saque = null!;
        }

        private Transacao saque = null!;

        public Conta(string numero)
        {
            Numero = numero;
            Saldo = 0;
            Transacoes = new List<Transacao>();
            saque = null!;
        }

        public void Depositar(decimal valor)
        {
            Saldo += valor;

            Transacao deposito = new Transacao(TipoTransacao.Deposito, valor);
            Transacoes.Add(deposito);
        }

        public void Sacar(decimal valor)
        {
            if (Saldo < valor)
                throw new InvalidOperationException("Insufficient balance.");

            Saldo -= valor;

            Transacao saque = new Transacao(TipoTransacao.Saque, valor);
            Transacoes.Add(saque);
        }
    }
}
