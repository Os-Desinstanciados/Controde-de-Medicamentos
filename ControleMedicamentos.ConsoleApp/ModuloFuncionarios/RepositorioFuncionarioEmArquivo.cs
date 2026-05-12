using ControleMedicamentos.ConsoleApp.Compartilhado;
using ControleMedicamentos.ConsoleApp.Compartilhado.Arquivos;
using ControleMedicamentos.ConsoleApp.ModuloFornecedores;

namespace ControleMedicamentos.ConsoleApp.ModuloFuncionarios;

public class RepositorioFuncionarioEmArquivo : RepositorioBaseEmArquivo<Funcionario>, IRepositorio<Funcionario>
{
    public RepositorioFuncionarioEmArquivo(ContextoJson contexto) : base(contexto)
    {
    }

    protected override List<Funcionario> CarregarRegistros()
    {
        return contexto.Funcionarios;
    }
}
