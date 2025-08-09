using MeuTccMvc.Models;
using Microsoft.EntityFrameworkCore;

namespace MeuTccMvc.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
    {
        public DbSet<PrevisaoTempo> PrevisoesTempo { get; set; }
    }
}