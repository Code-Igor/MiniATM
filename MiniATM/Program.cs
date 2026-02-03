// 
using MiniATM.Application;
using MiniATM.Domain;


// metodos
static void Pausar()
{
    Console.WriteLine("\nPress any key to continue...");
    Console.ReadKey();
}


static void CriarConta (ContaService contaService, string numero) 
{
    contaService.CriarConta(numero);
}

static Conta ConsultarConta(ContaService contaService, int contaId)
{
    return contaService.ObterConta(contaId);
}




// console 

bool executar = true;

while (executar)
{
    Console.Clear();
    Console.WriteLine("=== MINI ATM ===");
    Console.WriteLine("1 - Create Account");
    Console.WriteLine("2 - View Account");
    Console.WriteLine("3 - View Balance");
    Console.WriteLine("4 - Deposit");
    Console.WriteLine("5 - Withdraw");
    Console.WriteLine("0 - Exit");
    Console.Write("Choose an option: ");

    string opcao = Console.ReadLine();

    try
    {
        switch (opcao)
        {
            case "1":
                Console.WriteLine();
                break;

            case "2":
                break;

            case "3":
                break;

            case "4":
                
                break;

            case "5":
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
