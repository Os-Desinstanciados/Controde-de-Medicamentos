using System;
using ControleMedicamentos.ConsoleApp.Compartilhado;
using ControleMedicamentos.ConsoleApp.ModuloFornecedores;

namespace ControleMedicamentos.ConsoleApp.ModuloMedicamentos;

public class Medicamento : EntidadeBase
{
    public string Nome { get; set; } = string.Empty;
    public string Descricao { get; set; } = string.Empty;
    public int QuantidadeEstoque { get; set; } = 0;

    public Fornecedor Fornecedor { get; set; } = null!;

  public Medicamento()
    {
    }
    
    public Medicamento(string nome, string descricao, int quantidadeEstoque, Fornecedor fornecedor) : this()
    {
        Nome = nome;
        Descricao = descricao;
        QuantidadeEstoque = quantidadeEstoque;
        Fornecedor = fornecedor;
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
        QuantidadeEstoque = medicamentoAtualizado.QuantidadeEstoque;
        Fornecedor = medicamentoAtualizado.Fornecedor;
        
    }
}
