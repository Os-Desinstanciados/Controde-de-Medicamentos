using ControleMedicamentos.ConsoleApp.Compartilhado;
using ControleMedicamentos.ConsoleApp.ModuloFornecedores;
using ControleMedicamentos.ConsoleApp.ModuloMedicamentos;
using ControleMedicamentos.ConsoleApp.ModuloPacientes;
using ControleMedicamentos.ConsoleApp.ModuloFuncionarios;
using ControleMedicamentos.ConsoleApp.ModuloEstoque;

namespace ControleMedicamentos.ConsoleApp.Utilidades;

public class TelaPrincipal
{
  private readonly IRepositorio<Fornecedor> repositorioFornecedor;
  private readonly IRepositorio<Paciente> repositorioPaciente;
  private readonly IRepositorio<Medicamento> repositorioMedicamento;
  private readonly IRepositorio<Funcionario> repositorioFuncionario;
  private readonly IRepositorioRequisicao repositorioRequisicao;

  public TelaPrincipal(IRepositorio<Paciente> repositorioPaciente,
  IRepositorio<Fornecedor> repositorioFornecedor,
  IRepositorio<Medicamento> repositorioMedicamento,
  IRepositorio<Funcionario> repositorioFuncionario,
  IRepositorioRequisicao repositorioRequisicao
  )
  {
    this.repositorioPaciente = repositorioPaciente;
    this.repositorioFornecedor = repositorioFornecedor;
    this.repositorioMedicamento = repositorioMedicamento;
    this.repositorioFuncionario = repositorioFuncionario;
    this.repositorioRequisicao = repositorioRequisicao;
  }

    public ITelaOpcoes? ApresentarMenuOpcoesPrincipal()
    {
        Console.Clear();
        Console.WriteLine("---------------------------------");
        Console.WriteLine("Controle de Medicamentos");
        Console.WriteLine("---------------------------------");
        Console.WriteLine("1 - Gerenciar Pacientes");
        Console.WriteLine("2 - Gestão de Fornecedores");
        Console.WriteLine("3 - Gestão de Medicamentos");
        Console.WriteLine("4 - Gestão de Funcionarios"); 
        Console.WriteLine("5 - Gestão de Estoque");       
        Console.WriteLine("S - Sair");
        Console.WriteLine("---------------------------------");
        Console.Write("> ");
        string? opcaoMenuPrincipal = Console.ReadLine()?.ToUpper();

        if (opcaoMenuPrincipal == "1")
            return new TelaPaciente(repositorioPaciente);

        if (opcaoMenuPrincipal == "2")
            return new TelaFornecedor(repositorioFornecedor);

        if (opcaoMenuPrincipal == "3")
            return new TelaMedicamento(repositorioMedicamento, repositorioFornecedor);

        if (opcaoMenuPrincipal == "4")
            return new TelaFuncionario(repositorioFuncionario);

        if (opcaoMenuPrincipal == "5")
        {
            return new TelaRequisicao(
                repositorioRequisicao,
                repositorioFuncionario,
                repositorioMedicamento,
                repositorioPaciente
            );
        }        

        return null;
    }
}