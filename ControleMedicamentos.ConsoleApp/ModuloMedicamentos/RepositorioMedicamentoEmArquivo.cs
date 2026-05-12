using System;
using ControleMedicamentos.ConsoleApp.Compartilhado;
using ControleMedicamentos.ConsoleApp.Compartilhado.Arquivos;
using ControleMedicamentos.ConsoleApp.ModuloFornecedores;

namespace ControleMedicamentos.ConsoleApp.ModuloMedicamentos;

public class RepositorioMedicamentoEmArquivo : RepositorioBaseEmArquivo<Medicamento>, IRepositorio<Medicamento>
{
    public RepositorioMedicamentoEmArquivo(ContextoJson contexto) : base(contexto)
    {
    }

    protected override List<Medicamento> CarregarRegistros()
    {
        return contexto.Medicamentos;
    }
}
