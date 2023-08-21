
using AutoMapper;
using FilmesApi.Data;
using FilmesApi.Data.DTOS.Sessao;
using FilmesApi.ExceptionFilter;
using FilmesApi.Models;

namespace FilmesApi.Service;

public class SessaoService
{
    private readonly FilmeContext _context;
    private readonly IMapper _mapper;

    public SessaoService(FilmeContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public CreateSessaoDTO CreateSessao(CreateSessaoDTO sessaoDto)
    {
        Sessao sessao = _mapper.Map<Sessao>(sessaoDto);
        _context.Sessoes.Add(sessao);
        _context.SaveChanges();
        return sessaoDto;
    }

    public List<ReadSessaoDTO> FindAllSessoes()
    {
        return _mapper.Map<List<ReadSessaoDTO>>(_context.Sessoes.ToList());
    }

    public ReadSessaoDTO FindIdSessoes(int filmeId, int cinemaId)
    {
        var sessao = _context.Sessoes.FirstOrDefault(sessao => sessao.FilmeId == filmeId && sessao.CinemaId == cinemaId);
        ReadSessaoDTO sessaoDto = _mapper.Map<ReadSessaoDTO>(sessao);

        if (sessao == null)
        {
            throw new StudentNotFoundException("Not Found");
        }
        
        return sessaoDto;
    }
}
