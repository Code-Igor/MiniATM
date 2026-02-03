using MiniATM.Domain;
using MiniATM.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniATM.Application
{
    internal class ContaService
    {

        private readonly ContaRepository _contaRepository;

        private ContaService _contaService; 


        public ContaService(ContaRepository contaRepository)
        {
            _contaRepository = contaRepository;
        }

        public Conta CriarConta(string numero)
        {
            var conta = new Conta(numero);
            _contaRepository.Adicionar(conta);
            return conta;
        }

        public void Depositar(int contaId, decimal valor) 
        {
            if (valor <= 0)
                throw new ArgumentException("Withdraw value must be positive.");

            var conta = _contaService.ObterConta(contaId);

            conta.Depositar(valor);
            _contaRepository.Atualizar(conta);
        }


        public void Sacar(decimal valor, int contaId) 
        {
            if (valor <= 0)
                throw new ArgumentException("Withdraw value must be positive.");

            var conta = _contaService.ObterConta(contaId);

            conta.Sacar(valor);
            _contaRepository.Atualizar(conta);
        }

        public decimal ObterSaldo(int contaId)
        {
            var conta = _contaService.ObterConta(contaId);
            var saldo = conta.Saldo;
            return saldo;
        }

        public Conta? ObterConta(int contaId)
        {
            return _contaRepository.ObterPorId(contaId);
        }
    }
}
