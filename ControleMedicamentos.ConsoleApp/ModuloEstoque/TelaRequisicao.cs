using System;
using ControleMedicamentos.ConsoleApp.Compartilhado;

namespace ControleMedicamentos.ConsoleApp.ModuloEstoque;

public class TelaRequisicao : ITelaOpcoes
{
    public string? ObterOpcaoMenu()
    {
        Console.Clear();
        Console.WriteLine("---------------------------------");
        Console.WriteLine($"Gestão de Estoque");
        Console.WriteLine("---------------------------------");
        Console.WriteLine($"1 - Cadastrar requisição de entrada");
        Console.WriteLine($"2 - Visualizar requisições de entrada");
        Console.WriteLine($"3 - Cadastrar requisição de saída");
        Console.WriteLine($"4 - Visualizar requisições de saída");
        Console.WriteLine("S - Voltar para o início");
        Console.WriteLine("---------------------------------");
        Console.Write("> ");
        string? opcaoMenu = Console.ReadLine()?.ToUpper();

        return opcaoMenu;
    }
}
