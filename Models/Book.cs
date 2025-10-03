using System.ComponentModel.DataAnnotations;

namespace MeuTccMvc.Models;

/// <summary>
/// Livro
/// </summary>
public class Book : MediaItem
{
    [StringLength(255)]
    public string? Author { get; set; }

    [StringLength(50)]
    public string? ISBN { get; set; }

    [StringLength(255)]
    public string? Publisher { get; set; }
}