using AutoMapper;
using FilmesApi.Data;
using FilmesApi.Data.DTOS.Filme;
using FilmesApi.ExceptionFilter;
using FilmesApi.Models;
using Microsoft.AspNetCore.JsonPatch;

namespace FilmesApi.Service;

public class FilmeService
{
    private readonly FilmeContext _context;
    private readonly IMapper _mapper;

    public FilmeService(FilmeContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public List<ReadFilmeDTO> FindAll(int skip, int take)
    {
        return _mapper.Map<List<ReadFilmeDTO>>(_context.Filmes.Skip(skip).Take(take).ToList());
    }

    public ReadFilmeDTO FindId(int id)
    {
        var filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);
        ReadFilmeDTO filmeDto = _mapper.Map<ReadFilmeDTO>(filme);

        if (filme == null)
        {
              throw new StudentNotFoundException("Not Found");
        }

        return filmeDto;
    }

    public CreateFilmeDTO CreateFilme(CreateFilmeDTO filmeDto)
    {
        Filme filme = _mapper.Map<Filme>(filmeDto);
        _context.Filmes.Add(filme);
        _context.SaveChanges();
        return filmeDto;
    }

    public UpdateFilmeDTO UpdateFilme(int id, UpdateFilmeDTO updateDto)
    {
        var update = _context.Enderecos.FirstOrDefault(endereco => endereco.id == id);
        if (update == null)
        {
            throw new StudentNotFoundException("Not Found");
        }
        _mapper.Map(updateDto, update);
        _context.SaveChanges();
        return updateDto;
    }

    public UpdateFilmeDTO UpdateFilmesParcial(int id, JsonPatchDocument<UpdateFilmeDTO> updateDto) 
    {
        var filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);
        if (filme == null)
        {
            throw new StudentNotFoundException("Not Found");
        }

        var updateMapper = _mapper.Map<UpdateFilmeDTO>(filme);

        _mapper.Map(updateMapper, filme);
        _context.SaveChanges();
        return updateMapper;
    }

    public UpdateFilmeDTO UpdateFilmes(int id, UpdateFilmeDTO updateDto)
    {
        var filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);
        if (filme == null)
        {
            throw new StudentNotFoundException("Not Found");
        }
        _mapper.Map(updateDto, filme);
        _context.SaveChanges();
        return updateDto;
    }


    public ReadFilmeDTO DeleteFilme(int id)
    {
        var filme = _context.Enderecos.FirstOrDefault(endereco => endereco.id == id);
        ReadFilmeDTO filmeView = _mapper.Map<ReadFilmeDTO>(filme);
        if (filme == null)
        {
            throw new StudentNotFoundException("Not Found");
        }
        _context.Remove(filme);
        _context.SaveChanges();
        return filmeView;
    }
}
