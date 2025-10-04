using MeuTccMvc.Models;
using Microsoft.EntityFrameworkCore;

namespace MeuTccMvc.Data
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<MediaItem> MediaItems { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MediaItem>()
            .HasDiscriminator<string>("Discriminator")
            .HasValue<Book>("Book")
            .HasValue<Movie>("Movie")
            .HasValue<Series>("Series");

            base.OnModelCreating(modelBuilder);

            modelBuilder.Seed();
        }
    }
}