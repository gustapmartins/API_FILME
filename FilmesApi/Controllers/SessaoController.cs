using Microsoft.AspNetCore.Mvc;
using FilmesApi.Data.DTOS.Sessao;
using FilmesApi.Service;

namespace FilmesApi.Controllers;

[ApiController]
[Route("[controller]")]
public class SessaoController : ControllerBase
{
    private readonly SessaoService _sessaoService;

    private SessaoController(SessaoService sessaoService)
    {
        _sessaoService = sessaoService;
    }

    [HttpGet]
    public IActionResult FindAllSessoes()
    {
        return Ok(_sessaoService.FindAllSessoes());
    }
    
    [HttpPost]
    public IActionResult CreateSessao(CreateSessaoDTO createDto)
    {
        return CreatedAtAction(nameof(FindIdSessoes), _sessaoService.CreateSessao(createDto));
    }

    [HttpGet("{filmeId}/{cinemaId}")]
    public IActionResult FindIdSessoes(int filmeId, int cinemaId)
    {
        return Ok(_sessaoService.FindIdSessoes(filmeId, cinemaId));
    }
}