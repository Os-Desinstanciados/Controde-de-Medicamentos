using System;
using ControleMedicamentos.ConsoleApp.Compartilhado;
using ControleMedicamentos.ConsoleApp.Compartilhado.Arquivos;

namespace ControleMedicamentos.ConsoleApp.ModuloEstoque;

public interface IRepositorioRequisicao
{
    void Cadastrar(RequisicaoBase requisicao);
    
}



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
}
