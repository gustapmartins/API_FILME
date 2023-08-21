using AutoMapper;
using FilmesApi.Data.DTOS.Filme;
using FilmesApi.Models;

namespace FilmesApi.Profiles;

public class FilmeProfile: Profile
{
    public FilmeProfile()
    {
        CreateMap<CreateFilmeDTO, Filme>();
        CreateMap<UpdateFilmeDTO, Filme>();
        CreateMap<Filme, UpdateFilmeDTO>();
        CreateMap<Filme, ReadFilmeDTO>().ForMember(filmeDto => filmeDto.Sessoes, opt => opt.MapFrom(filme => filme.Sessoes)); ;
    }
}
