using System;
using ControleMedicamentos.ConsoleApp.Compartilhado;
using ControleMedicamentos.ConsoleApp.Utilidades;

namespace ControleMedicamentos.ConsoleApp.ModuloFuncionarios;

public class TelaFuncionario : TelaBase<Funcionario>, ITelaCrud, ITelaOpcoes
{
    public TelaFuncionario(
        IRepositorio<Funcionario> repositorio) : base("Funcionario", repositorio)
    {
    }

    public TelaFuncionario(string nomeEntidade, IRepositorio<Funcionario> repositorio) : base(nomeEntidade, repositorio)
    {
    }

    public override void VisualizarTodos(bool deveExibirCabecalho)
    {
        if (deveExibirCabecalho)
            ExibirCabecalho("Visualização de Produtos");

        List<Funcionario> produtos = repositorio.SelecionarTodos();

        if (produtos.Count == 0)
        {
            Notificador.ExibirMensagem("Nenhum item registrado.");
            return;
        }

        Console.WriteLine(
            "{0, -7} | {1, -30} | {2, -15} | {3, -20}",
            "Id", "Nome", "Telefone", "CPF"
        );

        foreach (Funcionario f in produtos)
        {
            Console.WriteLine(
                "{0, -7} | {1, -30} | {2, -15} | {3, -20}",
                f.Id, f.Nome, f.Telefone, f.Cpf
            );
        }

        if (deveExibirCabecalho)
        {
            Console.WriteLine("---------------------------------");
            Console.Write("Digite ENTER para continuar...");
            Console.ReadLine();
        }
    }

    protected override Funcionario ObterDadosCadastrais()
    {
        Console.Write("Digite o nome do funcionario: ");
        string nome = Console.ReadLine()!;

        Console.Write("Digite o telefone do funcionario: ");
        string telefone = Console.ReadLine()!;

        Console.Write("Digite o CPF do funcionario: ");
        string cpf = Console.ReadLine()!;

        return new Funcionario(nome, telefone, cpf);
    }

    protected override List<string> ValidarRegistroDuplicado(Funcionario novaEntidade, string? idIgnorado = null)
    {
        List<string> errosDuplicacao = new List<string>();

        List<Funcionario> registros = repositorio.SelecionarTodos();

        foreach (Funcionario f in registros)
        {
            if (f.Id != idIgnorado && f.Cpf == novaEntidade.Cpf)
                errosDuplicacao.Add("Já existe um registro com o CPF informado.");
        }
        return errosDuplicacao;
    }
}
