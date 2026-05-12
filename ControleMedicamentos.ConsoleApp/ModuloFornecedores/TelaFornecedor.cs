using ControleMedicamentos.ConsoleApp.Compartilhado;

namespace ControleMedicamentos.ConsoleApp.ModuloFornecedores;

public class TelaFornecedor : TelaBase<Fornecedor>, ITelaOpcoes, ITelaCrud
{
    public TelaFornecedor(IRepositorio<Fornecedor> repositorio) : base("Fornecedor", repositorio)
    {
    }

    public override void VisualizarTodos(bool deveExibirCabecalho)
    {
        throw new NotImplementedException();
    }

    protected override Fornecedor ObterDadosCadastrais()
    {
        throw new NotImplementedException();
    }
}
