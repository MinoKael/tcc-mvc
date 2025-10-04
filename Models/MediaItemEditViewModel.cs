using MeuTccMvc.Models.Enum;

namespace MeuTccMvc.Models;
public class MediaItemEditViewModel
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public int ReleaseYear { get; set; }
    public string? Genre { get; set; }
    public string? Sinopse { get; set; }
    public MediaType MediaType { get; set; }
    public string? Author { get; set; }
    public string? Director { get; set; }
    public string? ISBN { get; set; }
    public string? Publisher { get; set; }
    public int? DurationMinutes { get; set; }
    public int? Seasons { get; set; }
}
