using API_Livraria.Entities;
using API_Livraria.DTO_s;
using API_Livraria.Types;
using System.IO;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace API_Livraria.Controllers.LivroController;
public class LivroController : LivrariaBaseController
{


    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(Livro))]
    public IActionResult Create([FromBody] LivroDTO request)
    {
        var arquivo = System.IO.File.ReadAllText("./Mockup/livros.json");
        var lista = JsonSerializer.Deserialize<List<Livro>>(arquivo);

        Livro NewLivro = new(Guid.NewGuid())
        {
            Autor = request.Autor,
            Genero = request.Genero,
            QtdEstoque = request.QtdEstoque,
            Titulo = request.Titulo,
            Valor = request.Valor,
        };

        lista?.Add(NewLivro);
        var listaSerialized = JsonSerializer.Serialize(lista, new JsonSerializerOptions { WriteIndented = true});
        System.IO.File.WriteAllText("./Mockup/livros.json",listaSerialized);

        return Ok(NewLivro);
    }

    [HttpGet]
    [ProducesResponseType(statusCode: StatusCodes.Status200OK, type: typeof(List<Livro>))]
    public IActionResult GetListaDeLivros()
    {
        var arquivo = System.IO.File.ReadAllText("./Mockup/livros.json");
        var lista = JsonSerializer.Deserialize<List<Livro>>(arquivo);

        return Ok(lista);
    }

    [HttpPut]
    [Route("{id}")]
    [ProducesResponseType(statusCode:StatusCodes.Status202Accepted, type: typeof(List<Livro>))]
    public IActionResult Update( Guid id, [FromBody] LivroDTO updatedLivro)
    {
        string arquivo = System.IO.File.ReadAllText("./Mockup/livros.json");
        List<Livro> lista = JsonSerializer.Deserialize<List<Livro>>(arquivo);

        int LivroToUpdateIndex = lista.FindIndex(Livro => Livro.Id == id);


        Livro LivroToUpdate = lista[LivroToUpdateIndex];
        LivroToUpdate.Titulo = updatedLivro.Titulo;
        LivroToUpdate.Autor = updatedLivro.Autor;
        LivroToUpdate.QtdEstoque = updatedLivro.QtdEstoque;
        LivroToUpdate.Valor = updatedLivro.Valor;

        string ListaSerialized = JsonSerializer.Serialize<List<Livro>>(lista , new JsonSerializerOptions { WriteIndented = true});
        System.IO.File.WriteAllText("./Mockup/livros.json", ListaSerialized);

         return Ok(ListaSerialized);
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(statusCode: StatusCodes.Status204NoContent)]
    public IActionResult Delete(Guid id){
        string arquivo = System.IO.File.ReadAllText("./Mockup/livros.json");
        List<Livro> lista = JsonSerializer.Deserialize<List<Livro>>(arquivo);

        Livro LivroToRemove = lista.Find( livro => livro.Id == id);

        lista.Remove(LivroToRemove);
        arquivo = JsonSerializer.Serialize<List<Livro>>(lista, new JsonSerializerOptions { WriteIndented = true});
        System.IO.File.WriteAllText("./Mockup/livros.json" , arquivo);

        return NoContent();
    }
}
