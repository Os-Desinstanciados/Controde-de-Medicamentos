using System;
using ControleMedicamentos.ConsoleApp.ModuloPacientes;

namespace ControleMedicamentos.ConsoleApp.ModuloEstoque;

public class RequisicaoSaida : RequisicaoBase
{
    public Paciente Paciente { get; set; } = null!;
    public List<MedicamentoPrescrito> MedicamentosPrescritos { get; set;} = new List<MedicamentoPrescrito>();
    public RequisicaoSaida()
    {
        Tipo = TipoRequisicao.Saida;
    }

    public RequisicaoSaida(Paciente paciente, List<MedicamentoPrescrito> medicamentosPrescritos) : this()
    {
        Paciente = paciente;
        MedicamentosPrescritos = medicamentosPrescritos;
    }
}
