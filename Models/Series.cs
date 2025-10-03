using System.ComponentModel.DataAnnotations;

namespace MeuTccMvc.Models;
/// <summary>
/// Filme
/// </summary>
public class Series : MediaItem
{
    [StringLength(255)]
    public string? Director { get; set; }

    public int? Seasons { get; set; }
}