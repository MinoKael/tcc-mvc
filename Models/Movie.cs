using System.ComponentModel.DataAnnotations;

namespace MeuTccMvc.Models;
/// <summary>
/// Filme
/// </summary>
public class Movie : MediaItem
{
    [StringLength(255)]
    public string? Director { get; set; }

    public int? DurationMinutes { get; set; }

}