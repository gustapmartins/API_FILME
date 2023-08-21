using Microsoft.AspNetCore.Mvc;
using FilmesApi.Service;
using FilmesApi.Data.DTOS.Endereco;

namespace FilmesApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EnderecoController : ControllerBase
    {

        private readonly EnderecoService _enderecoService;

        public EnderecoController(EnderecoService enderecoService)
        {
            _enderecoService = enderecoService;
        }

        [HttpGet]
        public List<ReadEnderecoDTO> FindAllEnderecos()
        {
            return _enderecoService.FindAll();
        }

        [HttpGet("{id}")]
        public IActionResult FindEnderecosPorId(int id)
        {
            return Ok(_enderecoService.FindId(id));
        }

        [HttpPost]
        public IActionResult CreateEndereco([FromBody] CreateEnderecoDTO enderecoDto)
        {
            return CreatedAtAction(nameof(FindAllEnderecos), _enderecoService.CreateEndereco(enderecoDto));
        }

        [HttpPut("{id}")]
        public IActionResult UpdateEndereco(int id, [FromBody] UpdateEnderecoDTO enderecoDto)
        {
            return Ok(_enderecoService.UpdateEndereco(id, enderecoDto));
        }


        [HttpDelete("{id}")]
        public IActionResult DeleteEndereco(int id)
        {
            return Ok(_enderecoService.DeleteEndereco(id));
        }

    }
}