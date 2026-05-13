using System;

namespace ControleMedicamentos.ConsoleApp.ModuloEstoque;

public interface IRepositorioRequisicao
{
    void Cadastrar(RequisicaoBase requisicao);

    List<RequisicaoSaida> SelecionarRequisicoesSaida();
}
