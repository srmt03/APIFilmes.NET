using System.ComponentModel.DataAnnotations;

namespace WebApiFilmes.Models;

public class Movie
{
    public int Id { get; set; }

    [Required(ErrorMessage = "O Título do Filme é Obrigatório")]
    public string Title { get; set; }

    [Required(ErrorMessage = "O Gênero do Filme é Obrigatório")]
    [MaxLength(50, ErrorMessage = "O tamanho do Gênero não pode exceder 50 caracteres")]
    public string Gender { get; set; }

    [Required]
    [Range(70, 600, ErrorMessage = "A Duração deve ter entre 70 e 600 minutos")]
    public int DurationTime { get; set; }
}
