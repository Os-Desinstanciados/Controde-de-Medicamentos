using System;
using System.ComponentModel.DataAnnotations;
using ControleMedicamentos.ConsoleApp.Compartilhado;
using ControleMedicamentos.ConsoleApp.ModuloFornecedores;

namespace ControleMedicamentos.ConsoleApp.ModuloMedicamentos;

public class TelaMedicamento : TelaBase<Medicamento>, ITelaOpcoes, ITelaCrud
{
    private readonly IRepositorio<Fornecedor> repositorioFornecedor;
    public TelaMedicamento(IRepositorio<Medicamento> repositorio,
    IRepositorio<Fornecedor> repositorioFornecedor) : base("Medicamento", repositorio)
    {
        this.repositorioFornecedor = repositorioFornecedor;
    }

    public override void VisualizarTodos(bool deveExibirCabecalho)
    {
        if (deveExibirCabecalho)
            ExibirCabecalho("Visualização de Medicamentos");

        List<Medicamento> medicamentos = repositorio.SelecionarTodos();

        
        if (medicamentos.Count == 0)
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
            "{0, -7} | {1, -20} | {2, -20} | {3, -20} | {4, -20}",
            "Id", "Nome", "Descrição", "Qtd. no Estoque", "Fornecedor"
        );

        foreach (Medicamento m in medicamentos)
        {   
            string quantidadeExibicao = m.QuantidadeEstoque.ToString();

            if (m.QuantidadeEstoque < 20)
                quantidadeExibicao += " (em falta)";

            Console.WriteLine(
                "{0, -7} | {1, -20} | {2, -20} | {3, -20} | {4, -20}",
                m.Id, m.Nome, m.Descricao, quantidadeExibicao, m.Fornecedor.Nome
            );
        }

        if (deveExibirCabecalho)
        {
            Console.WriteLine("---------------------------------");
            Console.Write("Digite ENTER para continuar...");
            Console.ReadLine();
        }        

    }

    protected override Medicamento ObterDadosCadastrais()
    {
        Console.Write("Digite o nome do medicamento: ");
        string nome = Console.ReadLine() ?? string.Empty;          

        Console.Write("Digite a descrição do medicamento: ");
        string descricao = Console.ReadLine() ?? string.Empty;

        Console.Write("Digite a quantidade de medicamentos: ");
        int quantidadeEstoque = Convert.ToInt32(Console.ReadLine());

        string idSelecionado = SelecionarFornecedor();

        Fornecedor? fornecedorSelecionado = repositorioFornecedor.SelecionarPorId(idSelecionado);

        return new Medicamento(nome, descricao, quantidadeEstoque, fornecedorSelecionado);
    }

    private string SelecionarFornecedor()
    {
        List<Fornecedor> fornecedores = repositorioFornecedor.SelecionarTodos();

        Console.WriteLine("---------------------------------");
  

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

        Console.ResetColor();

        Console.WriteLine("---------------------------------");
        
        string? idSelecionado;

        do
        {
            Console.Write("Digite o ID do fornecedor do medicamento: ");
            idSelecionado = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(idSelecionado) && idSelecionado.Length == 7)
                break;
        } while (true);

        return idSelecionado;
    }

}
