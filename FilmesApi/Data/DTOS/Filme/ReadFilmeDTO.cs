using FilmesApi.Data.DTOS.Sessao;
using FilmesApi.Models;

namespace FilmesApi.Data.DTOS.Filme;

public class ReadFilmeDTO
{
    public string titulo { get; set; }
    public string genero { get; set; }
    public int duracao { get; set; }
    public ICollection<ReadSessaoDTO> Sessoes { get; set; }
}
