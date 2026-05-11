using ControleDeMedicamentos.ConsoleApp.Compartilhado;

namespace ControleDeMedicamentos.ConsoleApp.ModuloFornecedores;

public class TelaFornecedor : TelaBase<Fornecedor>, ITelaOpcoes, ITelaCrud
{
    public TelaFornecedor(IRepositorio<Fornecedor> repositorio) : base("Fornecedor", repositorio)
    {
    }

    public override void VisualizarTodos(bool deveExibirCabecalho)
    {
        if (deveExibirCabecalho)
            ExibirCabecalho("Visualização de Fornecedores");

        List<Fornecedor> fornecedores = repositorio.SelecionarTodos();

        if (fornecedores.Count == 0)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Não existe nenhum registro.");
            Console.ResetColor();
            Console.WriteLine("---------------------------------");
            Console.Write("Digite ENTER para continuar...");
            Console.ReadLine();
            return;
        }

        Console.WriteLine(
            "{0, -7} | {1, -20} | {2, -20} | {3, -20}",
            "Id", "Nome", "Telefone", "CNPJ"
        );

        foreach (Fornecedor f in fornecedores)
        {            
            Console.WriteLine(
                "{0, -7} | {1, -20} | {2, -20} | {3, -20}",
                f.Id, f.Nome, f.Telefone, f.Cnpj
            );
        }

        if (deveExibirCabecalho)
        {
            Console.WriteLine("---------------------------------");
            Console.Write("Digite ENTER para continuar...");
            Console.ReadLine();
        }        

    }

    protected override Fornecedor ObterDadosCadastrais()
    {
        Console.Write("Digite o nome do fornecedor: ");
        string nome = Console.ReadLine() ?? string.Empty;          

        Console.Write("Digite o número de telefone do fornecedor: ");
        string telefone = Console.ReadLine() ?? string.Empty;

        Console.Write("Digite o número do CNPJ do fornecedor: ");
        string cnpj = Console.ReadLine() ?? string.Empty;    

        return new Fornecedor(nome, telefone, cnpj);
    }
}
