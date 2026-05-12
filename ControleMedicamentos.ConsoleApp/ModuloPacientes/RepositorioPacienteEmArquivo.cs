using System;
using ControleMedicamentos.ConsoleApp.Compartilhado;
using ControleMedicamentos.ConsoleApp.Compartilhado.Arquivos;

namespace ControleMedicamentos.ConsoleApp.ModuloPacientes;

public class RepositorioPacienteEmArquivo : RepositorioBaseEmArquivo<Paciente>, IRepositorio<Paciente>
{
  public RepositorioPacienteEmArquivo(ContextoJson contexto) : base(contexto)
  {
  }

  protected override List<Paciente> CarregarRegistros()
  {
    return contexto.Pacientes;
  }
}
