namespace FilmesApi.Data.DTOS
{
    public class ReadCinemaDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public ReadEnderecoDTO ReadEnderecoDTO { get; set; }
        public ICollection<ReadSessaoDTO> Sessoes { get; set; }
    }
}
