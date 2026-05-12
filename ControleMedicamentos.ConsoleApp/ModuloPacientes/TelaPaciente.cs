using System;
using ControleMedicamentos.ConsoleApp.Compartilhado;
using ControleMedicamentos.ConsoleApp.Utilidades;

namespace ControleMedicamentos.ConsoleApp.ModuloPacientes;

public class TelaPaciente : TelaBase<Paciente>, ITelaCrud, ITelaOpcoes
{
  public TelaPaciente(IRepositorio<Paciente> repositorio) : base("Paciente", repositorio)
  {
  }

  public override void VisualizarTodos(bool deveExibirCabecalho)
  {
    if (deveExibirCabecalho)
      ExibirCabecalho("Visualização de Produtos");

    List<Paciente> produtos = repositorio.SelecionarTodos();

    if (produtos.Count == 0)
    {
      Notificador.ExibirMensagem("Nenhum item registrado.");
      return;
    }

    Console.WriteLine(
        "{0, -7} | {1, -30} | {2, -15} | {3, -20} | {4, -15}",
        "Id", "Nome", "Telefone", "Cartão do SUS", "CPF"
    );

    foreach (Paciente p in produtos)
    {
      Console.WriteLine(
          "{0, -7} | {1, -30} | {2, -15} | {3, -20} | {4, -15}",
          p.Id, p.Nome, p.Telefone, p.CartaoSUS, p.CPF
      );
    }

    if (deveExibirCabecalho)
    {
      Console.WriteLine("---------------------------------");
      Console.Write("Digite ENTER para continuar...");
      Console.ReadLine();
    }
  }

  protected override Paciente ObterDadosCadastrais()
  {
    Console.Write("Digite o nome do paciente: ");
    string nome = Console.ReadLine()!;

    Console.Write("Digite o telefone do paciente: ");
    string telefone = Console.ReadLine()!;

    Console.Write("Digite o Cartão SUS do paciente: ");
    string cartaoSus = Console.ReadLine()!;

    Console.Write("Digite o CPF do paciente: ");
    string cpf = Console.ReadLine()!;

    return new Paciente(nome, telefone, cartaoSus, cpf);

  }

  protected override List<string> ValidarRegistroDuplicado(Paciente novaEntidade, string? idIgnorado = null)
  {
    List<string> errosDuplicacao = new List<string>();

    List<Paciente> registros = repositorio.SelecionarTodos();

    foreach (Paciente p in registros)
    {
      if (p.Id != idIgnorado && p.CartaoSUS == novaEntidade.CartaoSUS)
        errosDuplicacao.Add("Já existe um registro com o cartao SUS informado.");
    }

    return errosDuplicacao;
  }
}
