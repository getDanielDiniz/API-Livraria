using API_Livraria.Types;

namespace API_Livraria.DTO_s;

public class LivroDTO
{
    public required string Titulo { get; set; }
    public required Genero Genero { get; set; }
    public required string Autor { get; set; }
    public required double Valor { get; set; }
    public required int QtdEstoque { get; set; }
}
