using System;
using ControleDeMedicamentos.ConsoleApp.ModuloEstoque;

namespace ControleMedicamentos.ConsoleApp.ModuloEstoque;

public interface IRepositorioRequisicao
{
    void Cadastrar(RequisicaoBase requisicao);
    List<RequisicaoEntrada> SelecionarRequisicoesEntrada();
}
