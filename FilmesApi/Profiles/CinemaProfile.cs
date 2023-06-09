using AutoMapper;
using FilmesApi.Data.DTOS;
using FilmesApi.Models;

namespace FilmesApi.Profiles
{
    public class CinemaProfile: Profile
    {
        public CinemaProfile()
        {
            CreateMap<CreateCinemaDTO, Cinema>();
            CreateMap<Cinema, ReadCinemaDTO>()
                .ForMember(cinemaDto => cinemaDto.ReadEnderecoDTO, opt => opt.MapFrom(cinema => cinema.Endereco))
                .ForMember(cinemaDto => cinemaDto.Sessoes, opt => opt.MapFrom(cinema => cinema.Sessoes));
            CreateMap<UpdateCinemaDTO, Cinema>();
        }
    }
}
