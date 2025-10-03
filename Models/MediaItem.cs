using System.ComponentModel.DataAnnotations;
using MeuTccMvc.Models.Enum;
namespace MeuTccMvc.Models;
/// <summary>
/// Item de mídia base (Tabela TPH)
/// </summary>
public abstract class MediaItem
{
    public int Id { get; set; }

    [Required]
    [StringLength(500)]
    public string Title { get; set; }
    public int? ReleaseYear { get; set; }
    public MediaType MediaType { get; set; }
    public string? Genre { get; set; }
    public string? Sinopse { get; set; }
}