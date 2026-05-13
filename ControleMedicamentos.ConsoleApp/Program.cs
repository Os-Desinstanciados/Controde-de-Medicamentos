using System.Text.Json;
using ControleMedicamentos.ConsoleApp.Compartilhado;
using ControleMedicamentos.ConsoleApp.Compartilhado.Arquivos;
using ControleMedicamentos.ConsoleApp.ModuloPacientes;
using ControleMedicamentos.ConsoleApp.ModuloFornecedores;
using ControleMedicamentos.ConsoleApp.Utilidades;
using ControleMedicamentos.ConsoleApp.ModuloMedicamentos;
using ControleMedicamentos.ConsoleApp.ModuloFuncionarios;


ContextoJson contexto = new ContextoJson();

try
{
    contexto.Carregar();
}
catch (JsonException)
{
    Notificador.ExibirMensagem("O arquivo de armazenamento está corrompido! Contate o suporte.");
    return;
}

IRepositorio<Paciente> repositorioPaciente = new RepositorioPacienteEmArquivo(contexto);
IRepositorio<Fornecedor> repositorioFornecedor = new RepositorioFornecedorEmArquivo(contexto);
IRepositorio<Medicamento> repositorioMedicamento = new RepositorioMedicamentoEmArquivo(contexto);
IRepositorio<Funcionario> repositorioFuncionario = new RepositorioFuncionarioEmArquivo(contexto);
IRepositorioRequisicao repositorioRequisicao = new RepositorioRequisicaoEmArquivo(contexto);

TelaPrincipal telaPrincipal = new TelaPrincipal(
    repositorioPaciente,
    repositorioFornecedor,
    repositorioMedicamento,
    repositorioFuncionario,
    repositorioRequisicao    
);

while (true)
{
    ITelaOpcoes? telaSelecionada = telaPrincipal.ApresentarMenuOpcoesPrincipal();

    if (telaSelecionada == null)
    {
        Console.Clear();
        break;
    }

    while (true)
    {
        string? opcaoSubMenu = telaSelecionada.ObterOpcaoMenu();

        if (opcaoSubMenu == "S")
        {
            Console.Clear();
            break;
        }

        if (telaSelecionada is ITelaCrud telaCrud)
        {
            if (opcaoSubMenu == "1")
                telaCrud.Cadastrar();

            else if (opcaoSubMenu == "2")
                telaCrud.Editar();

            else if (opcaoSubMenu == "3")
                telaCrud.Excluir();

            else if (opcaoSubMenu == "4")
                telaCrud.VisualizarTodos(deveExibirCabecalho: true);
        }

        else if (telaSelecionada is TelaRequisicao telaRequisicao)
        {
            if (opcaoSubMenu == "1")
                telaRequisicao.CadastrarRequisicaoEntrada();

            else if (opcaoSubMenu == "2")
                telaRequisicao.VisualizarRequisicoesEntrada();

            else if (opcaoSubMenu == "3")
                telaRequisicao.CadastrarRequisicaoSaida();

            else if (opcaoSubMenu == "4")
                telaRequisicao.VisualizarRequisicoesSaida();
        }
    }
}