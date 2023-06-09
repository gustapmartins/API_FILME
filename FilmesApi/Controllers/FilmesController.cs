using AutoMapper;
using FilmesApi.Data;
using FilmesApi.Data.DTOS;
using FilmesApi.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace FilmesApi.Controllers;

[ApiController]
[Route("[controller]")]
public class FilmesController: ControllerBase
{
    private FilmeContext _context;
    private IMapper _mapper;

    public FilmesController(FilmeContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    /// <summary>
    /// Adiciona um filme ao banco de dados
    /// </summary>
    /// <param name="filmeDto">Objeto com os campos necessários para criação de um filme</param>
    /// <returns>IActionResult</returns>
    /// <response code="201">Caso inserção seja feita com sucesso</response>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public CreatedAtActionResult AdicionarFilme([FromBody] CreateFilmeDTO filmeDto)
    {

        Filme filme = _mapper.Map<Filme>(filmeDto); 
        _context.Filmes.Add(filme);
        _context.SaveChanges();
        return CreatedAtAction(nameof(RecuperaId), new {id = filme.Id}, filme);
    }

    [HttpGet("{id}")]
    public IActionResult RecuperaId(int id)
    {
        var filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);
        if (filme == null) return NotFound();
        var filmeDto = _mapper.Map<ReadFilmeDTO>(filme);
        return Ok(filmeDto);
    }

    [HttpGet]
    public IEnumerable<ReadFilmeDTO> RecuperaFilmes([FromQuery] int skip = 0, 
        [FromQuery] int take = 50 )
    {
        return _mapper.Map<List<ReadFilmeDTO>> 
            (_context.Filmes.Skip(skip).Take(take).ToList());
    }

    [HttpPut("{id}")]
    public IActionResult AtualizaFilme(int id, [FromBody] UpdateFilmeDTO filmeDto) 
    {
        var filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);
        if(filme == null) return NotFound();
        _mapper.Map(filmeDto, filme);
        _context.SaveChanges();
        return NoContent();
    }

    [HttpPatch("{id}")]
    public IActionResult AtualizaFilmeParcial(int id, JsonPatchDocument<UpdateFilmeDTO> filmeDto)
         
    {  
        var filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);
        if (filme == null) return NotFound();

        var filmeParaAtualizar = _mapper.Map<UpdateFilmeDTO>(filme);

        filmeDto.ApplyTo(filmeParaAtualizar, ModelState);

        if (!TryValidateModel(filmeParaAtualizar))
        {
            return ValidationProblem(ModelState);
        } 

        _mapper.Map(filmeParaAtualizar, filme);
        _context.SaveChanges();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteFilme(int id)
    {
        var filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);
        if(filme == null) return NotFound();
        _context.Remove(filme);
        _context.SaveChanges();
        return NoContent();

    }
}
