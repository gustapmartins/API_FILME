using AutoMapper;
using FilmesApi.Data;
using FilmesApi.Data.DTOS.Cinema;
using FilmesApi.ExceptionFilter;
using FilmesApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace FilmesApi.Service;

public class CinemaService

{
    private readonly FilmeContext _context;
    private readonly IMapper _mapper;

    public CinemaService(IMapper mapper, FilmeContext context)
    {
        _mapper = mapper;
        _context = context;
    }

    public List<ReadCinemaDTO> FindAll()
    {
        var find = _mapper.Map<List<ReadCinemaDTO>>(_context.Cinemas.ToList());

        if(find.Count == 0) 
        {
            throw new StudentNotFoundException("Está lista está vazia");
        }
        return find;
    }

    public CreateCinemaDTO CreateCinema(CreateCinemaDTO cinemaDto)
    {
        Cinema cinema = _mapper.Map<Cinema>(cinemaDto);
        _context.Cinemas.Add(cinema);
        _context.SaveChanges();
        return cinemaDto;
    }

    public ReadCinemaDTO FindId(int id)
    {
        Cinema cinema = _context.Cinemas.FirstOrDefault(cinema => cinema.Id == id);
        if (cinema == null)
        {
            throw new StudentNotFoundException("Not Found");
        }
        ReadCinemaDTO cinemaView = _mapper.Map<ReadCinemaDTO>(cinema);
        return cinemaView;
    }

    public UpdateCinemaDTO UpdateCinema(int id, [FromBody] UpdateCinemaDTO cinemaDto)
    {
        Cinema cinema = _context.Cinemas.FirstOrDefault(cinema => cinema.Id == id);
        if (cinema == null)
        {
            throw new StudentNotFoundException("Not Found");
        }
        _mapper.Map(cinemaDto, cinema);
        _context.SaveChanges();
        return cinemaDto;
    }

    public ReadCinemaDTO DeleteCinema(int id)
    {
        Cinema cinema = _context.Cinemas.FirstOrDefault(cinema => cinema.Id == id);
        if (cinema == null)
        {
            throw new StudentNotFoundException("Not Found");
        }
        _context.Remove(cinema);
        _context.SaveChanges();
        ReadCinemaDTO cinemaView = _mapper.Map<ReadCinemaDTO>(cinema);
        return cinemaView;
    }
}
