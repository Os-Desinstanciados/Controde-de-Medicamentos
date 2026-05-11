using ControleMedicamentos.ConsoleApp.Compartilhado;
// using ControleMedicamentos.ConsoleApp.ModuloPacientes;
using ControleMedicamentos.ConsoleApp.ModuloFornecedores;
using ControleMedicamentos.ConsoleApp.ModuloMedicamentos;

namespace ControleMedicamentos.ConsoleApp.Utilidades;

public class TelaPrincipal
{
  private readonly IRepositorio<Fornecedor> repositorioFornecedor;
  private readonly IRepositorio<Medicamento> repositorioMedicamento;

  //private readonly IRepositorio<Paciente> repositorioPaciente;

  public TelaPrincipal(//IRepositorio<Paciente> repositorioPaciente,
   IRepositorio<Fornecedor> repositorioFornecedor, IRepositorio<Medicamento> repositorioMedicamento)
  {
    //this.repositorioPaciente = repositorioPaciente;
    this.repositorioFornecedor = repositorioFornecedor;
    this.repositorioMedicamento = repositorioMedicamento;
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
        Console.WriteLine("S - Sair");
        Console.WriteLine("---------------------------------");
        Console.Write("> ");
        string? opcaoMenuPrincipal = Console.ReadLine()?.ToUpper();

        // if (opcaoMenuPrincipal == "1")
        //     return new TelaPaciente(repositorioPaciente);              

        if (opcaoMenuPrincipal == "2")
            return new TelaFornecedor(repositorioFornecedor);

        if (opcaoMenuPrincipal == "3")
            return new TelaMedicamento(repositorioMedicamento, repositorioFornecedor);

        return null;
    }
}