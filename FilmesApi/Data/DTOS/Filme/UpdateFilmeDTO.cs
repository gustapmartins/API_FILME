using System.ComponentModel.DataAnnotations;

namespace FilmesApi.Data.DTOS.Filme;

public class UpdateFilmeDTO
{
    [Required(ErrorMessage = "O titulo do filme é obrigatório")]
    public string titulo { get; set; }
    [Required(ErrorMessage = "O gênero do filme é obrigatório")]
    [StringLength(50, ErrorMessage = "O tamanho não pode ser mais que 50 caracteres")]
    public string genero { get; set; }
    [Required]
    [Range(70, 600, ErrorMessage = "A duração deve ser entre 70 e 600")]
    public int duracao { get; set; }
}
