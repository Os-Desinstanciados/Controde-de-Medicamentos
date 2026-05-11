using ControleDeMedicamentos.ConsoleApp.Compartilhado;

namespace ControleDeMedicamentos.ConsoleApp.ModuloFornecedores;

public class Fornecedor : EntidadeBase
{
    public string Nome { get; set; } = string.Empty;
    public string Telefone { get; set; } = string.Empty;
    public string Cnpj { get; set; } = string.Empty;

    public Fornecedor(string nome, string telefone, string cnpj)
    {
        Nome = nome;
        Telefone = telefone;
        Cnpj = cnpj;
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


    if (string.IsNullOrWhiteSpace(Telefone))
      erros.Add("O campo \"Telefone\" deve ser preenchido.");

    else if (Telefone.Length != 10 && Telefone.Length != 11)
      erros.Add("O campo \"Telefone\" deve conter 10 ou 11 caracteres.");
    
    else if (!Telefone.All(char.IsDigit))
      erros.Add("O campo \"Telefone\" deve conter apenas números.");

    
    if (string.IsNullOrWhiteSpace(Cnpj))
      erros.Add("O campo \"CNPJ\" deve ser preenchido.");

    else if (Cnpj.Length != 14)
      erros.Add("O campo \"CNPJ\" deve conter 14 dígitos.");

    else if (!Cnpj.All(char.IsDigit))
      erros.Add("O campo \"CNPJ\" deve conter apenas dígitos.");

    return erros;

    }

    public override void AtualizarDados(EntidadeBase entidadeAtualizada)
    {
        Fornecedor fornecedorAtualizado = (Fornecedor)entidadeAtualizada;

        Nome = fornecedorAtualizado.Nome;
        Telefone = fornecedorAtualizado.Telefone;
        Cnpj = fornecedorAtualizado.Cnpj;
        
    }    
}
