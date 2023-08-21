using FilmesApi.Data.DTOS.Filme;
using FilmesApi.Service;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace FilmesApi.Controllers;

[ApiController]
[Route("[controller]")]
public class FilmesController: ControllerBase
{
    private readonly FilmeService _filmeService;

    public FilmesController(FilmeService filmeService)
    {
        _filmeService = filmeService;
    }

    /// <summary>
    ///     Adiciona um filme ao banco de dados
    /// </summary>
    /// <param name="skip">Objeto com os campos necessários para criação de um filme</param>
    /// <param name="take">Objeto com os campos necessários para criação de um filme</param>
    ///     <returns>IActionResult</returns>
    /// <response code="200">Caso inserção seja feita com sucesso</response>
    [HttpGet]
    public IEnumerable<ReadFilmeDTO> FindAllFilmes([FromQuery] int skip = 0,
        [FromQuery] int take = 50)
    {
        return _filmeService.FindAll(skip, take);
    }

    [HttpGet("{id}")]
    public IActionResult FindId(int id)
    {
        return Ok(_filmeService.FindId(id));
    }

    /// <summary>
    ///     Adiciona um filme ao banco de dados
    /// </summary>
    /// <param name="filmeDto">Objeto com os campos necessários para criação de um filme</param>
    ///     <returns>IActionResult</returns>
    /// <response code="201">Caso inserção seja feita com sucesso</response>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public CreatedAtActionResult CreateFilme([FromBody] CreateFilmeDTO filmeDto)
    {
        return CreatedAtAction(nameof(FindAllFilmes), _filmeService.CreateFilme(filmeDto));
    }


    /// <summary>
    ///     Atualiza um filme ao banco de dados
    /// </summary>
    /// <param name="id">Objeto com os campos necessários para criação de um filme</param>
    /// <param name="filmeDto">Objeto com os campos necessários para criação de um filme</param>
    ///     <returns>IActionResult</returns>
    /// <response code="200">Caso inserção seja feita com sucesso</response>
    [HttpPut("{id}")]
    public IActionResult UpdateFilme(int id, [FromBody] UpdateFilmeDTO filmeDto) 
    {
        return Ok(_filmeService.UpdateFilmes(id, filmeDto));
    }

    /// <summary>
    ///     Atualiza campos especificos ao banco de dados
    /// </summary>
    /// <param name="id">Objeto com os campos necessários para criação de um filme</param>
    /// <param name="filmeDto">Objeto com os campos necessários para criação de um filme</param>
    ///     <returns>IActionResult</returns>
    /// <response code="200">Caso inserção seja feita com sucesso</response>
    [HttpPatch("{id}")]
    public IActionResult UpdateFilmeParcial(int id, JsonPatchDocument<UpdateFilmeDTO> filmeDto)
    {
        return Ok(_filmeService.UpdateFilmesParcial(id, filmeDto));
    }

    /// <summary>
    ///     Delete um filme do banco de dados
    /// </summary>
    /// <param name="id">Objeto com os campos necessários para criação de um filme</param>
    ///     <returns>IActionResult</returns>
    /// <response code="204">Caso inserção seja feita com sucesso</response>
    [HttpDelete("{id}")]
    public IActionResult DeleteFilme(int id)
    {
        return Ok(_filmeService.DeleteFilme(id));
    }
}
