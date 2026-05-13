using System;
using ControleMedicamentos.ConsoleApp.Compartilhado;
using ControleMedicamentos.ConsoleApp.Compartilhado.Arquivos;

namespace ControleMedicamentos.ConsoleApp.ModuloEstoque;



public class RepositorioRequisicaoEmArquivo : IRepositorioRequisicao
{
    protected readonly ContextoJson contexto;
    
    protected readonly List<RequisicaoBase> registros;
    
    public RepositorioRequisicaoEmArquivo(ContextoJson contexto)
    {
        this.contexto = contexto;
        registros = contexto.Requisicoes;
    }

    public void Cadastrar(RequisicaoBase requisicao)
    {
        registros.Add(requisicao);

        contexto.Salvar();
    }

    public List<RequisicaoSaida> SelecionarRequisicoesSaida()
    {
        List<RequisicaoSaida> requisicoesSaida = new List<RequisicaoSaida>();

        foreach (RequisicaoBase req in registros)
        {
            if (req is RequisicaoSaida reqSaida)
                requisicoesSaida.Add(reqSaida);
        }

        return requisicoesSaida;
    }
}
