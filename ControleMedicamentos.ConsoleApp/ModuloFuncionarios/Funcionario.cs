using System;
using ControleMedicamentos.ConsoleApp.Compartilhado;

namespace ControleMedicamentos.ConsoleApp.ModuloFuncionarios;

public class Funcionario : EntidadeBase
{
    public Funcionario(string nome, string telefone, string cpf)
    {
        Nome = nome;
        Telefone = telefone;
        Cpf = cpf;
    }

    public string Nome { get; set; }
    public string Telefone { get; set; }
    public string Cpf { get; set; }


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


        if (string.IsNullOrWhiteSpace(Cpf))
            erros.Add("O campo \"CPF\" deve ser preenchido.");

        else if (!Cpf.All(char.IsDigit))
            erros.Add("O campo \"CPF\" deve conter apenas números.");

        else if (Cpf.Length != 11)
            erros.Add("O campo \"CPF\" deve ter 11 dígitos");

        return erros;
    }
}
