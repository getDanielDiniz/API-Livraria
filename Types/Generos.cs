using System.Text.Json.Serialization;

namespace API_Livraria.Types;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum Genero{
    Ficção,
    Romance,
    Mistério,
    Fantasia,
};

