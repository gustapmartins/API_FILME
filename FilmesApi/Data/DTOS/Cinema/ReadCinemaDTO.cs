using FilmesApi.Data.DTOS.Endereco;
using FilmesApi.Data.DTOS.Sessao;

namespace FilmesApi.Data.DTOS.Cinema
{
    public class ReadCinemaDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public ReadEnderecoDTO Endereco { get; set; }
        public ICollection<ReadSessaoDTO> Sessoes { get; set; }
    }
}
