using MeuTccMvc.Models.Entity;
using Microsoft.EntityFrameworkCore;

namespace MeuTccMvc.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
    {
        public DbSet<ItemMidia> ItensMidia { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            modelBuilder.Entity<ItemMidia>()
                .Property(e => e.TipoMidia)
                .HasConversion<string>();

            modelBuilder.Seed();
        }
    }
}