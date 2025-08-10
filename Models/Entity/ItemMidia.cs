using System.ComponentModel.DataAnnotations;

namespace MeuTccMvc.Models;

public class ItemMidia
{
    [Key]
    public int Id { get; set; }

    [StringLength(255)]
    public required string Titulo { get; set; }

    [StringLength(255)]
    public required string AutorDiretor { get; set; }

    public int AnoLancamento { get; set; }

    [StringLength(100)]
    public string? Genero { get; set; }

    public string? Sinopse { get; set; }

    public required TipoMidia TipoMidia { get; set; }
}