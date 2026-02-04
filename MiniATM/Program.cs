// 
using Microsoft.EntityFrameworkCore;
using MiniATM.Infrastructure.Repositories;
using MiniATM.Application;
using MiniATM.Infrastructure;
using MiniATM.Domain;
using System.Reflection;
using System.Runtime.CompilerServices;


// criando instancias
AppDbContext appDbContext = new AppDbContext();
ContaRepository contaRepository = new ContaRepository(appDbContext);
ContaService contaService = new ContaService(contaRepository);


// aplica migrações em tempo de execução para criar o banco/tabelas se necessário
try
{
    appDbContext.Database.Migrate();
}
catch (Exception ex)
{
    Console.WriteLine($"Database migration error: {ex.Message}");
}


// metodos
static void Pausar()
{
    Console.WriteLine("\nPress any key to continue...");
    Console.ReadKey();
}



static Conta CriarConta(ContaService contaService, string numero)
{
    var conta = contaService.CriarConta(numero);
    return conta;
}


static decimal ConsultarSaldo(ContaService contaService, int contaId)
{
    return contaService.ObterSaldo(contaId);
}

static void Depositar(ContaService contaService, int contaId, decimal valor)
{
    contaService.Depositar(contaId, valor);
}
 


// console 

bool executar = true;

while (executar)
{
    Console.Clear();
    Console.WriteLine("=== MINI ATM ===");
    Console.WriteLine("1 - Create Account");
    Console.WriteLine("2 - Enter Account");
    Console.WriteLine("0 - Exit");

    Console.Write("Choose an option: ");
    string opcao = Console.ReadLine() ?? string.Empty;


    try
    {
        switch (opcao)
        {
            case "1":
                Console.Write("Please, give a number for your account: ");
                string numeroConta = Console.ReadLine() ?? string.Empty;
                if (!string.IsNullOrWhiteSpace(numeroConta))
                {
                    var conta = CriarConta(contaService, numeroConta);

                    Console.WriteLine("Account created with sucess, your Account id is: " + conta.Id);
                    Pausar();

                }
                else
                {
                    Console.WriteLine("The Account number cannot be null. Try again.");
                    Pausar();
                }
                break;

            case "2":

                Console.Write("Please, give your account Id: ");
                string contaId = Console.ReadLine() ?? string.Empty;
                if (int.TryParse(contaId, out int contaIdInt))
                {
                    var conta = contaService.ObterConta(contaIdInt);

                    Console.WriteLine("Account Acessed");

                    Console.WriteLine("1 - View Balance");
                    Console.WriteLine("2 - Deposit");
                    Console.WriteLine("3 - Withdraw");
                    Console.WriteLine("0 - Exit");

                    Console.Write("Choose an option: ");
                    opcao = Console.ReadLine() ?? string.Empty;

                    try
                    {
                        switch (opcao)
                        {
                            case "1":
                                var resultado = ConsultarSaldo(contaService, contaIdInt);
                                Console.Write(resultado);
                                Pausar();
                                break;

                            case "2":
                                Console.Write("How many? ");
                                string deposito = Console.ReadLine() ?? string.Empty;
                                if (decimal.TryParse(deposito, out decimal valorDeposito))
                                {
                                    Depositar(contaService, contaIdInt, valorDeposito);
                                    Console.WriteLine("Deposit successful.");
                                }
                                else
                                {
                                    Console.WriteLine("Invalid amount.");
                                }
                                Pausar();
                                break;                                      

                            case "3":
                                Console.Write("How many? ");
                                string saque = Console.ReadLine() ?? string.Empty;
                                if (decimal.TryParse(saque, out decimal valorSaque))
                                {
                                    try
                                    {
                                        contaService.Sacar(valorSaque, contaIdInt);
                                        Console.WriteLine("Withdraw successful.");
                                    }
                                    catch (Exception ex)
                                    {
                                        Console.WriteLine($"Error: {ex.Message}");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Invalid amount.");
                                }
                                Pausar();
                                break;

                            case "0":
                                executar = false;
                                break;
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error: {ex.Message}");
                        Pausar();
                    }

                }
                else
                {
                    Console.WriteLine("Invalid account Id. Please enter a valid number.");
                    Pausar();
                }
                break;

            case "0":
                executar = false;
                break;

            default:
                Console.WriteLine("Invalid option.");
                Pausar();
                break;
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error: {ex.Message}");
        Pausar();
    }
}

Console.WriteLine("Program finished.");
