using System.Text.Json.Serialization;
using ControleMedicamentos.ConsoleApp.Utilidades;

namespace ControleMedicamentos.ConsoleApp.ModuloEstoque;

[JsonPolymorphic(TypeDiscriminatorPropertyName = "Tipo")]
[JsonDerivedType(typeof(RequisicaoEntrada), (int)TipoRequisicao.Entrada)]
[JsonDerivedType(typeof(RequisicaoSaida), (int)TipoRequisicao.Saida)]

public abstract class RequisicaoBase
{
    public string Id { get; set; } = GeradorIds.GerarIdCurto();
    public DateTime DataCriacao { get; set; } = DateTime.Now;
    public TipoRequisicao Tipo { get; set; } = TipoRequisicao.Indefinido;
}
