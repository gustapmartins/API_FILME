using Microsoft.AspNetCore.Mvc;
using FilmesApi.Service;
using FilmesApi.Models;
using FilmesApi.Data.DTOS.Cinema;

namespace FilmesApi.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class CinemaController : ControllerBase
    {
        
        private readonly CinemaService _cinemaService;
        

        public CinemaController(CinemaService cinemaService)
        {
            _cinemaService = cinemaService;
        }

        [HttpPost]
        public IActionResult CreateCinema([FromBody] CreateCinemaDTO cinemaDto)
        {
            return CreatedAtAction(nameof(FindAllCinema), _cinemaService.CreateCinema(cinemaDto));
        }

        [HttpGet]
        public List<ReadCinemaDTO> FindAllCinema()
        {
            return _cinemaService.FindAll();
        }

        [HttpGet("{id}")]
        public IActionResult findId(int id)
        {
            return Ok(_cinemaService.FindId(id));
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCinema(int id, [FromBody] UpdateCinemaDTO cinemaDto)
        {
            return Ok(_cinemaService.UpdateCinema(id, cinemaDto));
        }


        [HttpDelete("{id}")]
        public IActionResult DeleteCinema(int id)
        {
            return Ok(_cinemaService.DeleteCinema(id));
        }

    }
}