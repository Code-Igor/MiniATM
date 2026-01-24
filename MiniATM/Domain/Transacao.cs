using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniATM.Domain
{
    internal class Transacao
    {
        public int Id { get; private set; }

        public int ContaId { get; private set; }
        public Conta Conta { get; private set; } = null!;

        public TipoTransacao Tipo { get; private set; }
        public decimal Valor { get; private set; }
        public DateTime Data { get; private set; }

        private Transacao() { }

        public Transacao(TipoTransacao tipo, decimal valor)
        {
            Tipo = tipo;
            Valor = valor;
            Data = DateTime.UtcNow;
        }

    }
}
