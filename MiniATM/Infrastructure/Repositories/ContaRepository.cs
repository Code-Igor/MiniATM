using Microsoft.EntityFrameworkCore;
using MiniATM.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniATM.Infrastructure.Repositories
{
    internal class ContaRepository
    {
        private readonly AppDbContext _context;

        public ContaRepository(AppDbContext context)
        {
            _context = context;
        }

        public Conta? ObterPorId(int id)
        {
            return _context.Contas
                           .Include(c => c.Transacoes)
                           .FirstOrDefault(c => c.Id == id);
        }

        public void Adicionar(Conta conta)
        {
            _context.Contas.Add(conta);
        }

        public void Atualizar(Conta conta)
        {
            _context.Contas.Update(conta);
        }

        public void Salvar()
        {
            _context.SaveChanges();
        }
    }
}
