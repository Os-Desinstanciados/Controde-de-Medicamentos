using ControleMedicamentos.ConsoleApp.ModuloMedicamentos;
using ControleMedicamentos.ConsoleApp.ModuloFuncionarios;
using ControleMedicamentos.ConsoleApp.Compartilhado;

namespace ControleMedicamentos.ConsoleApp.ModuloEstoque;

public class RequisicaoEntrada : EntidadeBase
{
    public DateTime Data { get; set; }
    public Medicamento Medicamento { get; set; }
    public Funcionario Funcionario { get; set; }
    public int Quantidade { get; set; }

    public RequisicaoEntrada(DateTime data, Medicamento medicamento, Funcionario funcionario, int quantidade)
    {
        Data = data;
        Medicamento = medicamento;
        Funcionario = funcionario;
        Quantidade = quantidade;
    }

    public override void AtualizarDados(EntidadeBase entidadeAtualizada)
    {
        RequisicaoEntrada requisicaoAtualizada = (RequisicaoEntrada)entidadeAtualizada;

        Data = requisicaoAtualizada.Data;
        Medicamento = requisicaoAtualizada.Medicamento;
        Funcionario = requisicaoAtualizada.Funcionario;
        Quantidade = requisicaoAtualizada.Quantidade;
    }

    public override List<string> Validar()
    {
        List<string> erros = new List<string>();

        if (Data == DateTime.MinValue)
            erros.Add("O campo \"Data\" deve ser preenchido com uma data válida.");

        if (Medicamento == null)
            erros.Add("O campo \"Medicamento\" é obrigatório.");

        if (Funcionario == null)
            erros.Add("O campo \"Funcionário\" é obrigatório.");

        if (Quantidade <= 0)
            erros.Add("O campo \"Quantidade\" deve ser um número positivo.");

        return erros;
    }
}