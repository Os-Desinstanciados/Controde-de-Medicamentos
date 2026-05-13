using System;
using ControleDeMedicamentos.ConsoleApp.ModuloEstoque;
using ControleMedicamentos.ConsoleApp.ModuloFuncionarios;
using ControleMedicamentos.ConsoleApp.ModuloMedicamentos;

namespace ControleMedicamentos.ConsoleApp.ModuloEstoque;

public class RequisicaoEntrada : RequisicaoBase
{
    public Funcionario Funcionario { get; set; } = null!;
    public Medicamento Medicamento { get; set; } = null!;
    public uint Quantidade { get; set; } = 0;

    public RequisicaoEntrada()
    {
        Tipo = TipoRequisicao.Entrada;
    }

    public RequisicaoEntrada(
        Funcionario funcionario,
        Medicamento medicamento,
        uint quantidade
    ) : this()
    {
        Funcionario = funcionario;
        Medicamento = medicamento;
        Quantidade = quantidade;
    }
}
