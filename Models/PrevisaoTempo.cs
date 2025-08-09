using System.ComponentModel.DataAnnotations;

namespace MeuTccMvc.Models
{
    public class PrevisaoTempo
    {
        [Key]
        public int Id { get; set; }
        public DateOnly Data { get; set; }
        public int TemperaturaC { get; set; }
        public string? Resumo { get; set; }
        public int TemperaturaF => 32 + (int)(TemperaturaC / 0.5556);
    }
}