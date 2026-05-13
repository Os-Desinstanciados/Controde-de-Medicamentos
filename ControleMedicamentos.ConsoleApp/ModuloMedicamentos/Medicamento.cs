using System;
using ControleMedicamentos.ConsoleApp.Compartilhado;
using ControleMedicamentos.ConsoleApp.ModuloEstoque;
using ControleMedicamentos.ConsoleApp.ModuloFornecedores;

namespace ControleMedicamentos.ConsoleApp.ModuloMedicamentos;

public class Medicamento : EntidadeBase
{
    public string Nome { get; set; } = string.Empty;
    public string Descricao { get; set; } = string.Empty;
    
    public Fornecedor Fornecedor { get; set; } = null!;
    public List<RequisicaoBase> Requisicoes { get; set; } = new List<RequisicaoBase>();
    public uint QuantidadeEstoque
    {
        get
        {
            uint quantidadeEstoque = 0;

            foreach (RequisicaoBase req in Requisicoes)
            {
                if (req is RequisicaoSaida reqSaida)
                {
                    foreach (MedicamentoPrescrito medPresc in reqSaida.MedicamentosPrescritos)
                    {
                        if (medPresc.Medicamento == this)
                            quantidadeEstoque -= medPresc.Quantidade;
                    }
                }
            }

            return quantidadeEstoque;
        }
       
    }

  public Medicamento()
    {
    }
    
    public Medicamento(string nome, string descricao, Fornecedor fornecedor) : this()
    {
        Nome = nome;
        Descricao = descricao;        
        Fornecedor = fornecedor;
    }

    public void RegistrarRequisicao(RequisicaoBase requisicao)
    {
        Requisicoes.Add(requisicao);
    }    
        
    public override List<string> Validar()
    {
        List<string> erros = new List<string>();

    if (string.IsNullOrWhiteSpace(Nome))
      erros.Add("O campo \"Nome\" deve ser preenchido.");

    else if (Nome.Length < 3 || Nome.Length > 100)
      erros.Add("O campo \"Nome\" deve conter entre 3 e 100 caracteres.");

    else if (!Nome.Replace(" ", "").All(char.IsLetter))
      erros.Add("O campo \"Nome\" deve conter apenas letras.");


    if (string.IsNullOrWhiteSpace(Descricao))
      erros.Add("O campo \"Descrição\" deve ser preenchido.");

    else if (Descricao.Length < 5 && Descricao.Length > 200)
      erros.Add("O campo \"Descrição\" deve conter entre 5 e 200 caracteres."); 


    if (QuantidadeEstoque == 0)
      erros.Add("O campo \"Quantidade\" deve ser preenchido.");

    if (Fornecedor == null)
      erros.Add("O campo \"Fornecedor\" deve ter um fornecedor válido.");    

    return erros;
    }

    public override void AtualizarDados(EntidadeBase entidadeAtualizada)
    {
        Medicamento medicamentoAtualizado = (Medicamento)entidadeAtualizada;

        Nome = medicamentoAtualizado.Nome;
        Descricao = medicamentoAtualizado.Descricao;        
        Fornecedor = medicamentoAtualizado.Fornecedor;
        
    }
}
