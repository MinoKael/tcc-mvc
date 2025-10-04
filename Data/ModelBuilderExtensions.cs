using MeuTccMvc.Models;
using MeuTccMvc.Models.Enum;
using Microsoft.EntityFrameworkCore;

namespace MeuTccMvc.Data
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>().HasData(
                new Book
                {
                    Id = 1,
                    Title = "O Senhor dos Anéis: A Sociedade do Anel",
                    Author = "J.R.R. Tolkien",
                    ReleaseYear = 1954,
                    Genre = "Fantasia",
                    Sinopse = "Um jovem hobbit herda um anel mágico e perigoso...",
                    MediaType = MediaType.Book
                },
                new Book
                {
                    Id = 2,
                    Title = "Duna",
                    Author = "Frank Herbert",
                    ReleaseYear = 1965,
                    Genre = "Ficção Científica",
                    Sinopse = "A jornada de um jovem nobre em um planeta desértico...",
                    MediaType = MediaType.Book
                }
            );

            modelBuilder.Entity<Movie>().HasData(
                new Movie
                {
                    Id = 3,
                    Title = "O Poderoso Chefão",
                    Director = "Francis Ford Coppola",
                    ReleaseYear = 1972,
                    Genre = "Crime, Drama",
                    Sinopse = "O patriarca de uma dinastia do crime organizado...",
                    MediaType = MediaType.Movie
                },
                new Movie
                {
                    Id = 4,
                    Title = "Interestelar",
                    Director = "Christopher Nolan",
                    ReleaseYear = 2014,
                    Genre = "Ficção Científica, Aventura",
                    Sinopse = "Uma equipe de exploradores viaja através de um buraco...",
                    MediaType = MediaType.Movie
                }
            );

            modelBuilder.Entity<Series>().HasData(
                new Series
                {
                    Id = 5,
                    Title = "Breaking Bad",
                    Director = "Vince Gilligan",
                    ReleaseYear = 2008,
                    Genre = "Crime, Drama, Suspense",
                    Sinopse = "Um professor de química diagnosticado com câncer...",
                    MediaType = MediaType.Series
                },
                new Series
                {
                    Id = 6,
                    Title = "The Office (US)",
                    Director = "Greg Daniels",
                    ReleaseYear = 2005,
                    Genre = "Comédia",
                    Sinopse = "Um documentário sobre o dia a dia cômico...",
                    MediaType = MediaType.Series
                }
            );
        }
    }

}