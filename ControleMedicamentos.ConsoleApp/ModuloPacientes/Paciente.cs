using ControleMedicamentos.ConsoleApp.Compartilhado;

namespace ControleMedicamentos.ConsoleApp.ModuloPacientes;

public class Paciente : EntidadeBase
{
  public string Nome { get; set; }
  public string Telefone { get; set; }
  public string CartaoSUS { get; set; }
  public string CPF { get; set; }

  public Paciente(string nome, string telefone, string cartaoSUS, string cpf)
  {
    Nome = nome;
    Telefone = telefone;
    CartaoSUS = cartaoSUS;
    CPF = cpf;
  }

  public override void AtualizarDados(EntidadeBase entidadeAtualizada)
  {
    throw new NotImplementedException();
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

    
    if (string.IsNullOrWhiteSpace(CartaoSUS))
      erros.Add("O campo \"Cartão SUS\" deve ser preenchido.");

    else if (CartaoSUS.Length != 15)
      erros.Add("O campo \"Cartão SUS\" deve conter 15 dígitos.");

    else if (!CartaoSUS.All(char.IsDigit))
      erros.Add("O campo \"Cartão SUS\" deve conter apenas dígitos.");

    if (string.IsNullOrWhiteSpace(CPF))
      erros.Add("O campo \"CPF\" deve ser preenchido.");

    else if (CPF.Length != 11)
      erros.Add("O campo \"CPF\" deve conter 11 dígitos.");

    else if (!CPF.All(char.IsDigit))
      erros.Add("O campo \"CPF\" deve conter apenas dígitos.");


    return erros;

  }
}
