using API_Livraria.Types;
namespace API_Livraria.Entities;

public class Livro(Guid Id)
{
    public Guid Id { get; } = Id;
    public required string Titulo { get; set; }
    public required Genero Genero { get; set; }
    public required string Autor { get; set; }
    public required double Valor { get; set; }
    public required int QtdEstoque { get; set; }
}
