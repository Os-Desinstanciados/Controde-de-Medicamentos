using System;
using ControleMedicamentos.ConsoleApp.ModuloEstoque;


namespace ControleMedicamentos.ConsoleApp.ModuloEstoque;

public interface IRepositorioRequisicao
{   
    void Cadastrar(RequisicaoBase requisicao);

    List<RequisicaoEntrada> SelecionarRequisicoesEntrada();
    List<RequisicaoSaida> SelecionarRequisicoesSaida();
}
