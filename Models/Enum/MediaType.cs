using System.ComponentModel.DataAnnotations;

namespace MeuTccMvc.Models.Enum;

public enum MediaType
{
    [Display(Name = "Livro")]
    Book = 1,
    [Display(Name = "Filme")]
    Movie = 2,
    [Display(Name = "Série")]
    Series = 3,
}