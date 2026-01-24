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
        public string Numero { get; private set; } = string.Empty;
        public decimal Saldo { get; private set; }

        public ICollection<Transacao> Transacoes { get; private set; }

        private Conta()
        {
            Transacoes = new List<Transacao>();
        }

        public Conta(string numero)
        {
            Numero = numero;
            Saldo = 0m;
            Transacoes = new List<Transacao>();
        }
    }
}
